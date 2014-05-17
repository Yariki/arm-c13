using System;
using System.Collections.Generic;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Data.UnitOfWork.Implementation;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.Helpers;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.Documents.View;
using ARM.Module.Interfaces.Documents.ViewModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.Documents
{
    public class ARMContractValidatableViewModel : ARMValidatableViewModelBase, IARMContractValidatableViewModel
    {

        private IUnitOfWork _unitOfWork = null;

        public ARMContractValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMContractView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            _unitOfWork = UnityContainer.Resolve<IUnitOfWork>();
        }

        public override string Title
        {
            get { return FormatTitle(Resource.AppResource.Resources.Model_Data_Contract); }
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

        public string Note
        {
            get { return Get(() => Note); }
            set { Set(() => Note, value); }
        }

        public string Number
        {
            get { return Get(() => Number); }
            set { Set(() => Number, value); }
        }

        public EducationLevel Level
        {
            get { return Get(() => Level); }
            set { Set(() => Level, value); }
        }

        public Guid? ParentId
        {
            get { return Get(() => ParentId); }
            set { Set(() => ParentId, value); }
        }

        public Guid? UniversityId
        {
            get { return Get(() => UniversityId); }
            set { Set(() => UniversityId, value); }
        }

        public Guid? StudentId
        {
            get { return Get(() => StudentId); }
            set { Set(() => StudentId, value); }
        }

        public Guid? SpecialityId
        {
            get { return Get(() => SpecialityId); }
            set { Set(() => SpecialityId, value); }
        }

        public decimal Price
        {
            get { return Get(() => Price); }
            set { Set(() => Price, value); }
        }
        #endregion

        #region [source enum]

        private Dictionary<EducationLevel, string> _sourceEducation;

        public Dictionary<EducationLevel, string> SourceEducation
        {
            get
            {
                return _sourceEducation ?? (_sourceEducation = ARMEnumHelper.Instance.GetLocalsForEnum<EducationLevel>());
            }
        }

        #endregion

        #region [overrides]

        public override void SetBusinessObject(ViewMode mode, eARMMetadata metadata, Guid id, bool isIdEmpty = false)
        {
            base.SetBusinessObject(mode, metadata, id, isIdEmpty);
            var entity = GetBusinessObject<Contract>();
            if (entity == null || _unitOfWork == null)
                return;
            switch (Mode)
            {

                case ViewMode.Add:
                    entity.UniversityId = _unitOfWork.SettingsRepository.GetDefaultUniversity();
                    entity.Level = _unitOfWork.SettingsRepository.GetDefaultEducationLevel();
                    entity.Number = string.Format("{0}-{1:D10}", _unitOfWork.SettingsRepository.GetContractPrefix(),
                        _unitOfWork.SettingsRepository.GetNextContractNumber());
                    break;
            }
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
                        _unitOfWork.ContractRepository.Insert(GetBusinessObject<Contract>());
                        break;
                    case ViewMode.Edit:
                        _unitOfWork.ContractRepository.Update(GetBusinessObject<Contract>());
                        break;
                }
                _unitOfWork.ContractRepository.Save();
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }
            base.SaveExecute(arg);
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

        #endregion

        #region [private]
        #endregion

    }
}