///////////////////////////////////////////////////////////
//  ARMMainWorkspaceViewModel.cs
//  Implementation of the Class ARMMainWorkspaceViewModel
//  Generated by Enterprise Architect
//  Created on:      02-Apr-2014 1:17:47 AM
///////////////////////////////////////////////////////////

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;
using ARM.Core.Const;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Core.Logging;
using ARM.Core.MVVM;
using ARM.Data.Models;
using ARM.Infrastructure.Events;
using ARM.Infrastructure.Events.EventPayload;
using ARM.Infrastructure.MVVM;
using ARM.Module.Enums;
using ARM.Module.Interfaces;
using ARM.Module.Interfaces.References.ViewModel;
using ARM.Module.Interfaces.View;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Core.Converters;

namespace ARM.Module.ViewModel.Main
{
    public class ARMMainWorkspaceViewModel : ARMViewModelBase, IARMMainWorkspaceViewModel
    {
        private readonly IUnityContainer _unityContainer;
        private readonly IEventAggregator _eventAggregator;

        private IARMWorkspaceViewModel _current;
        private int _currentIndex;

        #region [needs]

        private SubscriptionToken _tokenProcess;
        private SubscriptionToken _tokenClose;

        #endregion


        public ARMMainWorkspaceViewModel(IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMMainWorkspaceView workspaceView)
            : base(workspaceView)
        {
            Items = new ObservableCollection<IARMWorkspaceViewModel>();
            _unityContainer = unityContainer;
            _eventAggregator = eventAggregator;
            Menu = _unityContainer.Resolve<IARMMainMenuViewModel>();
            Toolbox = _unityContainer.Resolve<IARMMainToolboxViewModel>();
            StatusBar = _unityContainer.Resolve<IARMMainStatusBarViewModel>();
            Menu.SetActions(OnMenuExecute, OnMenuCanExecute);
            Menu.InitializeCommands();
            InitEventAggregator();
            ClosingCommand = new DelegateCommand<object>(OnClosingDocument, (o) => true);
        }

        private void InitEventAggregator()
        {
            if (_eventAggregator == null)
                return;
            var addEvent = _eventAggregator.GetEvent<ARMEntityProcessEvent>();
            if (addEvent != null)
            {
                _tokenProcess = addEvent.Subscribe(OnProcessEntity);
            }
            var closeEvent = _eventAggregator.GetEvent<ARMCloseEvent>();
            if (closeEvent != null)
            {
                _tokenClose = closeEvent.Subscribe(OnCloseModel);
            }
        }

        public IARMView MenuView
        {
            get { return Menu.View; }
        }

        public IARMView ToolboxView
        {
            get { return Toolbox.View; }
        }

        public IARMView StatusBarView
        {
            get { return StatusBar.View; }
        }

        public IARMMainMenuViewModel Menu { get; private set; }

        public IARMMainToolboxViewModel Toolbox { get; private set; }

        public IARMMainStatusBarViewModel StatusBar { get; private set; }
        public event EventHandler Close;

        public void OnClosing(CancelEventArgs arg)
        {

        }

        public ICommand ClosingCommand { get; private set; }

        public ObservableCollection<IARMWorkspaceViewModel> Items { get; private set; }

        public int CurrentWorkspaceIndex
        {
            get { return _currentIndex; }
            set
            {
                _currentIndex = value;
                OnPropertyChanged(() => CurrentWorkspaceIndex);
                CurrentWorkspace = Items.ElementAt(_currentIndex);
            }
        }

        public IARMWorkspaceViewModel CurrentWorkspace
        {
            get { return _current; }
            set
            {
                _current = value;
                OnPropertyChanged(() => CurrentWorkspace);
            }
        }

        #region [private]

        #region [menu]

        private void OnMenuExecute(eARMMainMenuCommand cmd)
        {
            IARMWorkspaceViewModel workspaceViewModel = null;
            switch (cmd)
            {
                case eARMMainMenuCommand.Exit:
                    if (Close != null)
                        Close(this, EventArgs.Empty);
                    break;
                case eARMMainMenuCommand.ReferenceUniversity:
                    workspaceViewModel = _unityContainer.Resolve<IARMGridViewModel<University>>();
                    break;
                case eARMMainMenuCommand.ReferenceStaff:
                    workspaceViewModel = _unityContainer.Resolve<IARMGridViewModel<Staff>>();
                    break;
                case eARMMainMenuCommand.ReferenceLanguage:
                    workspaceViewModel = _unityContainer.Resolve<IARMGridViewModel<Language>>();
                    break;
                case eARMMainMenuCommand.ReferenceCountry:
                    workspaceViewModel = _unityContainer.Resolve<IARMGridViewModel<Country>>();
                    break;
                case eARMMainMenuCommand.ReferenceSettings:
                    workspaceViewModel = _unityContainer.Resolve<IARMSettingsValidatableViewModel>();
                    if (workspaceViewModel != null)
                    {
                        (workspaceViewModel as IARMSettingsValidatableViewModel).SetBusinessObject(ViewMode.Edit, eARMMetadata.Settings, GlobalConst.IdDefault, true);
                    }
                    break;
                case eARMMainMenuCommand.ReferenceFaculty:
                    workspaceViewModel = _unityContainer.Resolve<IARMGridViewModel<Faculty>>();
                    break;
                case eARMMainMenuCommand.ReferenceGroup:
                    workspaceViewModel = _unityContainer.Resolve<IARMGridViewModel<Group>>();
                    break;
                case eARMMainMenuCommand.ReferenceSession:
                    workspaceViewModel = _unityContainer.Resolve<IARMGridViewModel<Session>>();
                    break;
                case eARMMainMenuCommand.ReferenceClass:
                    workspaceViewModel = _unityContainer.Resolve<IARMGridViewModel<Class>>();
                    break;
                case eARMMainMenuCommand.ReferenceAddress:
                    workspaceViewModel = _unityContainer.Resolve<IARMGridViewModel<Address>>();
                    break;
            }
            if (workspaceViewModel != null)
            {
                Items.Add(workspaceViewModel);
                CurrentWorkspace = workspaceViewModel;
            }
        }

        private bool OnMenuCanExecute(eARMMainMenuCommand cmd)
        {
            switch (cmd)
            {
                case eARMMainMenuCommand.ReferenceUniversity:
                    return false;
            }
            return true;
        }

        #endregion

        #region [global event ]

        private void OnProcessEntity(ARMProcessEntityEventPayload obj)
        {
            if (obj == null)
                return;
            IARMDataViewModel viewModel = null;
            switch (obj.Metadata)
            {
                case eARMMetadata.University:
                    viewModel = _unityContainer.Resolve<IARMUniversityDataViewModel>();
                    if (viewModel != null)
                    {
                        (viewModel as ARMDataViewModelBase).SetBusinessObject(obj.Mode, eARMMetadata.University, obj.Id);
                    }
                    break;
                case eARMMetadata.Staff:
                    viewModel = _unityContainer.Resolve<IARMStaffValidatableViewModel>();
                    if (viewModel != null)
                    {
                        (viewModel as ARMDataViewModelBase).SetBusinessObject(obj.Mode, eARMMetadata.Staff, obj.Id);
                    }
                    break;
                case eARMMetadata.Language:
                    viewModel = _unityContainer.Resolve<IARMLanguageValidatableViewModel>();
                    if (viewModel != null)
                    {
                        (viewModel as ARMDataViewModelBase).SetBusinessObject(obj.Mode, eARMMetadata.Language, obj.Id);
                    }
                    break;
                case eARMMetadata.Country:
                    viewModel = _unityContainer.Resolve<IARMCountryValidatableViewModel>();
                    if (viewModel != null)
                    {
                        (viewModel as ARMDataViewModelBase).SetBusinessObject(obj.Mode, eARMMetadata.Country, obj.Id);
                    }
                    break;
                case eARMMetadata.Faculty:
                    viewModel = _unityContainer.Resolve<IARMFacultyValidatableViewModel>();
                    if (viewModel != null)
                    {
                        (viewModel as ARMDataViewModelBase).SetBusinessObject(obj.Mode, eARMMetadata.Faculty, obj.Id);
                    }
                    break;
                case eARMMetadata.Group:
                    viewModel = _unityContainer.Resolve<IARMGroupValidatableViewModel>();
                    if (viewModel != null)
                    {
                        (viewModel as ARMDataViewModelBase).SetBusinessObject(obj.Mode, eARMMetadata.Group, obj.Id);
                    }
                    break;
                case eARMMetadata.Session:
                    viewModel = _unityContainer.Resolve<IARMSessionValidatableViewModel>();
                    if (viewModel != null)
                    {
                        (viewModel as ARMDataViewModelBase).SetBusinessObject(obj.Mode, eARMMetadata.Session, obj.Id);
                    }
                    break;
                case eARMMetadata.Class:
                    viewModel = _unityContainer.Resolve<IARMClassValidatableViewModel>();
                    if (viewModel != null)
                    {
                        (viewModel as ARMDataViewModelBase).SetBusinessObject(obj.Mode, eARMMetadata.Class, obj.Id);
                    }
                    break;
                case eARMMetadata.Address:
                    viewModel = _unityContainer.Resolve<IARMAddressValidatableViewModel>();
                    if (viewModel != null)
                    {
                        (viewModel as ARMDataViewModelBase).SetBusinessObject(obj.Mode, eARMMetadata.Address, obj.Id);
                    }
                    break;
            }
            if (viewModel != null)
            {
                Items.Add(viewModel);
                CurrentWorkspace = viewModel;
                _currentIndex = Items.IndexOf(CurrentWorkspace);
                OnPropertyChanged(() => CurrentWorkspaceIndex);
            }
        }

        private void OnCloseModel(ARMCloseEventPayload obj)
        {
            if (obj == null || obj.Model == null)
                return;
            Items.Remove(obj.Model);
            obj.Model.Dispose();
        }

        #endregion

        private void OnClosingDocument(object obj)
        {
            DocumentClosingEventArgs arg = obj as DocumentClosingEventArgs;
            if (arg == null || !(CurrentWorkspace is IARMDataViewModel))
                return;
            arg.Cancel = (CurrentWorkspace as IARMDataViewModel).Closing();
        }

        #endregion



    } //end ARMMainWorkspaceViewModel
} //end namespace Main