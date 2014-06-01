using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Input;
using ARM.Core.Enums;
using ARM.Core.Extensions;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Data.UnitOfWork.Implementation;
using ARM.Infrastructure.Controls.ARMDialogWindow;
using ARM.Infrastructure.Controls.ARMLookupWindow;
using ARM.Infrastructure.Controls.Interfaces;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.Helpers;
using ARM.Infrastructure.MVVM;
using ARM.Module.Commands.Menu.Reference;
using ARM.Module.Interfaces.References.View;
using ARM.Module.Interfaces.References.ViewModel;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using NSubstitute.Core;

namespace ARM.Module.ViewModel.References
{
    /// <summary>
    /// Клас для роботи з моделю даних -  студент.
    /// </summary>
    public class ARMStudentValidatableViewModel : ARMValidatableViewModelBase, IARMStudentValidatableViewModel
    {
        #region [needs]

        private IUnitOfWork _unitOfWork;

        #endregion


        /// <summary>
        /// Створити екземпляр <see cref="ARMStudentValidatableViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public ARMStudentValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMStudentView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            _unitOfWork = UnityContainer.Resolve<IUnitOfWork>();

            AddAchivementCommand = new ARMRelayCommand(AddAchivementExecute);
            DeleteAchivementCommand = new ARMRelayCommand(DeleteAchivementExecute);

            AddHobbyCommand = new ARMRelayCommand(AddHobbyExecute);
            DeleteHobbyCommand = new ARMRelayCommand(DeleteHobbyExecute);

            AddParentCommand = new ARMRelayCommand(AddParentExecute);
            DeleteParentCommand = new ARMRelayCommand(DeleteParentExecute);

            AddLanguageCommand = new ARMRelayCommand(AddLanguageExecute);
            DeleteLanguageCommand = new ARMRelayCommand(DeleteLanguageExecute);

            AddVisaCommand = new ARMRelayCommand(AddVisaExecute);
            DeleteVisaCommand = new ARMRelayCommand(DeleteVisaExecute);


            AchivementsList = new ObservableCollection<Achivement>();
            HobbiesList = new ObservableCollection<Hobby>();
            ParentsList = new ObservableCollection<Parent>();
            LanguagesList = new ObservableCollection<Language>();
            VisaList = new ObservableCollection<Visa>();
        }

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
        public override string Title
        {
            get { return FormatTitle(Resource.AppResource.Resources.Model_Data_Student); }
        }

        #region [properties]

        public IUnityContainer DiContainer
        {
            get { return UnityContainer; }
        }

        public string FirstName
        {
            get { return Get(() => FirstName); }
            set { Set(() => FirstName, value); }
        }

        public string MiddleName
        {
            get { return Get(() => MiddleName); }
            set { Set(() => MiddleName, value); }
        }

        public string LastName
        {
            get { return Get(() => LastName); }
            set { Set(() => LastName, value); }
        }

        public string Email
        {
            get { return Get(() => Email); }
            set { Set(() => Email, value); }
        }

        public string PhoneMobile
        {
            get { return Get(() => PhoneMobile); }
            set { Set(() => PhoneMobile, value); }
        }

        public string PhoneHome
        {
            get { return Get(() => PhoneHome); }
            set { Set(() => PhoneHome, value); }
        }

        public SexType Sex
        {
            get { return Get(() => Sex); }
            set { Set(() => Sex, value); }
        }

        public Guid AddressId
        {
            get { return Get(() => AddressId); }
            set { Set(() => AddressId, value); }
        }

        public Guid LivingAddressId
        {
            get { return Get(() => LivingAddressId); }
            set { Set(() => LivingAddressId, value); }
        }

        public ObservableCollection<Parent> ParentsList
        {
            get { return Get(() => ParentsList); }
            set { Set(() => ParentsList, value); }
        }

        public Guid? GroupId
        {
            get { return Get(() => GroupId); }
            set { Set(() => GroupId, value); }
        }

        public ObservableCollection<Hobby> HobbiesList
        {
            get { return Get(() => HobbiesList); }
            set { Set(() => HobbiesList, value); }
        }

        public ObservableCollection<Achivement> AchivementsList
        {
            get { return Get(() => AchivementsList); }
            set { Set(() => AchivementsList, value); }
        }

        public DateTime DateFirstEnter
        {
            get { return Get(() => DateFirstEnter); }
            set { Set(() => DateFirstEnter, value); }
        }

        public DateTime? DateLeft
        {
            get { return Get(() => DateLeft); }
            set { Set(() => DateLeft, value); }
        }

        public ObservableCollection<Language> LanguagesList
        {
            get { return Get(() => LanguagesList); }
            set { Set(() => LanguagesList, value); }
        }

        public Guid? FacultyId
        {
            get { return Get(() => FacultyId); }
            set { Set(() => FacultyId, value); }
        }

        public StudyMode StudyMode
        {
            get { return Get(() => StudyMode); }
            set { Set(() => StudyMode, value); }
        }

        public string GradeBookNumber
        {
            get { return Get(() => GradeBookNumber); }
            set { Set(() => GradeBookNumber, value); }
        }

        public bool IsForeign
        {
            get { return Get(() => IsForeign); }
            set { Set(() => IsForeign, value); OnPropertyChanged(() => IsForeignStudent); }
        }

        public Guid? SpecialityId
        {
            get { return Get(() => SpecialityId); }
            set { Set(() => SpecialityId, value); }
        }

        public StudentStatus Status
        {
            get { return Get(() => Status); }
            set { Set(() => Status, value); }
        }

        public Guid? EmployerId
        {
            get { return Get(() => EmployerId); }
            set { Set(() => EmployerId, value); }
        }

        public eARMStudyType StudyType
        {
            get { return Get(() => StudyType); }
            set { Set(() => StudyType, value); }
        }

        public ObservableCollection<Visa> VisaList
        {
            get { return Get(() => VisaList); }
            set { Set(() => VisaList, value); }
        }

        public Visibility IsForeignStudent 
        {
            get { return (Mode == ViewMode.Edit && IsForeign).ToVisibility(); }
        }

        public decimal Stipend
        {
            get { return Get(() => Stipend); }
            set { Set(() => Stipend, value); }
        }

        public string Note
        {
            get { return Get(() => Note); }
            set { Set(() => Note, value); }
        }


        #endregion

        #region [enum source]

        private Dictionary<SexType, string> _sourceSex;
        /// <summary>
        /// Отримує або задає список значень типу статі.
        /// </summary>
        public Dictionary<SexType, string> SourceSex
        {
            get { return _sourceSex ?? (_sourceSex = ARMEnumHelper.Instance.GetLocalsForEnum<SexType>()); }
        }

        private Dictionary<StudyMode, string> _sourceStudyMode;
        /// <summary>
        /// Отримує або задає список значень типу методу навчання.
        /// </summary>
        public Dictionary<StudyMode, string> SourceStudyMode
        {
            get { return _sourceStudyMode ?? (_sourceStudyMode = ARMEnumHelper.Instance.GetLocalsForEnum<StudyMode>()); }
        }

        private Dictionary<StudentStatus, string> _sourceStudentStatus;
        /// <summary>
        /// Отримує або задає список значень типу статуса студента.
        /// </summary>
        public Dictionary<StudentStatus, string> SourceStudentStatus
        {
            get { return _sourceStudentStatus ?? (_sourceStudentStatus = ARMEnumHelper.Instance.GetLocalsForEnum<StudentStatus>()); }
        }

        private Dictionary<eARMStudyType, string> _sourceStudyType;
        /// <summary>
        /// Отримує або задає список значень типу типу навчання.
        /// </summary>
        public Dictionary<eARMStudyType, string> SourceStudyType
        {
            get { return _sourceStudyType ?? (_sourceStudyType = ARMEnumHelper.Instance.GetLocalsForEnum<eARMStudyType>()); }
        }

        #endregion

        #region [override]

        /// <summary>
        /// встановлення режиму роботи та моделі даних (у відповідності до метаданих та ідентифікатора)
        /// </summary>
        /// <param name="mode">Режим роботи.</param>
        /// <param name="metadata">Метадата.</param>
        /// <param name="id">Ідентифікатор.</param>
        /// <param name="isIdEmpty">Флаг, чи може фдентифікатор бути пустим.</param>
        public override void SetBusinessObject(ViewMode mode, eARMMetadata metadata, Guid id, bool isIdEmpty = false)
        {
            base.SetBusinessObject(mode, metadata, id, isIdEmpty);
            var entity = GetBusinessObject<Student>();
            if (_unitOfWork == null || entity == null)
                return;
            switch (Mode)
            {
                case ViewMode.Add:
                    entity.DateFirstEnter = DateTime.Now;
                    break;
            }
            if (entity.Achivements != null && entity.Achivements.Count > 0)
            {
                AchivementsList.AddRange(entity.Achivements);
            }
            if (entity.Hobbies != null && entity.Hobbies.Count > 0)
            {
                HobbiesList.AddRange(entity.Hobbies);
            }
            if (entity.Parents != null && entity.Parents.Count > 0)
            {
                ParentsList.AddRange(entity.Parents);
            }
            if (entity.Languages != null && entity.Languages.Count > 0)
            {
                LanguagesList.AddRange(entity.Languages);
            }
            if (entity.Visas != null && entity.Visas.Count > 0)
            {
                VisaList.AddRange(entity.Visas);
            }
        }

        /// <summary>
        /// Звільняє некеровані і - можливо - керовані ресурси.
        /// </summary>
        /// <param name="disposing"><c>true</c> щоб звільнити керовані і некеровані ресурси; <c>false</c> щоб звільнити тільки некеровані ресурси.</param>
        protected override void Dispose(bool disposing)
        {
            if (!Disposed && disposing)
            {
                if (_unitOfWork != null)
                {
                    _unitOfWork.Dispose();
                    _unitOfWork = null;
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Виклик зберігання обєкту.
        /// </summary>
        /// <param name="arg">Аргумент.</param>
        protected override void SaveExecute(object arg)
        {
            if (!ValidateBeforeSave())
                return;

            try
            {
                switch (Mode)
                {
                    case ViewMode.Add:
                        _unitOfWork.StudentRepository.Insert(GetBusinessObject<Student>());
                        break;
                    case ViewMode.Edit:
                        var entity = GetBusinessObject<Student>();
                        entity.Languages.Clear();
                        this.LanguagesList.ForEach( l => entity.Languages.Add(l));
                        _unitOfWork.StudentRepository.Update(entity);
                        break;
                }
                _unitOfWork.StudentRepository.Save();
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }
            finally
            {

            }

            base.SaveExecute(arg);
        }

        #endregion


        /// <summary>
        /// Керує видимістю додаткових вкладок для роботи з моделю студента.
        /// </summary>
        public Visibility VisibilityAdditional
        {
            get { return Mode == ViewMode.Add ? Visibility.Collapsed : Visibility.Visible; }
        }

        #region [Achivement]

        /// <summary>
        /// Отримує або задає обране досягнення.
        /// </summary>
        public Achivement SelectedAchivement
        {
            get { return Get(() => SelectedAchivement); }
            set { Set(() => SelectedAchivement, value); }
        }

        /// <summary>
        /// Команда для додавання досягнення.
        /// </summary>
        public ICommand AddAchivementCommand { get; private set; }

        /// <summary>
        /// Команда для видалення досягнення.
        /// </summary>
        public ICommand DeleteAchivementCommand { get; private set; }


        /// <summary>
        /// Додає нове досягення.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        private void AddAchivementExecute(object arg)
        {
            try
            {
                IARMAchivementValidatableViewModel model = UnityContainer.Resolve<IARMAchivementValidatableViewModel>();
                if (model == null)
                {
                    return;
                }
                model.SetBusinessObject(ViewMode.Add, eARMMetadata.Achivement, Guid.Empty, false);
                ARMDialogWindow dlgWnd = new ARMDialogWindow(model) { Width = 350, Height = 450 };
                var result = dlgWnd.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    try
                    {
                        var entity = model.GetBusinessObject<Achivement>();
                        entity.Id = Guid.NewGuid();
                        entity.StudentId = GetBusinessObject<Student>().Id;
                        _unitOfWork.AchivementRepository.Insert(entity);
                        _unitOfWork.AchivementRepository.Save();
                        AchivementsList.Add(entity);
                        OnPropertyChanged(() => AchivementsList);
                    }
                    catch (Exception ex)
                    {
                        ARMSystemFacade.Instance.Logger.LogError(ex.Message);
                    }
                    finally
                    {
                        model.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }
        }

        /// <summary>
        /// Видаляє досягення.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        private void DeleteAchivementExecute(object arg)
        {
            if (SelectedAchivement == null)
                return;
            try
            {
                _unitOfWork.AchivementRepository.Delete(SelectedAchivement);
                _unitOfWork.AchivementRepository.Save();
                AchivementsList.Remove(SelectedAchivement);
                OnPropertyChanged(() => AchivementsList);
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }
        }

        #endregion

        #region [Hobby]

        /// <summary>
        /// Отримує або задає обране хобі.
        /// </summary>
        public Hobby SelectedHobby
        {
            get { return Get(() => SelectedHobby); }
            set { Set(() => SelectedHobby, value); }
        }

        /// <summary>
        /// Команда для додавання хобі.
        /// </summary>
        public ICommand AddHobbyCommand { get; private set; }

        /// <summary>
        /// Команда для видалення хобі.
        /// </summary>
        public ICommand DeleteHobbyCommand { get; private set; }


        /// <summary>
        /// Додає хобі.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        private void AddHobbyExecute(object arg)
        {
            try
            {
                IARMHobbyValidatableViewModel model = UnityContainer.Resolve<IARMHobbyValidatableViewModel>();
                if (model == null)
                {
                    return;
                }
                model.SetBusinessObject(ViewMode.Add, eARMMetadata.Hobby, Guid.Empty, false);
                ARMDialogWindow dlgWnd = new ARMDialogWindow(model) { Width = 350, Height = 450 };
                var result = dlgWnd.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    try
                    {
                        var entity = model.GetBusinessObject<Hobby>();
                        entity.Id = Guid.NewGuid();
                        entity.StudentId = GetBusinessObject<Student>().Id;
                        _unitOfWork.HobbyRepository.Insert(entity);
                        _unitOfWork.HobbyRepository.Save();
                        HobbiesList.Add(entity);
                        OnPropertyChanged(() => HobbiesList);
                    }
                    catch (Exception ex)
                    {
                        ARMSystemFacade.Instance.Logger.LogError(ex.Message);
                    }
                    finally
                    {
                        model.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }
        }

        /// <summary>
        /// Видаляє хобі.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        private void DeleteHobbyExecute(object arg)
        {
            if (SelectedHobby == null)
                return;
            try
            {
                _unitOfWork.HobbyRepository.Delete(SelectedHobby);
                _unitOfWork.HobbyRepository.Save();
                HobbiesList.Remove(SelectedHobby);
                OnPropertyChanged(() => HobbiesList);
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }
        }

        #endregion

        #region [Parents]

        /// <summary>
        /// Отримує або задає обраного з батьків (:D).
        /// </summary>
        public Parent SelectedParent
        {
            get { return Get(() => SelectedParent); }
            set { Set(() => SelectedParent, value); }
        }

        /// <summary>
        /// Команда для додавання одного з батьків.
        /// </summary>
        public ICommand AddParentCommand { get; private set; }
        /// <summary>
        /// Команда для видалення одного з батьків.
        /// </summary>
        public ICommand DeleteParentCommand { get; private set; }

        /// <summary>
        /// Додавання одного з батьків.
        /// </summary>
        /// <param name="obj">Аргументи для додавання.</param>
        private void AddParentExecute(object obj)
        {
            IARMLookupViewModel viewModel = new ARMLookupViewModel(UnityContainer, EventAggregator, new ARMLookupView());
            viewModel.Initialize(eARMMetadata.Parent);
            ARMLookupWindow wnd = new ARMLookupWindow(viewModel);
            var result = wnd.ShowDialog();
            if (result.HasValue && result.Value && viewModel.SelectedItem != null)
            {
                try
                {
                    var parent = viewModel.SelectedItem as Parent;
                    parent.StudentId = GetBusinessObject<Student>().Id;
                    _unitOfWork.ParentRepository.Update(parent);
                    _unitOfWork.ParentRepository.Save();
                    ParentsList.Add(parent);
                    OnPropertyChanged(() => ParentsList);
                }
                catch (Exception ex)
                {
                    ARMSystemFacade.Instance.Logger.LogError(ex.Message);
                }
            }
        }

        /// <summary>
        /// Видалення одного з батьків.
        /// </summary>
        /// <param name="obj">Аргументи для видалення.</param>
        private void DeleteParentExecute(object obj)
        {
            if (SelectedParent == null)
                return;
            try
            {
                SelectedParent.StudentId = null;
                _unitOfWork.ParentRepository.Update(SelectedParent);
                _unitOfWork.ParentRepository.Save();
                ParentsList.Remove(SelectedParent);
                OnPropertyChanged(() => ParentsList);
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }
        }

        #endregion

        #region [languages]

        /// <summary>
        /// Отримує або задає обрану мову.
        /// </summary>
        public Language SelectedLanguage
        {
            get
            {
                return Get(() => SelectedLanguage);
            }
            set
            {
                Set(() => SelectedLanguage, value);
            }
        }

        /// <summary>
        /// Команда для додавання мови.
        /// </summary>
        public ICommand AddLanguageCommand { get; private set; }
        /// <summary>
        /// Команда для видалення мови.
        /// </summary>
        public ICommand DeleteLanguageCommand { get; private set; }

        /// <summary>
        /// Додє мову до списку.
        /// </summary>
        /// <param name="arg">The argument.</param>
        private void AddLanguageExecute(object arg)
        {
            IARMLookupViewModel viewModel = new ARMLookupViewModel(UnityContainer, EventAggregator, new ARMLookupView());
            viewModel.Initialize(eARMMetadata.Language);
            ARMLookupWindow wnd = new ARMLookupWindow(viewModel);
            var result = wnd.ShowDialog();
            if (result.HasValue && result.Value)
            {
                var language = viewModel.SelectedItem as Language;
                this.LanguagesList.Add(language);
                OnPropertyChanged(() => LanguagesList);
            }
        }

        /// <summary>
        /// Видалає мову зі списку.
        /// </summary>
        /// <param name="arg">The argument.</param>
        private void DeleteLanguageExecute(object arg)
        {
            if (SelectedLanguage == null)
                return;
            LanguagesList.Remove(SelectedLanguage);
            OnPropertyChanged(() => LanguagesList);
        }

        #endregion

        #region [visa]

        /// <summary>
        /// Отримує або задає обрану візу.
        /// </summary>
        public Visa SelectedVisa 
        {
            get { return Get(() => SelectedVisa); }
            set {Set(() => SelectedVisa,value); }
        }

        /// <summary>
        /// Команда для додавання візи.
        /// </summary>
        public ICommand AddVisaCommand { get; private set; }
        /// <summary>
        /// Команда видалення візи.
        /// </summary>
        public ICommand DeleteVisaCommand { get; private set; }

        /// <summary>
        /// Додавання візи.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        private void AddVisaExecute(object arg)
        {
            IARMVisaValidatableViewModel viewModel = UnityContainer.Resolve<IARMVisaValidatableViewModel>();
            try
            {
                if (viewModel == null)
                    return;
                viewModel.SetBusinessObject(ViewMode.Add, eARMMetadata.Visa, Guid.Empty, false);
                ARMDialogWindow dlgWnd = new ARMDialogWindow(viewModel) {Width = 350, Height = 450};
                var result = dlgWnd.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    var entity = viewModel.GetBusinessObject<Visa>();
                    entity.Id = Guid.NewGuid();
                    entity.StudentId = GetBusinessObject<Student>().Id;
                    UnitOfWork.VisaRepository.Insert(entity);
                    UnitOfWork.VisaRepository.Save();
                    VisaList.Add(entity);
                    OnPropertyChanged(() => VisaList);
                }
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }
            finally
            {
                if(viewModel != null)
                    viewModel.Dispose();
            }
        }


        /// <summary>
        /// Видалення мови.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        private void DeleteVisaExecute(object arg)
        {
            if (SelectedVisa == null)
                return;
            try
            {
                UnitOfWork.VisaRepository.Delete(SelectedVisa);
                UnitOfWork.VisaRepository.Save();
                VisaList.Remove(SelectedVisa);
                OnPropertyChanged(() => VisaList);
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }
        }

        #endregion

        #region [private]

        #endregion

    }
}