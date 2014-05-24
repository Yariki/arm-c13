using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.Services.CalculationStipend.View;
using ARM.Module.Interfaces.Services.CalculationStipend.ViewModel;
using ARM.Module.ViewModel.Services.CalculationStipend.Stipend;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.Services.CalculationStipend
{
    /// <summary>
    /// Клас який признаяений для розрахунку стипендій студентам по результатам сесії.
    /// </summary>
    public class ARMCalculationStipendViewModel : ARMServiceViewModelBase, IARMCalculationStipendViewModel
    {
        /// <summary>
        /// Створити екземпляр <see cref="ARMCalculationStipendViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public ARMCalculationStipendViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMCalculationStipendView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
        public override string Title
        {
            get { return Resource.AppResource.Resources.Service_CalculationStipend_Title; }
        }

        #region [properties]

        /// <summary>
        /// ОТримує або задає список груп.
        /// </summary>
        public ObservableCollection<Group> Groups
        {
            get { return Get(() => Groups); }
            set { Set(() => Groups, value); }
        }

        /// <summary>
        /// Отримує або задає список сесій.
        /// </summary>
        public ObservableCollection<Session> Sessions
        {
            get { return Get(() => Sessions); }
            set { Set(() => Sessions, value); }
        }

        /// <summary>
        /// Отримує або задає обрану групу.
        /// </summary>
        public Group SelectedGroup
        {
            get { return Get(() => SelectedGroup); }
            set { Set(() => SelectedGroup, value); }
        }

        /// <summary>
        /// Отримує або задає обрану сесїю.
        /// </summary>
        public Session SelectedSession
        {
            get { return Get(() => SelectedSession); }
            set { Set(() => SelectedSession, value); }
        }

        /// <summary>
        /// Отримує або задає дані з розрахованими стипендіями.
        /// Дана колекція відображається на екрані.
        /// </summary>
        public ObservableCollection<ARMStudentStipendViewModel> StudentStipendsSource
        {
            get { return Get(() => StudentStipendsSource); }
            set { Set(() => StudentStipendsSource, value); }
        }

        /// <summary>
        /// Команда розхрахунку стипендій.
        /// </summary>
        public ICommand CalculateCommand { get; private set; }

        /// <summary>
        /// Команда застосування даних розрахунку для оновлення інформайції для студента.
        /// </summary>
        public ICommand ApplyCommand { get; private set; }

        #endregion

        #region [overrides]

        /// <summary>
        /// Проводить ініціалізацію вкладки і моделі представлення вцілому.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            Groups = new ObservableCollection<Group>(UnitOfWork.GroupRepository.GetAll().ToList());
            Sessions = new ObservableCollection<Session>(UnitOfWork.SessionRepository.GetAll().ToList());
            CalculateCommand = new ARMRelayCommand(CalculateExecute, CanCalculateExecute);
            ApplyCommand = new ARMRelayCommand(ApplyExecute,CanApplyExecute);
        }

        #endregion

        #region [private]

        /// <summary>
        /// Запускає процес розрахунку в потоці.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        private void CalculateExecute(object arg)
        {
            IsBusy = true;
            Task.Factory.StartNew(InternalProcessCalculationOfStipend);
        }

        /// <summary>
        /// Процес розрахунку стипендій по результатам сесії.
        /// </summary>
        private void InternalProcessCalculationOfStipend()
        {
            var listStudent = SelectedGroup.Students.Select(s => s.Id);
            var listClasses = SelectedSession.Classes.Select(c => c.Id);
            var filterResult =
                UnitOfWork.MarkRepository.GetAll(
                    new Func<Data.Models.Mark, bool>(
                        m => listClasses.Contains(m.ClassId.Value) && listStudent.Contains(m.StudentId.Value)));
            var list = new List<ARMStudentMarksData>();
            listStudent.ForEach(s =>
            {
                var sd = new ARMStudentMarksData() { StudentId = s };
                foreach (var cl in listClasses)
                {
                    var summark = filterResult.Where(m => m.StudentId == s && m.ClassId.Value == cl)
                        .Sum(m => m.MarkRate);
                    sd.SumMarks.Add(cl, UnitOfWork.RateRepositary.GetApproprialRate(summark));
                }
                list.Add(sd);
            });

            decimal commonStipend = UnitOfWork.SettingsRepository.GetCommomStipend();
            decimal increasedStipend = UnitOfWork.SettingsRepository.GetIncreasedStipend();
            decimal commonMark = UnitOfWork.SettingsRepository.GetCommonMark();
            decimal increasedMark = UnitOfWork.SettingsRepository.GetIncreasedMark();

            var result = new ObservableCollection<ARMStudentStipendViewModel>();
            foreach (var armStudentMarksData in list)
            {
                var st = new ARMStudentStipendViewModel()
                {
                    Student = SelectedGroup.Students.FirstOrDefault(s => s.Id == armStudentMarksData.StudentId)
                };
                st.Rate = armStudentMarksData.SumMarks.Values.Average(r => r.Mark);
                st.CurrentStipend = st.Student.Stipend;
                st.CalculatedStipend = commonMark <= st.Rate && st.Rate < increasedMark
                    ? commonStipend
                    : st.Rate == increasedMark ? increasedStipend : commonStipend;
                result.Add(st);
            }

            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                StudentStipendsSource = result;
                IsBusy = false;
            }));
        }

        /// <summary>
        /// Визначає чи доступна кнопка розрахунку.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        /// <returns></returns>
        private bool CanCalculateExecute(object arg)
        {
            return SelectedGroup != null && SelectedSession != null;
        }

        /// <summary>
        /// Застосування розрахованих даних.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        private void ApplyExecute(object arg)
        {
            IsBusy = true;
            Task.Factory.StartNew(InternalApplyResults);
        }

        /// <summary>
        /// Процес застосування розрахованих значень.
        /// </summary>
        private void InternalApplyResults()
        {
            ARMSystemFacade.Instance.Logger.LogInfo("Start applying stipend...");
            try
            {
                foreach (var armStudentStipendViewModel in StudentStipendsSource)
                {
                    armStudentStipendViewModel.Student.Stipend = armStudentStipendViewModel.CalculatedStipend;
                    UnitOfWork.StudentRepository.Update(armStudentStipendViewModel.Student);
                }
                UnitOfWork.StudentRepository.Save();
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// Визначає чи кнопка застосувати доступна.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        /// <returns></returns>
        private bool CanApplyExecute(object arg)
        {
            return StudentStipendsSource != null && StudentStipendsSource.Count > 0;
        }

        #endregion

    }
}