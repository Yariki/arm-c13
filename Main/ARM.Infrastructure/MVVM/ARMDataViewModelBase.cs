///////////////////////////////////////////////////////////
//  ARMDataViewModelBase.cs
//  Implementation of the Class ARMDataViewModelBase
//  Generated by Enterprise Architect
//  Created on:      30-Mar-2014 8:12:16 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Input;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Core.MVVM;
using ARM.Core.Service;
using ARM.Core.Extensions;
using ARM.Data.Sevice.Resolver;
using ARM.Infrastructure.Events;
using ARM.Infrastructure.Events.EventPayload;
using ARM.Infrastructure.Facade;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Infrastructure.MVVM
{
    public abstract class ARMDataViewModelBase : ARMWorkspaceViewModelBase, IARMDataViewModel
    {
        private object _dataObject;
        private readonly Dictionary<string, object> _values = new Dictionary<string, object>();
        private List<IARMModelPropertyInfo> _listProperty;

        /// 
        ///  <param name="businessObject"></param>
        ///  <param name="view"></param>
        /// <param name="regionManager"></param>
        protected ARMDataViewModelBase(IRegionManager regionManager,IUnityContainer unityContainer,IEventAggregator eventAggregator,  IARMView view) 
            : base(regionManager,unityContainer,eventAggregator,view)
        {
            SaveCommand = new  ARMRelayCommand(SaveExecute, CanSaveExecte);
            CancelCommand = new ARMRelayCommand(CancelExecute,CanCancelExecute);
            HasChanges = false;
        }

        ///
        /// <param name="obj"></param>
        public virtual void SetBusinessObject(ViewMode mode, eARMMetadata metadata, Guid id, bool isIdEmpty = false)
        {
            Mode = mode;
            Metadata = metadata;
            var dataModelReoslver = UnityContainer.Resolve<IARMDataModelResolver>();
            if (dataModelReoslver != null)
            {
                _dataObject = dataModelReoslver.GetDataModel(metadata, id, isIdEmpty);
            }
            _listProperty = ARMModelsPropertyCache.Instance.GetPropertyInfos(_dataObject.GetType()).ToList();
        }

        public ViewMode Mode { get; private set; }
        public eARMMetadata Metadata { get; private set; }
        public bool HasChanges { get; set; }

        public override bool Closing()
        {
            if (HasChanges)
            {
                var result = ARMSystemFacade.Instance.MessageBox.ShowQuestion(Resource.AppResource.Resources.Message_Save);
                if (result == MessageBoxResult.Yes)
                {
                    SaveExecute(null);
                }
            }
            return false;
        }

        public TObj GetBusinessObject<TObj>()
        {
            return (TObj)_dataObject;
        }

        protected bool HasProperty(string name)
        {
            if (!_listProperty.Any())
                return false;
            return _listProperty.Any(i => i.Property.Name == name);
        }

        protected IARMModelPropertyInfo GetPropertyInfo(string name)
        {
            if (!_listProperty.Any())
                return null;
            return _listProperty.FirstOrDefault(i => i.Property.Name == name);
        }

        protected IList<IARMModelPropertyInfo> GetAllArmPropertyInfo()
        {
            return _listProperty;
        }

        ///
        /// <param name="expression"></param>
        protected T Get<T>(Expression<Func<T>> expression)
        {
            return Get<T>(this.GetPropertyName(expression), default(T));
        }

        ///
        /// <param name="expression"></param>
        /// <param name="defaultValue"></param>
        protected T Get<T>(Expression<Func<T>> expression, T defaultValue)
        {
            return Get<T>(this.GetPropertyName(expression),defaultValue);
        }

        ///
        /// <param name="name"></param>
        protected T Get<T>(string name)
        {
            return Get<T>(name,default(T));
        }

        ///
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        protected T Get<T>(string name, T defaultValue)
        {
            if (_dataObject != null && HasProperty(name))
            {
                IARMModelPropertyInfo pi = GetPropertyInfo(name);
                var val =  pi != null ? pi.Property.GetPropertyValue<T>(_dataObject) : defaultValue;
                return val;
            }
            if (_values.ContainsKey(name))
            {
                return (T)_values[name];
            }
            return defaultValue;
        }

        ///
        /// <param name="expression"></param>
        /// <param name="val"></param>
        protected void Set<T>(Expression<Func<T>> expression, T val)
        {
            var name = GetPropertyName(expression);
            Set<T>(name,val);
        }

        ///
        /// <param name="name"></param>
        /// <param name="val"></param>
        protected void Set<T>(string name, T val)
        {
            if (_dataObject != null && HasProperty(name))
            {
                IARMModelPropertyInfo pi = GetPropertyInfo(name);
                if (pi != null)
                {
                    pi.Property.SetPropertyValue(_dataObject, val);
                    HasChanges = true;
                }
            }
            else 
            {
                _values[name] = val;
            }
            OnPropertyChanged(name);
            OnSetValue(name);
            
        }

        ///
        /// <param name="name"></param>
        protected virtual void OnSetValue(string name)
        {
        }

        protected virtual bool CanSaveExecte(object arg)
        {
            return true;
        }

        protected virtual void SaveExecute(object arg)
        {
            HasChanges = false;
            EventAggregator.GetEvent<ARMSyncEvent>().Publish(new ARMSyncEventPayload(Metadata));
            Close();
        }

        protected virtual bool CanCancelExecute(object arg)
        {
            return true;
        }

        protected virtual void CancelExecute(object arg)
        {
            Close();
        }

        public object DataObject
        {
            get { return _dataObject; }
        }
		
		#region [commands]
		
		public ICommand SaveCommand {get;private set;}
		
		public ICommand CancelCommand {get;private set;}
			
		#endregion

        #region [dispose]

        protected override void Dispose(bool disposing)
        {
            if (!Disposed && disposing)
            {
                _dataObject = null;
                if (_listProperty != null)
                {
                    _listProperty.Clear();
                    _listProperty = null;
                }
                if (_values != null)
                {
                    _values.Clear();
                }
            }
            base.Dispose(disposing);
        }

        #endregion


        #region [private]

        private void Close()
        {
            EventAggregator.GetEvent<ARMCloseEvent>().Publish(new ARMCloseEventPayload(this));
        }

        #endregion



    }//end ARMDataViewModelBase
}//end namespace MVVM