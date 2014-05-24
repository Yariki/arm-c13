using System;
using ARM.Core.Enums;
using ARM.Data.Interfaces.University;
using ARM.Data.Models;
using ARM.Data.UnitOfWork.Implementation;
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
    /// Клас для роботи з моделю даних -   університет.
    /// </summary>
    public class ARMUniversityDataViewModel : ARMDataViewModelBase, IARMUniversityDataViewModel
    {
        /// <summary>
        /// Створити екземпляр <see cref="ARMUniversityDataViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public ARMUniversityDataViewModel(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator, IARMUniversityView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
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

        public string Email
        {
            get { return Get(() => Email); }
            set { Set(() => Email, value); }
        }

        #region IARMUniversityDataViewModel Members

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
        public override string Title
        {
            get
            {
                return string.Format(Resources.Model_Data_University,
                    Mode == ViewMode.Add
                        ? Resources.Model_Action_Add
                        : Mode == ViewMode.Edit
                            ? Resources.Model_Action_Edit
                            : Mode == ViewMode.View ? Resources.Model_Action_View : "");
            }
        }

        #endregion IARMUniversityDataViewModel Members

        /// <summary>
        /// Виклик зберігання обєкту.
        /// </summary>
        /// <param name="arg">Аргумент.</param>
        protected override void SaveExecute(object arg)
        {
            using (var unitOfWork = UnityContainer.Resolve<IUnitOfWork>())
            {
                IUniversityBll universityRepositary = unitOfWork.UniversityRepository;
                switch (Mode)
                {
                    case ViewMode.Add:
                        universityRepositary.Insert(GetBusinessObject<University>());
                        universityRepositary.Save();
                        break;

                    case ViewMode.Edit:
                        universityRepositary.Update(GetBusinessObject<University>());
                        universityRepositary.Save();
                        break;
                }
            }
            base.SaveExecute(arg);
        }
    }
}