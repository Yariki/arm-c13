using System;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Data.UnitOfWork.Implementation;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.References.View;
using ARM.Module.Interfaces.References.ViewModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.References
{
    public class ARMFacultyValidatableViewModel : ARMValidatableViewModelBase, IARMFacultyValidatableViewModel
    {
        private IUnitOfWork _unitOfWork;

        public ARMFacultyValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMFacultyView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            _unitOfWork = UnityContainer.Resolve<IUnitOfWork>();
        }

        public override string Title
        {
            get { return FormatTitle(Resource.AppResource.Resources.Model_Data_Faculty); }
        }

        #region [properties]

        public IUnityContainer DiContainer
        {
            get { return UnityContainer; }
        }

        public string Name
        {
            get { return Get(() => Name); }
            set { Set(() => Name, value); }
        }

        public Guid? StaffId
        {
            get { return Get(() => StaffId); }
            set { Set(() => StaffId, value); }
        }

        public string Url
        {
            get { return Get(() => Url); }
            set { Set(() => Url, value); }
        }

        public Guid UniversityId
        {
            get { return Get(() => UniversityId); }
            set { Set(() => UniversityId, value); }
        }

        #endregion

        #region [override]

        public override void SetBusinessObject(ViewMode mode, eARMMetadata metadata, Guid id, bool isIdEmpty = false)
        {
            base.SetBusinessObject(mode, metadata, id, isIdEmpty);
            var entity = GetBusinessObject<Faculty>();
            if (entity == null || _unitOfWork == null)
                return;
            switch (Mode)
            {
                case ViewMode.Add:
                    entity.UniversityId = _unitOfWork.SettingsRepository.GetDefaultUniversity();
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
            ValidateBeforeSave();
            if (!IsValid || _unitOfWork == null)
            {
                ARMSystemFacade.Instance.Logger.LogWarning("Not Valid or Unit Of Work is null");
                return;
            }
            try
            {
                switch (Mode)
                {
                    case ViewMode.Add:
                        _unitOfWork.FacultyRepository.Insert(GetBusinessObject<Faculty>());
                        break;
                    case ViewMode.Edit:
                        _unitOfWork.FacultyRepository.Update(GetBusinessObject<Faculty>());
                        break;

                }
                _unitOfWork.FacultyRepository.Save();
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }

            base.SaveExecute(arg);
        }

        #endregion
    }
}