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
    /// <summary>
    /// Класс для роботи з контраками.
    /// </summary>
    public class ARMContractValidatableViewModel : ARMValidatableViewModelBase, IARMContractValidatableViewModel
    {

        private IUnitOfWork _unitOfWork = null;

        /// <summary>
        /// Створити екземпляр <see cref="ARMContractValidatableViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">Менеджер регіонів.</param>
        /// <param name="unityContainer">Контейнер.</param>
        /// <param name="eventAggregator">Агрегатор подій.</param>
        /// <param name="view">Представлення.</param>
        public ARMContractValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMContractView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            _unitOfWork = UnityContainer.Resolve<IUnitOfWork>();
        }

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
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

        /// <summary>
        /// Оримує або задає дані для типів навчання.
        /// </summary>
        /// <value>
        /// The source education.
        /// </value>
        public Dictionary<EducationLevel, string> SourceEducation
        {
            get
            {
                return _sourceEducation ?? (_sourceEducation = ARMEnumHelper.Instance.GetLocalsForEnum<EducationLevel>());
            }
        }

        #endregion

        #region [overrides]

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

        #endregion

        #region [private]
        #endregion

    }
}