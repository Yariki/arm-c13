using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.MVVM;
using ARM.Module.Commands.Menu.Report;
using ARM.Module.Interfaces.Reports.View;
using ARM.Module.Interfaces.Reports.ViewModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.Reports
{
    public class ARMStudentListDeductViewModel : ARMReportGroupSessionViewModelBase, IARMStudentListDeductViewModel
    {
        private const int CountFailedCertification = 3;

        public ARMStudentListDeductViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMStudentListDeductView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        public override string Title
        {
            get { return Resource.AppResource.Resources.Report_Deduct_Title; }
        }

        #region [properties]

        public ICommand RunCommand { get; private set; }

        public ICommand WordUnloadCommand { get; set; }

        public ObservableCollection<object> DataSource
        {
            get { return Get(() => DataSource); }
            set { Set(() => DataSource, value); }
        }

        #endregion

        #region [overrides]

        public override void Initialize()
        {
            base.Initialize();
            SelectedGroup = null;
            SelectedSession = null;
            DataSource = new ObservableCollection<object>();
            RunCommand = new ARMRelayCommand(RunExecute,CanRunExecute);
        }

        protected override bool CanExportExecute(object arg)
        {
            return DataSource != null && DataSource.Count > 0;
        }

        #endregion

        #region [private]

        private bool CanRunExecute(object arg)
        {
            return SelectedGroup != null && SelectedSession != null;
        }

        private void RunExecute(object arg)
        {
            if (DataSource != null && DataSource.Count > 0)
            {
                DataSource.Clear();
            }
            IsBusy = true;
            Task.Factory.StartNew(InternalProcess);
        }

        private void InternalProcess()
        {
            try
            {
                var listClasses = SelectedSession.Classes.Select(c => c.Id);
                var listStudet = SelectedGroup.Students.Select(s => s.Id);
                var certFailed = UnitOfWork.MarkRepository.GetMarkAccordingStudentsAndClasses(listStudet, listClasses)
                    .Where(m => m.Type == MarkType.Certification)
                    .GroupBy(m => new {m.StudentId, m.ClassId})
                    .Select(g =>
                        new
                        {
                            StudetnId = g.Key.StudentId,
                            ClassId = g.Key.ClassId,
                            IsCertFailedAll = g.All(m => !m.IsCertification)
                        })
                    .GroupBy(d => d.StudetnId)
                    .Select(
                        g =>
                            new
                            {
                                StudentId = g.Key.Value,
                                Count = g.Count(c => c.IsCertFailedAll),
                                Classes = g.Select(a => new {a.ClassId, a.IsCertFailedAll})
                            })
                    .Where(a => a.Count >= CountFailedCertification);

                Debug.WriteLine("Cert failed");
                foreach (var cert in certFailed)
                {
                    Debug.WriteLine(string.Format("{0} {1}",cert.StudentId,cert.Count));
                }

                var rat1 = UnitOfWork.RateRepositary.GetLowRate();
                var rat2 = UnitOfWork.RateRepositary.GetLowRate60();
                var sessionFailed = UnitOfWork.MarkRepository.GetMarkAccordingStudentsAndClasses(listStudet, listClasses)
                    .Where(m => m.Type != MarkType.Certification)
                    .GroupBy(m => new { m.StudentId, m.ClassId })
                    .Select(g =>
                            new
                            {
                                StudentId = g.Key.StudentId,
                                ClassId = g.Key.ClassId,
                                Sum = g.Sum(m => m.MarkRate)
                            })
                            .Where(a => (a.Sum >= rat1.RateMin && a.Sum <= rat1.RateMax) || (a.Sum >= rat2.RateMin && a.Sum <= rat2.RateMax))
                            .GroupBy(a => a.StudentId)
                            .Select(a => new {StudentId = a.Key.Value,Classes = a.Select(g => new {g.ClassId,g.Sum})});

                Debug.WriteLine("Classes failed");
                foreach (var ses in sessionFailed)
                {
                    Debug.WriteLine(string.Format("{0}", ses.StudentId));
                }


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


        #endregion

    }
}