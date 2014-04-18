using System;
using System.Collections.Generic;
using ARM.Core.Enums;
using ARM.Core.Service;
using ARM.Data.Layer.Interfaces;
using Microsoft.Practices.Unity;

namespace ARM.Data.Sevice.Resolver
{
    public class ARMDataModelResolveHelper : IARMDataModelResolver
    {
        private readonly IUnityContainer _unityContainer;

        public ARMDataModelResolveHelper(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public object GetDataModel(eARMMetadata metadata, Guid id)
        {
            if (id == Guid.Empty)
            {
                var type = ARMModelsPropertyCache.Instance.GetTypeByMetadata(metadata);
                return Activator.CreateInstance(type);
            }
            var typeData = ARMModelsPropertyCache.Instance.GetTypeByMetadata(metadata);
            var typeBll = typeof (IBll<>);
            var bllForData = typeBll.MakeGenericType(typeData);
            dynamic readyBll = _unityContainer.Resolve(bllForData);
            if (readyBll != null)
            {
                return readyBll.GetById(id);
            }
            return null;
        }

        public IEnumerable<object> GetAllByMetadata(eARMMetadata metadata)
        {
            var typeData = ARMModelsPropertyCache.Instance.GetTypeByMetadata(metadata);
            if (typeData == null)
                return default(IEnumerable<object>);
            var typeBll = typeof (IBll<>);
            var typeBllModel = typeBll.MakeGenericType(typeData);
            using (dynamic readyBll = _unityContainer.Resolve(typeBllModel))
            {
                if (readyBll != null)
                {
                    var result = new List<object>();
                    foreach (object item in readyBll.GetAll())
                    {
                        result.Add(item);
                    }
                    return result;
                }    
            }
            return default(IEnumerable<object>);

        }
    }
}