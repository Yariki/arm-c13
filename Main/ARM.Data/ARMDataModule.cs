using ARM.Core.Module;
using ARM.Data.Layer.Interfaces;
using ARM.Data.Sevice.Resolver;
using ARM.Data.UnitOfWork.Implementation;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Unity.AutoRegistration;

namespace ARM.Data
{
    /// <summary>
    /// Простір імен, класи якого призначені для забезпечення робота з БД.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    internal class NamespaceDoc
    {
    }

    /// <summary>
    /// Моудль, що відповідає за реєстрацію всіх класів для даних.
    /// </summary>
    public class ARMDataModule : ARMBaseModule
    {
        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="ARMDataModule"/>.
        /// </summary>
        /// <param name="regionManager">Менеджер областей.</param>
        /// <param name="unityContainer">Контейнер IoC.</param>
        /// <param name="eventAggregator">Агрегатор подій.</param>
        public ARMDataModule(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator)
            : base(regionManager, unityContainer, eventAggregator)
        {
        }

        /// <summary>
        /// Реєстрація інтерфейсів.
        /// </summary>
        protected override void RegistreInterfaces()
        {
            base.RegistreInterfaces();
            UnityContainer
                .ConfigureAutoRegistration()
                .ExcludeSystemAssemblies()
                .Include(If.Implements<IUnitOfWork>, Then.Register().UsingPerCallMode())
                .Include(type => type.ImplementsOpenGeneric(typeof(IContext<>)), Then.Register().UsingPerCallMode())
                .Include(type => type.ImplementsOpenGeneric(typeof(IDal<>)), Then.Register().UsingPerCallMode())
                .Include(type => type.ImplementsOpenGeneric(typeof(IBll<>)), Then.Register().UsingPerCallMode())
                .ApplyAutoRegistration();
            UnityContainer.RegisterType<IARMDataModelResolver, ARMDataModelResolveHelper>(new ContainerControlledLifetimeManager());
        }
    }
}