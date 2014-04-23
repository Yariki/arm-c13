using System;
using System.Collections.Generic;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Core.MVVM;
using ARM.Core.Service;
using ARM.Data.Sevice.Resolver;
using ARM.Infrastructure.Controls.Interfaces;
using Microsoft.Practices.Unity;

namespace ARM.Infrastructure.Controls.ARMLookupWindow
{
    public class ARMLookupViewModel : ARMViewModelBase,IARMLookupViewModel
    {
        private IUnityContainer _unityContainer;

        public ARMLookupViewModel(IUnityContainer unityContainer, IARMView view) : base(view)
        {
            _unityContainer = unityContainer;
        }

        public IEnumerable<object> Source { get; private set; }

        public eARMMetadata Metadata { get; private set; }
        public Type EntityType { get; private set; }

        public object SelectedItem { get; set; }

        public void Initialize(eARMMetadata metadata)
        {
            var resolver = _unityContainer.Resolve<IARMDataModelResolver>();
            if(resolver == null)
                return;
            Metadata = metadata;
            EntityType = ARMModelsPropertyCache.Instance.GetTypeByMetadata(Metadata);
            Source = resolver.GetAllByMetadata(Metadata);

            OnPropertyChanged(() => Source);
            OnPropertyChanged(() => EntityType);
        }
    }
}