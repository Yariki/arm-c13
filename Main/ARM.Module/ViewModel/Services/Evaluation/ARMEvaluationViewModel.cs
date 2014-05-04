using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.Services.Evaluation.View;
using ARM.Module.Interfaces.Services.Evaluation.ViewModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Models = ARM.Data.Models;
namespace ARM.Module.ViewModel.Services.Evaluation
{
    public class ARMEvaluationViewModel : ARMDataViewModelBase,IARMEvaluationViewModel
    {
        public ARMEvaluationViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMEvaluationView view) 
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        public override string Title
        {
            get { return Resource.AppResource.Resources.Service_Evaluation_Title; }
        }

        #region [properties]

        public ObservableCollection<Group> GroupList
        {
            get; private set;
        }

        public ObservableCollection<Student> StudentList
        {
            get; private set;
        }

        public ObservableCollection<Models.Mark> MarkList
        {
            get; private set;
        }

        public ObservableCollection<Class> ClassList { get; private set; }

        public ObservableCollection<Session> SessionList { get; private set; }

        public Group SelectedGroup
        {
            get { return Get(() => SelectedGroup); }
            set { Set(() => SelectedGroup, value); }
        }

        public Student SelectedStudent
        {
            get { return Get(() => SelectedStudent); }
            set { Set(() => SelectedStudent, value); }
        }

        public Class SelectedClass
        {
            get { return Get(() => SelectedClass); }
            set { Set(() => SelectedClass, value); }
        }

        public Session SelectedSession
        {
            get { return Get(() => SelectedSession); }
            set { Set(() => SelectedSession, value); }
        }

        public Models.Mark SelectedMark
        {
            get { return Get(() => SelectedMark); }
            set { Set(() => SelectedMark, value); }
        }

        public Type TypeMark { get { return typeof (Models.Mark); } }

        #endregion

        #region [private]

        private void GroupChanged()
        {
            
        }

        private void StudentChanged()
        {
            
        }
        // m => m.StudentId == StudenyId && m.ClassId == ClassId
        // m => m.
        private Expression<Func<Models.Mark, bool>> BuildFilterFunction()
        {
            ParameterExpression pe = Expression.Parameter(typeof(Models.Mark), "m");
            //m.StudentId == StudenyId
            Expression ex1 = null;
            if (SelectedStudent != null)
            {
                Expression left = Expression.Property(pe, typeof(Models.Mark).GetProperty("StudentId", System.Type.EmptyTypes));
                Expression right = Expression.Constant(SelectedStudent.Id);
                ex1 = Expression.And(left, right);
            }
            Expression ex2 = null;
            if (SelectedClass != null)
            {
                Expression left = Expression.Property(pe, typeof(Models.Mark).GetProperty("ClassId", System.Type.EmptyTypes));
                Expression right = Expression.Constant(SelectedClass.Id);
                ex2 = Expression.And(left, right);
            }
            return (Expression<Func<Models.Mark, bool>>)(ex1 != null && ex2 != null
                ? Expression.And(ex1, ex2)
                : ex1 != null
                    ? ex1
                    : ex2 != null ? ex2 : null);
        }

        #endregion

    }
}