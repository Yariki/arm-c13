using ARM.Data.Models;
using ARM.Infrastructure.Interfaces.Grid;
using ARM.Infrastructure.MVVM;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.Grid
{
    public class ARMGroupGridViewModel : ARMGridViewModelBase<Group>
    {
        public ARMGroupGridViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMGridView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        public override string Title
        {
            get { return Resource.AppResource.Resources.Model_Group_Title; }
        }
    }
}