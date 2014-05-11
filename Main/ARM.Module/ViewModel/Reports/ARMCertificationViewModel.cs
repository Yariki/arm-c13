using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.Reports.View;
using ARM.Module.Interfaces.Reports.ViewModel;
using ARM.Module.ViewModel.Reports.Certification;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using DataGrid = Xceed.Wpf.DataGrid;

namespace ARM.Module.ViewModel.Reports
{
    public class ARMCertificationViewModel : ARMReportViewModelBase,IARMCertificationViewModel
    {
        public ARMCertificationViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMCertificationView view) 
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        public override string Title
        {
            get { return Resource.AppResource.Resources.Report_Certification_Title; }
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

        public ObservableCollection<ARMStudentCertificationData> DataSource
        {
            get { return Get(() => DataSource); }
            set { Set(() => DataSource, value); }
        }

        public ObservableCollection<GridViewColumn> Columns
        {
            get { return Get(() => Columns); }
            set { Set(() => Columns, value); }
        }


        public ICommand RunCommand { get; private set; }

        #endregion

        #region [overrides]

        public override void Initialize()
        {
            base.Initialize();
            Groups = new ObservableCollection<Group>(UnitOfWork.GroupRepository.GetAll());
            Sessions = new ObservableCollection<Session>(UnitOfWork.SessionRepository.GetAll());
            SelectedGroup = null;
            SelectedSession = null;
            RunCommand = new ARMRelayCommand(RunExecute,CanRunExecute);
            Columns = new ObservableCollection<GridViewColumn>();
        }

        #endregion

        #region [private]

        private void RunExecute(object arg)
        {
            if (DataSource != null)
            {
                DataSource.Clear();
                DataSource = null;
            }
            var data = new ObservableCollection<ARMStudentCertificationData>();
            var listStudents = SelectedGroup.Students.Select(s => s.Id);
            var listClasses = SelectedSession.Classes.Select(c => c.Id);
            var marks =
                UnitOfWork.MarkRepository.GetAll(
                    new Func<Mark, bool>(
                        m =>
                            listStudents.Contains(m.StudentId.Value) && listClasses.Contains(m.ClassId.Value) &&
                            m.Type == MarkType.Certification)).GroupBy(m => new {m.StudentId,m.ClassId });
            foreach (var mark in marks)
            {
                var studentCert = AddAndGetData(data, mark.Key.StudentId.Value);
                foreach (var mark1 in mark.OrderBy(m => m.ClassId))
                {
                    studentCert[mark.Key.ClassId.ToString().ToLower()] = new ARMCertificationDetailsData()
                    {
                        Name = mark1.Name,
                        IsCertificated = mark1.IsCertification,
                        Date = mark1.Date.Value
                    };
                }    
            }
            GenerateColumns();
            DataSource = data;
        }

        private ARMStudentCertificationData AddAndGetData(ObservableCollection<ARMStudentCertificationData> list, Guid id)
        {
            var data = list.FirstOrDefault(s => s.Student.Id == id);
            if (data == null)
            {
                var st = new ARMStudentCertificationData() {Student = SelectedGroup.Students.First(s => s.Id == id)};
                list.Add(st);
                return st;
            }
            return data;
        }

        private void GenerateColumns()
        {
            Columns.Clear();
            Columns = null;
            var col = new ObservableCollection<GridViewColumn>();
            var name = new GridViewColumn { Width = 200, Header = Resource.AppResource.Resources.Model_Student_Title };
            //name.DisplayMemberBinding = new Binding("Student.Display");
            col.Add(name);
            foreach (var source in SelectedSession.Classes.OrderBy(c => c.Name))
            {
                var c = new GridViewColumn() { Width = 150, Header = source.Name};
                //c.DisplayMemberBinding = new Binding(string.Format("[{0}]", source.Id.ToString().ToLower()));
                col.Add(c);
            }
            Columns = col;
        }

        private bool CanRunExecute(object arg)
        {
            return SelectedGroup != null && SelectedSession != null;
        }

        #endregion
    }
}