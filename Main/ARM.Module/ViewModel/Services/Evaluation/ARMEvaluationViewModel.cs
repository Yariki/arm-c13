using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Documents;
using System.Windows.Input;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Infrastructure.Controls.ARMDialogWindow;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.MVVM;
using ARM.Module.Commands.Menu.Reference;
using ARM.Module.Interfaces.Services.Evaluation.View;
using ARM.Module.Interfaces.Services.Evaluation.ViewModel;
using ARM.Module.Interfaces.Services.Mark.ViewModel;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Xceed.Wpf.DataGrid.FilterCriteria;
using Models = ARM.Data.Models;
namespace ARM.Module.ViewModel.Services.Evaluation
{
    /// <summary>
    /// Клас що забезпечує функціональність по відслідковуванні успішності студентів протягом сесії.
    /// Допомагає вносити бали по предметам і атестаціям.
    /// </summary>
    public class ARMEvaluationViewModel : ARMServiceViewModelBase, IARMEvaluationViewModel
    {
        #region [needs]

        private bool _initialize = false;

        #endregion

        /// <summary>
        /// Створити екземпляр <see cref="ARMEvaluationViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public ARMEvaluationViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMEvaluationView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            AddMarkCommand = new ARMRelayCommand(AddMarkExecute);
            EditMarkCommand = new ARMRelayCommand(EditMarkExecute);
            DeleteMarkCommand = new ARMRelayCommand(DeleteMarkExecute);
        }

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
        public override string Title
        {
            get { return Resource.AppResource.Resources.Service_Evaluation_Title; }
        }

        #region [commands]

        /// <summary>
        /// Команда для додавання оцінки.
        /// </summary>
        public ICommand AddMarkCommand { get; private set; }
        /// <summary>
        /// Команда для редагування оцінки.
        /// </summary>
        public ICommand EditMarkCommand { get; private set; }
        /// <summary>
        /// Команда видалення оцінки.
        /// </summary>
        public ICommand DeleteMarkCommand { get; private set; }

        #endregion


        #region [properties]

        /// <summary>
        /// ОТримує список груп.
        /// </summary>
        public ObservableCollection<Group> GroupList
        {
            get;
            private set;
        }

        /// <summary>
        /// Отримує список студентів.
        /// </summary>
        public ObservableCollection<Student> StudentList
        {
            get;
            private set;
        }

        /// <summary>
        /// Отримує список оцінок.
        /// </summary>
        public ObservableCollection<Models.Mark> MarkList
        {
            get;
            private set;
        }

        /// <summary>
        /// Отримує список класів/занять.
        /// </summary>
        public ObservableCollection<Class> ClassList { get; private set; }

        /// <summary>
        /// Отримує список сесій.
        /// </summary>
        public ObservableCollection<Session> SessionList { get; private set; }

        /// <summary>
        /// отримує або задає обрану групу.
        /// </summary>
        public Group SelectedGroup
        {
            get { return Get(() => SelectedGroup); }
            set
            {
                Set(() => SelectedGroup, value);
                GroupChanged();
            }
        }

        /// <summary>
        /// Отримує або задає обраного студента.
        /// </summary>
        public Student SelectedStudent
        {
            get { return Get(() => SelectedStudent); }
            set
            {
                Set(() => SelectedStudent, value);
                StudentChanged();
            }
        }

        /// <summary>
        /// Отримує або задає обраний клас/заняття.
        /// </summary>
        public Class SelectedClass
        {
            get { return Get(() => SelectedClass); }
            set
            {
                Set(() => SelectedClass, value);
                ClassChanged();
            }
        }

        /// <summary>
        /// Отримує або задає обрану сесію.
        /// </summary>
        public Session SelectedSession
        {
            get { return Get(() => SelectedSession); }
            set
            {
                Set(() => SelectedSession, value);
                SessionChanged();
            }
        }

        /// <summary>
        /// Отримує або задає обрану оцінку.
        /// </summary>
        public Models.Mark SelectedMark
        {
            get { return Get(() => SelectedMark); }
            set { Set(() => SelectedMark, value); }
        }

        /// <summary>
        /// Отримує тип оцінки.
        /// </summary>
        public Type TypeMark { get { return typeof(Models.Mark); } }

        #endregion

        #region [override]

        /// <summary>
        /// Проводить ініціалізацію вкладки і моделі представлення вцілому.
        /// </summary>
        public override void Initialize()
        {
            _initialize = true;
            base.Initialize();
            GroupList = new ObservableCollection<Group>(UnitOfWork.GroupRepository.GetAllWithRelated());
            SessionList = new ObservableCollection<Session>(UnitOfWork.SessionRepository.GetAllWithRelated());
            StudentList = new ObservableCollection<Student>();
            ClassList = new ObservableCollection<Class>();
            MarkList = new ObservableCollection<Models.Mark>();
            SelectedClass = null;
            SelectedGroup = null;
            SelectedSession = null;
            SelectedStudent = null;
            _initialize = false;
        }

        #endregion


        #region [private]

        /// <summary>
        /// Виконується при зміні групи.
        /// Фільтрує оцінки в сітці.
        /// </summary>
        private void GroupChanged()
        {
            if (SelectedGroup == null)
                return;
            StudentList.Clear();
            StudentList.AddRange(SelectedGroup.Students);
            OnPropertyChanged(() => StudentList);
            UpdateMarks(false);
        }

        /// <summary>
        /// Виконується при зміні сесії.
        /// Фільтрує оцінки в сітці.
        /// </summary>
        private void SessionChanged()
        {
            if (SelectedSession == null)
                return;
            ClassList.Clear();
            ClassList.AddRange(SelectedSession.Classes);
            OnPropertyChanged(() => ClassList);
            UpdateMarks(false);
        }

        /// <summary>
        /// Виконується при зміні студента.
        /// Фільтрує оцінки відносно студента.
        /// </summary>
        private void StudentChanged()
        {
            UpdateMarks();
        }

        /// <summary>
        /// Виконується при зміні класу.
        /// Фільтрує оцінки відносно класу.
        /// </summary>
        private void ClassChanged()
        {
            UpdateMarks();
        }

        // m => m.StudentId == StudenyId && m.ClassId == ClassId
        // m => m.
        /// <summary>
        /// Будує вираз для фільтрації відносно студента і занятя.
        /// </summary>
        /// <returns></returns>
        private Expression<Func<Models.Mark, bool>> BuildFilterFunctionStudentClass()
        {
            ParameterExpression pe = Expression.Parameter(typeof(Models.Mark), "m");
            //m.StudentId == StudenyId
            Expression ex1 = null;
            if (SelectedStudent != null)
            {
                Expression left = Expression.Property(pe, typeof(Models.Mark).GetProperty("StudentId", System.Type.EmptyTypes));
                Expression right = Expression.Constant(SelectedStudent.Id, typeof(Guid?));
                ex1 = Expression.Equal(left, right);
            }
            // m.ClassId == ClassId
            Expression ex2 = null;
            if (SelectedClass != null)
            {
                Expression left = Expression.Property(pe, typeof(Models.Mark).GetProperty("ClassId", System.Type.EmptyTypes));
                Expression right = Expression.Constant(SelectedClass.Id, typeof(Guid?));
                ex2 = Expression.Equal(left, right);
            }
            return ex1 != null && ex2 != null
                ? Expression.Lambda<Func<Models.Mark, bool>>(Expression.And(ex1, ex2), pe) //m => m.StudentId == StudenyId && m.ClassId == ClassId
                : ex1 != null
                    ? Expression.Lambda<Func<Models.Mark, bool>>(ex1, pe) //m => m.StudentId == StudenyId 
                    : ex2 != null ? Expression.Lambda<Func<Models.Mark, bool>>(ex2, pe) //m => m.ClassId == ClassId
                    : null;
        }

        /// <summary>
        /// Будує вираз для фільтрації відносно групи та сесії.
        /// </summary>
        /// <returns></returns>
        private Expression<Func<Models.Mark, bool>> BuildFilterFunctionGroupSession()
        {
            ParameterExpression pe = Expression.Parameter(typeof(Models.Mark), "m");

            // m => listStudents.Contains(m.StudentId)
            Expression ex1 = null;
            MethodCallExpression mEx1 = null;
            if (SelectedGroup != null)
            {
                var listID = SelectedGroup.Students.Select(s => s.Id).ToList();
                ConstantExpression keys = Expression.Constant(listID, typeof (List<Guid>));
                Expression prop = Expression.Property(pe, "StudentId");
                Expression convertExpression = Expression.Convert(prop, typeof(Guid));
                mEx1 = Expression.Call(keys, "Contains", new Type[] { }, convertExpression);
                ex1 = Expression.Lambda<Func<Models.Mark, bool>>(mEx1, pe);
            }
            Expression ex2 = null;
            MethodCallExpression mEx2 = null;
            if (SelectedSession != null)
            {
                var listID = SelectedSession.Classes.Select(s => s.Id).ToList();
                ConstantExpression keys = Expression.Constant(listID, typeof(List<Guid>));
                Expression prop = Expression.Property(pe, "ClassId");
                Expression convertExpression = Expression.Convert(prop, typeof(Guid));
                mEx2 = Expression.Call(keys, "Contains", new Type[] { }, convertExpression);
                ex2 = Expression.Lambda<Func<Models.Mark, bool>>(mEx2, pe);
            }
            return (Expression<Func<Models.Mark, bool>>)(mEx1 != null && mEx2 != null
                ? Expression.Lambda<Func<Models.Mark, bool>>(Expression.And(mEx1,mEx2), pe)
                : ex1 != null
                    ? ex1
                    : ex2 != null ? ex2 : null);
        }

        /// <summary>
        /// Застосування фільтрації.
        /// </summary>
        /// <param name="isOld">if set to <c>true</c> [is old].</param>
        private void UpdateMarks(bool isOld = true)
        {
            if (_initialize)
                return;
            MarkList.Clear();
            var exp = isOld ? BuildFilterFunctionStudentClass() : BuildFilterFunctionGroupSession();
            var listMarks = UnitOfWork.MarkRepository.GetAll(exp);
            MarkList.AddRange(listMarks);
            OnPropertyChanged(() => MarkList);
        }


        /// <summary>
        /// Додавання оцінки.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        private void AddMarkExecute(object arg)
        {
            ProcessMark(ViewMode.Add,Guid.Empty);
        }

        /// <summary>
        /// Редагування оцінки.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        private void EditMarkExecute(object arg)
        {
            if(SelectedMark == null)
                return;
            ProcessMark(ViewMode.Edit,SelectedMark.Id);
        }

        /// <summary>
        /// Видалення оцінки.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        private void DeleteMarkExecute(object arg)
        {
            if(SelectedMark == null)
                return;
            UnitOfWork.MarkRepository.Delete(SelectedMark);
            UnitOfWork.MarkRepository.Save();
            UpdateMarks();
        }

        /// <summary>
        /// Процес роботи з оцінками.
        /// </summary>
        /// <param name="mode">Режим.</param>
        /// <param name="id">Ідентифікатор.</param>
        private void ProcessMark(ViewMode mode, Guid id)
        {
            IARMMarkValidatableViewModel markViewModel = UnityContainer.Resolve<IARMMarkValidatableViewModel>();
            try
            {
                markViewModel.SetBusinessObject(mode, eARMMetadata.Mark, id, false);
                if (mode == ViewMode.Add)
                {
                    if (SelectedStudent != null)
                    {
                        markViewModel.SetStudent(SelectedStudent.Id);
                    }
                    if (SelectedClass != null)
                    {
                        markViewModel.SetClass(SelectedClass.Id);
                    }
                }
                ARMDialogWindow dlg = new ARMDialogWindow(markViewModel) { Width = 510, Height = 250 };
                var result = dlg.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    var entity = markViewModel.GetBusinessObject<Models.Mark>();
                    if (mode == ViewMode.Add)
                        entity.Id = Guid.NewGuid();
                    switch (mode)
                    {
                        case ViewMode.Add:
                            UnitOfWork.MarkRepository.Insert(entity);
                            break;
                        case ViewMode.Edit:
                            UnitOfWork.MarkRepository.Update(entity);
                            break;
                    }
                    UnitOfWork.MarkRepository.Save();
                    UpdateMarks();
                }
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }
            finally
            {
                if (markViewModel != null)
                    markViewModel.Dispose();
            }
        }

        #endregion

    }
}