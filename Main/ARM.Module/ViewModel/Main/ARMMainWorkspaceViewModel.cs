﻿///////////////////////////////////////////////////////////
//  ARMMainWorkspaceViewModel.cs
//  Implementation of the Class ARMMainWorkspaceViewModel
//  Generated by Enterprise Architect
//  Created on:      02-Apr-2014 1:17:47 AM
///////////////////////////////////////////////////////////

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using ARM.Core.Const;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Core.MVVM;
using ARM.Data.Models;
using ARM.Infrastructure.Events;
using ARM.Infrastructure.Events.EventPayload;
using ARM.Infrastructure.MVVM;
using ARM.Module.Enums;
using ARM.Module.Interfaces;
using ARM.Module.Interfaces.Documents.ViewModel;
using ARM.Module.Interfaces.References.ViewModel;
using ARM.Module.Interfaces.Reports.ViewModel;
using ARM.Module.Interfaces.Services.CalculationStipend.ViewModel;
using ARM.Module.Interfaces.Services.Evaluation.ViewModel;
using ARM.Module.Interfaces.View;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using Xceed.Wpf.AvalonDock;

namespace ARM.Module.ViewModel.Main
{
    /// <summary>
    /// Класс, що представляє модель головного робочого простору.
    /// Відповідає за прийнятя всіх команд від меню, панелі інтрументів. Створює всі дочірні моделі.
    /// </summary>
    public class ARMMainWorkspaceViewModel : ARMViewModelBase, IARMMainWorkspaceViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IUnityContainer _unityContainer;

        private IARMWorkspaceViewModel _current;
        private int _currentIndex;

        #region [needs]

        private SubscriptionToken _tokenClose;
        private SubscriptionToken _tokenProcess;

        #endregion [needs]

        /// <summary>
        /// Створити екземпляр <see cref="ARMMainWorkspaceViewModel" /> class.
        /// </summary>
        /// <param name="unityContainer">Контейнер.</param>
        /// <param name="eventAggregator">Агрегатор подій.</param>
        /// <param name="workspaceView">Представлення.</param>
        public ARMMainWorkspaceViewModel(IUnityContainer unityContainer, IEventAggregator eventAggregator,
            IARMMainWorkspaceView workspaceView)
            : base(workspaceView)
        {
            Items = new ObservableCollection<IARMWorkspaceViewModel>();
            _unityContainer = unityContainer;
            _eventAggregator = eventAggregator;
            Menu = _unityContainer.Resolve<IARMMainMenuViewModel>();
            Toolbox = _unityContainer.Resolve<IARMMainToolboxViewModel>();
            StatusBar = _unityContainer.Resolve<IARMMainStatusBarViewModel>();
            Toolbox.SetActions(OnMenuExecute,OnMenuCanExecute);
            Menu.SetActions(OnMenuExecute, OnMenuCanExecute);
            Menu.InitializeCommands();
            Toolbox.InitializeCommands();
            InitEventAggregator();
            ClosingCommand = new DelegateCommand<object>(OnClosingDocument, o => true);
        }

        #region IARMMainWorkspaceViewModel Members

        /// <summary>
        /// Отримує головний інтерфейс користувача.
        /// </summary>
        public IARMView MenuView
        {
            get { return Menu.View; }
        }

        /// <summary>
        /// Отримує інтерфейс користувача для панелі управління.
        /// </summary>
        public IARMView ToolboxView
        {
            get { return Toolbox.View; }
        }

        /// <summary>
        /// Отримує інтерфейс користувача для панелі статуса.
        /// </summary>
        public IARMView StatusBarView
        {
            get { return StatusBar.View; }
        }

        /// <summary>
        /// Отримує модель представлення для головного меню.
        /// </summary>
        public IARMMainMenuViewModel Menu { get; private set; }

        /// <summary>
        /// Отримує модель представлення для панелі управління.
        /// </summary>
        public IARMMainToolboxViewModel Toolbox { get; private set; }

        /// <summary>
        /// Отримує модель представлення для панелі статуса.
        /// </summary>
        public IARMMainStatusBarViewModel StatusBar { get; private set; }

        /// <summary>
        /// Подія, яка відбувається при закритті моделі.
        /// </summary>
        public event EventHandler Close;

        /// <summary>
        /// Метод відбувається безпосередньо перед закритям, для допоміжної логіки.
        /// Наприклад, можливо відмінити закриття програми.
        /// </summary>
        /// <param name="arg"></param>
        public void OnClosing(CancelEventArgs arg)
        {
        }

        /// <summary>
        /// Команда закриття.
        /// </summary>
        public ICommand ClosingCommand { get; private set; }

        /// <summary>
        /// Отримує всі моделі з фким працює користувая в даний момент.
        /// </summary>
        public ObservableCollection<IARMWorkspaceViewModel> Items { get; private set; }

        /// <summary>
        /// Отримує або задає індекс поточної моделі представлення.
        /// </summary>
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

        /// <summary>
        /// Отриує та задає поточну модель представлення я кою працює користувач.
        /// </summary>
        public IARMWorkspaceViewModel CurrentWorkspace
        {
            get { return _current; }
            set
            {
                _current = value;
                OnPropertyChanged(() => CurrentWorkspace);
            }
        }

        #endregion IARMMainWorkspaceViewModel Members

        #region [private]

        #region [menu]

        /// <summary>
        /// Викликається на дію з головного меню.
        /// </summary>
        /// <param name="cmd">Тип команди.</param>
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
                        (workspaceViewModel as IARMSettingsValidatableViewModel).SetBusinessObject(ViewMode.Edit,
                            eARMMetadata.Settings, GlobalConst.IdDefault, true);
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

                case eARMMainMenuCommand.ReferenceParent:
                    workspaceViewModel = _unityContainer.Resolve<IARMGridViewModel<Parent>>();
                    break;

                case eARMMainMenuCommand.ReferenceSpeciality:
                    workspaceViewModel = _unityContainer.Resolve<IARMGridViewModel<Specialty>>();
                    break;

                case eARMMainMenuCommand.ReferenceUser:
                    workspaceViewModel = _unityContainer.Resolve<IARMGridViewModel<User>>();
                    break;

                case eARMMainMenuCommand.ReferenceStudent:
                    workspaceViewModel = _unityContainer.Resolve<IARMGridViewModel<Student>>();
                    break;
                case eARMMainMenuCommand.DocumentContract:
                    workspaceViewModel = _unityContainer.Resolve<IARMGridViewModel<Contract>>();
                    break;
                case eARMMainMenuCommand.DocumentInvoice:
                    workspaceViewModel = _unityContainer.Resolve<IARMGridViewModel<Invoice>>();
                    break;
                case eARMMainMenuCommand.DocumentPayment:
                    workspaceViewModel = _unityContainer.Resolve<IARMGridViewModel<Payment>>();
                    break;
                case eARMMainMenuCommand.ReferenceEmployer:
                    workspaceViewModel = _unityContainer.Resolve<IARMGridViewModel<Employer>>();
                    break;
                case eARMMainMenuCommand.ServiceEvaluation:
                    workspaceViewModel = _unityContainer.Resolve<IARMEvaluationViewModel>();
                    break;
                case eARMMainMenuCommand.ReportContractGroup:
                    workspaceViewModel = _unityContainer.Resolve<IARMContractGroupViewModel>();
                    break;
                case eARMMainMenuCommand.ReportCertification:
                    workspaceViewModel = _unityContainer.Resolve<IARMCertificationViewModel>();
                    break;
                case eARMMainMenuCommand.ServiceCalculationStipend:
                    workspaceViewModel = _unityContainer.Resolve<IARMCalculationStipendViewModel>();
                    break;
                case eARMMainMenuCommand.ReportSessionMarks:
                    workspaceViewModel = _unityContainer.Resolve<IARMSessionMarksViewModel>();
                    break;
                case eARMMainMenuCommand.ReportDebt:
                    workspaceViewModel = _unityContainer.Resolve<IARMDebtViewModel>();
                    break;
                case eARMMainMenuCommand.ReportForeignStudent:
                    workspaceViewModel = _unityContainer.Resolve<IARMForeignStudentViewModel>();
                    break;
                case eARMMainMenuCommand.ReportAcademicArrears:
                    workspaceViewModel = _unityContainer.Resolve<IARMAcademicArrearsViewModel>();
                    break;


            }
            if (workspaceViewModel != null)
            {
                workspaceViewModel.Initialize();
                Items.Add(workspaceViewModel);
                CurrentWorkspace = workspaceViewModel;
            }
        }

        /// <summary>
        /// Визначає чи доступний пункт меню.
        /// </summary>
        /// <param name="cmd">Тип команди.</param>
        /// <returns></returns>
        private bool OnMenuCanExecute(eARMMainMenuCommand cmd)
        {
            switch (cmd)
            {
                case eARMMainMenuCommand.ReferenceUniversity:
                    return false;
            }
            return true;
        }

        #endregion [menu]

        #region [global event ]

        /// <summary>
        /// Викликається для створення моделі по роботі з певним обєктом.
        /// Дана команда приходить з моделі сітки, де користувач має можливість натисинути кнопки: Додати, Редагувати, Видалити.
        /// </summary>
        /// <param name="obj">Аргументи.</param>
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

                case eARMMetadata.Parent:
                    viewModel = _unityContainer.Resolve<IARMParentValidatableViewModel>();
                    if (viewModel != null)
                    {
                        (viewModel as ARMDataViewModelBase).SetBusinessObject(obj.Mode, eARMMetadata.Parent, obj.Id);
                    }
                    break;

                case eARMMetadata.Specialty:
                    viewModel = _unityContainer.Resolve<IARMSpecialityValidatableViewModel>();
                    if (viewModel != null)
                    {
                        (viewModel as ARMDataViewModelBase).SetBusinessObject(obj.Mode, eARMMetadata.Specialty, obj.Id);
                    }
                    break;

                case eARMMetadata.User:
                    viewModel = _unityContainer.Resolve<IARMUserValidatableViewModel>();
                    if (viewModel != null)
                    {
                        (viewModel as ARMDataViewModelBase).SetBusinessObject(obj.Mode, eARMMetadata.User, obj.Id);
                    }
                    break;
                case eARMMetadata.Student:
                    viewModel = _unityContainer.Resolve<IARMStudentValidatableViewModel>();
                    if (viewModel != null)
                    {
                        (viewModel as ARMDataViewModelBase).SetBusinessObject(obj.Mode, eARMMetadata.Student, obj.Id);
                    }
                    break;
                case eARMMetadata.Contract:
                    viewModel = _unityContainer.Resolve<IARMContractValidatableViewModel>();
                    if (viewModel != null)
                    {
                        (viewModel as ARMDataViewModelBase).SetBusinessObject(obj.Mode, eARMMetadata.Contract, obj.Id);
                    }
                    break;
                case eARMMetadata.Invoice:
                    viewModel = _unityContainer.Resolve<IARMInvoiceValidatableViewModel>();
                    if (viewModel != null)
                    {
                        (viewModel as ARMDataViewModelBase).SetBusinessObject(obj.Mode, eARMMetadata.Invoice, obj.Id);
                    }
                    break;
                case eARMMetadata.Payment:
                    viewModel = _unityContainer.Resolve<IARMPaymentValidatableViewModel>();
                    if (viewModel != null)
                    {
                        (viewModel as ARMDataViewModelBase).SetBusinessObject(obj.Mode, eARMMetadata.Payment, obj.Id);
                    }
                    break;
                case eARMMetadata.Employer:
                    viewModel = _unityContainer.Resolve<IARMEmployerValidatableViewModel>();
                    if (viewModel != null)
                    {
                        (viewModel as ARMDataViewModelBase).SetBusinessObject(obj.Mode, eARMMetadata.Employer, obj.Id);
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

        /// <summary>
        /// Викликається при закриті моделі.
        /// </summary>
        /// <param name="obj">Аргументи.</param>
        private void OnCloseModel(ARMCloseEventPayload obj)
        {
            if (obj == null || obj.Model == null)
                return;
            Items.Remove(obj.Model);
            obj.Model.Dispose();
        }

        #endregion [global event ]

        /// <summary>
        /// Викликається при закритті вкладки.
        /// </summary>
        /// <param name="obj">Аргументи.</param>
        private void OnClosingDocument(object obj)
        {
            var arg = obj as DocumentClosingEventArgs;
            if (arg == null || !(CurrentWorkspace is IARMDataViewModel))
                return;
            arg.Cancel = (CurrentWorkspace as IARMDataViewModel).Closing();
        }

        #endregion [private]

        /// <summary>
        /// Підписується на події в агрегаторі подій.
        /// </summary>
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
    } //end ARMMainWorkspaceViewModel
} //end namespace Main