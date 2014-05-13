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
    public class ARMCalculationStipendViewModel : ARMServiceViewModelBase, IARMCalculationStipendViewModel
    {
        public ARMCalculationStipendViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMCalculationStipendView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        public override string Title
        {
            get { return Resource.AppResource.Resources.Service_CalculationStipend_Title; }
        }

        #region [properties]

        public ObservableCollection<Group> Groups
        {
            get { return Get(() => Groups); }
            set { Set(() => Groups, value); }
        }

        public ObservableCollection<Session> Sessions
        {
            get { return Get(() => Sessions); }
            set { Set(() => Sessions, value); }
        }

        public Group SelectedGroup
        {
            get { return Get(() => SelectedGroup); }
            set { Set(() => SelectedGroup, value); }
        }

        public Session SelectedSession
        {
            get { return Get(() => SelectedSession); }
            set { Set(() => SelectedSession, value); }
        }

        public ObservableCollection<ARMStudentStipendViewModel> StudentStipendsSource
        {
            get { return Get(() => StudentStipendsSource); }
            set { Set(() => StudentStipendsSource, value); }
        }

        public ICommand CalculateCommand { get; private set; }

        public ICommand ApplyCommand { get; private set; }

        #endregion

        #region [overrides]

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

        private void CalculateExecute(object arg)
        {
            IsBusy = true;
            Task.Factory.StartNew(InternalProcessCalculationOfStipend);
        }

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

        private bool CanCalculateExecute(object arg)
        {
            return SelectedGroup != null && SelectedSession != null;
        }

        private void ApplyExecute(object arg)
        {
            IsBusy = true;
            Task.Factory.StartNew(InternalApplyResults);
        }

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

        private bool CanApplyExecute(object arg)
        {
            return StudentStipendsSource != null && StudentStipendsSource.Count > 0;
        }

        #endregion

    }
}