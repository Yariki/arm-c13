using System;
using ARM.Core.Enums;
using ARM.Data.Models;
using ARM.Data.UnitOfWork.Implementation;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.References.View;
using ARM.Module.Interfaces.References.ViewModel;
using ARM.Resource.AppResource;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.References
{
    /// <summary>
    /// Клас для роботи з моделю даних - факультети
    /// </summary>
    public class ARMFacultyValidatableViewModel : ARMValidatableViewModelBase, IARMFacultyValidatableViewModel
    {
        private IUnitOfWork _unitOfWork;

        /// <summary>
        /// Створити екземпляр <see cref="ARMFacultyValidatableViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public ARMFacultyValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator, IARMFacultyView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            _unitOfWork = UnityContainer.Resolve<IUnitOfWork>();
        }

        #region IARMFacultyValidatableViewModel Members

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
        public override string Title
        {
            get { return FormatTitle(Resources.Model_Data_Faculty); }
        }

        #endregion IARMFacultyValidatableViewModel Members

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

        #endregion [properties]

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

        #endregion [override]
    }
}