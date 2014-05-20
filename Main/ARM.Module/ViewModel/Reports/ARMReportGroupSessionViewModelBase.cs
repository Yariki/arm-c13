using System.Collections.ObjectModel;
using System.Windows.Controls;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Infrastructure.MVVM;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.Reports
{
    public abstract class ARMReportGroupSessionViewModelBase : ARMReportViewModelBase
    {
        protected ARMReportGroupSessionViewModelBase(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMView view) 
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            Groups = new ObservableCollection<Group>(UnitOfWork.GroupRepository.GetAll());
            Sessions = new ObservableCollection<Session>(UnitOfWork.SessionRepository.GetAll());
            SelectedGroup = null;
            SelectedSession = null;
        }

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

        public ObservableCollection<DataGridColumn> Columns
        {
            get { return Get(() => Columns); }
            set { Set(() => Columns, value); }
        }
    }
}