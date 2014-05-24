using ARM.Data.Models;
using ARM.Infrastructure.Interfaces.Grid;
using ARM.Infrastructure.MVVM;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.Grid
{
    /// <summary>
    /// Клас для відображення сітки з правцівниками.
    /// </summary>
    public class ARMStaffGridViewModel : ARMGridViewModelBase<Staff>
    {
        /// <summary>
        /// Створити екземпляр <see cref="ARMStaffGridViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public ARMStaffGridViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMGridView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
        public override string Title
        {
            get { return Resource.AppResource.Resources.Grid_Staff_Title; }
        }
    }
}