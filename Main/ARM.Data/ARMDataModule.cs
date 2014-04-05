using ARM.Core.Module;
using ARM.Data.Layer.Interfaces;
using ARM.Data.UnitOfWork.Implementation;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Unity.AutoRegistration;

namespace ARM.Data
{
    public class ARMDataModule : ARMBaseModule 
    {

        public ARMDataModule(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator) 
            : base(regionManager,unityContainer,eventAggregator)
        {

		}

        protected override void RegistreInterfaces()
        {
            base.RegistreInterfaces();
            UnityContainer
                .ConfigureAutoRegistration()
                .ExcludeSystemAssemblies()
                .Include(If.Implements<IUnitOfWork>,Then.Register().UsingPerCallMode())
                .Include(type => type.ImplementsOpenGeneric(typeof(IContext<>)),Then.Register().UsingPerCallMode())
                .Include(type => type.ImplementsOpenGeneric(typeof(IDal<>)), Then.Register().UsingPerCallMode())
                .Include(type => type.ImplementsOpenGeneric(typeof(IBll<>)),Then.Register().UsingPerCallMode())
                .ApplyAutoRegistration();
        }
    }
}