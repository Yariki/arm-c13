///////////////////////////////////////////////////////////
//  ARMModelsPeopertyCache.cs
//  Implementation of the Class ARMModelsPeopertyCache
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 4:59:43 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using ARM.Core.Attributes;
using ARM.Core.Enums;
using ARM.Core.Extensions;
using ARM.Core.Interfaces;
using ARM.Core.Interfaces.Data;
using ARM.Core.Reflection;

namespace ARM.Core.Service
{
    public class ARMModelsPropertyCache
    {
        private Dictionary<Type, List<IARMModelPropertyInfo>> _dictCache = null;
        private Dictionary<eARMMetadata, Type> _dictMetadata = null;
        private const string AssemblyPrefix = "ARM";

        private ARMModelsPropertyCache()
        {
            _dictCache = new Dictionary<Type, List<IARMModelPropertyInfo>>();
            _dictMetadata = new Dictionary<eARMMetadata, Type>();
        }

        #region [static]

        private static Lazy<ARMModelsPropertyCache> _instance = new Lazy<ARMModelsPropertyCache>(() => new ARMModelsPropertyCache());

        public static ARMModelsPropertyCache Instance
        {
            get { return _instance.Value; }
        }

        #endregion [static]

        private void InitCache()
        {
            var listType =
                AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains(AssemblyPrefix)).SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IARMModel))));
            foreach (var type in listType)
            {
                AddType(type);
            }
        }

        private void AddType(Type type)
        {
            var listPi = type.GetAllPublicProperties();
            if (!listPi.Any()) return;
            List<IARMModelPropertyInfo> listArmPi = new List<IARMModelPropertyInfo>();
            foreach (var propertyInfo in listPi)
            {
                bool isRequired = propertyInfo.HasAttribute<ARMRequiredAttribute>();
                bool visiblbeInGrid = propertyInfo.HasAttribute<ARMGridAttribute>();
                int orderinGrid = 0;
                IARMValidationAttribute validAttr = null;
                DisplayAttribute disAttr = null;
                if (visiblbeInGrid)
                {
                    orderinGrid = propertyInfo.GetAttribute<ARMGridAttribute>().Order;
                }
                if (propertyInfo.HasAttribute<ARMValidationAttribute>())
                {
                    validAttr = propertyInfo.GetAttribute<ARMValidationAttribute>();
                }
                if (propertyInfo.HasAttribute<DisplayAttribute>())
                {
                    disAttr = propertyInfo.GetAttribute<DisplayAttribute>();
                }
                listArmPi.Add(new ARMModelPropertyInfo(propertyInfo, isRequired, validAttr, visiblbeInGrid, orderinGrid, disAttr));
            }
            _dictCache[type] = listArmPi;

            if (type.HasAttribute<ARMMetadataAttribute>())
            {
                eARMMetadata metadata = type.GetAttribute<ARMMetadataAttribute>().Metadata;
                _dictMetadata[metadata] = type;
            }
        }

        public void Initialize()
        {
            InitCache();
        }

        ///
        /// <param name="type"></param>
        public void AddNewType(Type type)
        {
            Contract.Requires(type != null);
            AddType(type);
        }

        ///
        /// <param name="type"></param>
        public List<IARMModelPropertyInfo> GetPropertyInfos(Type type)
        {
            Contract.Requires(type != null);
            type = GetCorrecType(type);
            return _dictCache.ContainsKey(type) ? _dictCache[type] : null;
        }

        public Type GetTypeByMetadata(eARMMetadata metadata)
        {
            Contract.Requires(metadata != eARMMetadata.None);
            return _dictMetadata[metadata];
        }

        public eARMMetadata GetMetadataByType(Type t)
        {
            Contract.Requires(t != null);
            t = GetCorrecType(t);
            var kpV = _dictMetadata.FirstOrDefault(kp => kp.Value == t);
            return kpV.Key;
        }

        private Type GetCorrecType(Type t)
        {
            if (t.BaseType != null && t.Namespace == "System.Data.Entity.DynamicProxies")
            {
                return t.BaseType;
            }
            return t;
        }
    }//end ARMModelsPeopertyCache
}//end namespace Service