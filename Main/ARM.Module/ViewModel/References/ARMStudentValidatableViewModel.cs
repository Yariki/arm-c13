using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Input;
using ARM.Core.Enums;
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
    public class ARMStudentValidatableViewModel : ARMValidatableViewModelBase, IARMStudentValidatableViewModel
    {
        #region [needs]

        private IUnitOfWork _unitOfWork;

        #endregion


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

            AchivementsList = new ObservableCollection<Achivement>();
            HobbiesList = new ObservableCollection<Hobby>();
            ParentsList = new ObservableCollection<Parent>();
            LanguagesList = new ObservableCollection<Language>();
        }

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
            set { Set(() => IsForeign, value); }
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

        #endregion

        #region [enum source]

        private Dictionary<SexType, string> _sourceSex;
        public Dictionary<SexType, string> SourceSex
        {
            get { return _sourceSex ?? (_sourceSex = EnumHelper.Instance.GetLocalsForEnum<SexType>()); }
        }

        private Dictionary<StudyMode, string> _sourceStudyMode;
        public Dictionary<StudyMode, string> SourceStudyMode
        {
            get { return _sourceStudyMode ?? (_sourceStudyMode = EnumHelper.Instance.GetLocalsForEnum<StudyMode>()); }
        }

        private Dictionary<StudentStatus, string> _sourceStudentStatus;
        public Dictionary<StudentStatus, string> SourceStudentStatus
        {
            get { return _sourceStudentStatus ?? (_sourceStudentStatus = EnumHelper.Instance.GetLocalsForEnum<StudentStatus>()); }
        }

        #endregion

        #region [override]

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
        }

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


        public Visibility VisibilityAdditional
        {
            get { return Mode == ViewMode.Add ? Visibility.Collapsed : Visibility.Visible; }
        }

        #region [Achivement]

        public Achivement SelectedAchivement
        {
            get { return Get(() => SelectedAchivement); }
            set { Set(() => SelectedAchivement, value); }
        }

        public ICommand AddAchivementCommand { get; private set; }

        public ICommand DeleteAchivementCommand { get; private set; }


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

        public Hobby SelectedHobby
        {
            get { return Get(() => SelectedHobby); }
            set { Set(() => SelectedHobby, value); }
        }

        public ICommand AddHobbyCommand { get; private set; }

        public ICommand DeleteHobbyCommand { get; private set; }


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

        public Parent SelectedParent
        {
            get { return Get(() => SelectedParent); }
            set { Set(() => SelectedParent, value); }
        }

        public ICommand AddParentCommand { get; private set; }
        public ICommand DeleteParentCommand { get; private set; }

        private void AddParentExecute(object obj)
        {
            IARMLookupViewModel viewModel = new ARMLookupViewModel(UnityContainer, new ARMLookupView());
            viewModel.Initialize(eARMMetadata.Parent);
            ARMLookupWindow wnd = new ARMLookupWindow(viewModel);
            var result = wnd.ShowDialog();
            if (result.HasValue && result.Value && viewModel.SelectedItem != null)
            {
                try
                {
                    var parent = viewModel.SelectedItem as Parent;
                    parent.StudentId = GetBusinessObject<Student>().Id;
                    _unitOfWork.ParentReposotory.Update(parent);
                    _unitOfWork.ParentReposotory.Save();
                    ParentsList.Add(parent);
                    OnPropertyChanged(() => ParentsList);
                }
                catch (Exception ex)
                {
                    ARMSystemFacade.Instance.Logger.LogError(ex.Message);
                }
            }
        }

        private void DeleteParentExecute(object obj)
        {
            if (SelectedParent == null)
                return;
            try
            {
                SelectedParent.StudentId = null;
                _unitOfWork.ParentReposotory.Update(SelectedParent);
                _unitOfWork.ParentReposotory.Save();
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

        public ICommand AddLanguageCommand { get; private set; }
        public ICommand DeleteLanguageCommand { get; private set; }

        public void AddLanguageExecute(object arg)
        {
            IARMLookupViewModel viewModel = new ARMLookupViewModel(UnityContainer, new ARMLookupView());
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

        public void DeleteLanguageExecute(object arg)
        {
            if (SelectedLanguage == null)
                return;
            LanguagesList.Remove(SelectedLanguage);
            OnPropertyChanged(() => LanguagesList);
        }

        #endregion

        #region [private]

        #endregion

    }
}