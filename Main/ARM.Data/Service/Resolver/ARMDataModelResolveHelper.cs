using System;
using System.Collections.Generic;
using ARM.Core.Enums;
using ARM.Core.Service;
using ARM.Data.Layer.Interfaces;
using Microsoft.Practices.Unity;

namespace ARM.Data.Sevice.Resolver
{
    /// <summary>
    /// Клас, що відповідає за вибірку елементів за їх метаданими та ідентифікаторами.
    /// </summary>
    public class ARMDataModelResolveHelper : IARMDataModelResolver
    {
        private readonly IUnityContainer _unityContainer;

        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="ARMDataModelResolveHelper"/>.
        /// </summary>
        /// <param name="unityContainer">Контейнер IoC.</param>
        public ARMDataModelResolveHelper(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        /// <summary>
        /// Отримує елемент.
        /// </summary>
        /// <param name="metadata">Метадата.</param>
        /// <param name="id">Ідентифікатор.</param>
        /// <param name="isIdEmpty">Чи може приймати пустий ідентифікатор.</param>
        /// <returns></returns>
        public object GetDataModel(eARMMetadata metadata, Guid id, bool isIdEmpty = false)
        {
            if (id == Guid.Empty && !isIdEmpty)
            {
                var type = ARMModelsPropertyCache.Instance.GetTypeByMetadata(metadata);
                return Activator.CreateInstance(type);
            }
            var typeData = ARMModelsPropertyCache.Instance.GetTypeByMetadata(metadata);
            var typeBll = typeof(IBll<>);
            var bllForData = typeBll.MakeGenericType(typeData);
            dynamic readyBll = _unityContainer.Resolve(bllForData);
            if (readyBll != null)
            {
                return readyBll.GetById(id);
            }
            return null;
        }

        /// <summary>
        /// Отримує всі елементи по метадаті.
        /// </summary>
        /// <param name="metadata">Метадата.</param>
        /// <returns></returns>
        public IEnumerable<object> GetAllByMetadata(eARMMetadata metadata)
        {
            var typeData = ARMModelsPropertyCache.Instance.GetTypeByMetadata(metadata);
            if (typeData == null)
                return default(IEnumerable<object>);
            var typeBll = typeof(IBll<>);
            var typeBllModel = typeBll.MakeGenericType(typeData);
            using (dynamic readyBll = _unityContainer.Resolve(typeBllModel))
            {
                if (readyBll != null)
                {
                    var result = new List<object>();
                    foreach (object item in readyBll.GetAllWithRelated())
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