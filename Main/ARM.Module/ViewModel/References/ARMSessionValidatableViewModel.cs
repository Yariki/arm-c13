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
    /// Клас для роботи з моделю даних - сесії.
    /// </summary>
    public class ARMSessionValidatableViewModel : ARMValidatableViewModelBase, IARMSessionValidatableViewModel
    {
        /// <summary>
        /// Створити екземпляр <see cref="ARMSessionValidatableViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public ARMSessionValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator, IARMSessionView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        #region IARMSessionValidatableViewModel Members

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
        public override string Title
        {
            get { return FormatTitle(Resources.Model_Data_Session); }
        }

        #endregion IARMSessionValidatableViewModel Members

        #region [properties]

        public string Name
        {
            get { return Get(() => Name); }
            set { Set(() => Name, value); }
        }

        public DateTime DateBegin
        {
            get { return Get(() => DateBegin); }
            set { Set(() => DateBegin, value); }
        }

        public DateTime DateEnd
        {
            get { return Get(() => DateEnd); }
            set { Set(() => DateEnd, value); }
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
            var entity = GetBusinessObject<Session>();
            if (entity == null)
                return;
            switch (Mode)
            {
                case ViewMode.Add:
                    entity.DateBegin = entity.DateEnd = DateTime.Now;
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
                using (var unitOfWork = UnityContainer.Resolve<IUnitOfWork>())
                {
                    switch (Mode)
                    {
                        case ViewMode.Add:
                            unitOfWork.SessionRepository.Insert(GetBusinessObject<Session>());
                            break;

                        case ViewMode.Edit:
                            unitOfWork.SessionRepository.Update(GetBusinessObject<Session>());
                            break;
                    }
                    unitOfWork.SessionRepository.Save();
                }
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