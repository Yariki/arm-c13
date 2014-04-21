using System;
using System.Collections.Generic;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Data.UnitOfWork.Implementation;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.Helpers;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.References.View;
using ARM.Module.Interfaces.References.ViewModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

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

        public IList<Parent> Parents
        {
            get { return Get(() => Parents); }
            set { Set(() => Parents, value); }
        }

        public Guid? GroupId
        {
            get { return Get(() => GroupId); }
            set { Set(() => GroupId, value); }
        }

        public IList<Hobby> Hobbies
        {
            get { return Get(() => Hobbies); }
            set { Set(() => Hobbies, value); }
        }

        public IList<Achivement> Achivements
        {
            get { return Get(() => Achivements); }
            set { Set(() => Achivements, value); }
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

        public IList<Language> Languages
        {
            get { return Get(() => Languages); }
            set { Set(() => Languages, value); }
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
                        _unitOfWork.StudentRepository.Update(GetBusinessObject<Student>());
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

        #region [private]
        #endregion

    }
}