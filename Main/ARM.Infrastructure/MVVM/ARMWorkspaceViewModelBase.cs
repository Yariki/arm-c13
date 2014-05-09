///////////////////////////////////////////////////////////
//  ARMWorkspaceViewModelBase.cs
//  Implementation of the Class ARMWorkspaceViewModelBase
//  Generated by Enterprise Architect
//  Created on:      31-Mar-2014 12:33:20 AM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Input;
using ARM.Core.Extensions;
using ARM.Core.Interfaces;
using ARM.Core.MVVM;
using ARM.Data.UnitOfWork.Implementation;
using ARM.Infrastructure.Events;
using ARM.Infrastructure.Events.EventPayload;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Infrastructure.MVVM
{
    public abstract class ARMWorkspaceViewModelBase : ARMViewModelBase,IARMWorkspaceViewModel
    {

#region [needs]
        private ICommand _closeCommand;
        protected readonly IRegionManager RegionManager;
        protected readonly IUnityContainer UnityContainer;
        protected readonly IEventAggregator EventAggregator;
        protected readonly Dictionary<string, object> _values = new Dictionary<string, object>();
        protected IUnitOfWork UnitOfWork = null;

        #endregion


        public class CloseAbort
        {
            public bool Handled { get; set; }
        }

        public ARMWorkspaceViewModelBase(IRegionManager regionManager,IUnityContainer unityContainer,IEventAggregator eventAggregator, IARMView view)
            : base(view)
        {
            RegionManager = regionManager;
            UnityContainer = unityContainer;
            EventAggregator = eventAggregator;
            CancelCommand = new ARMRelayCommand(CancelExecute, CanCancelExecute);
            UnitOfWork = UnityContainer.Resolve<IUnitOfWork>();
        }

        
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new DelegateCommand(OnClose);
                }
                return _closeCommand;
            }
        }

        public abstract string Title { get; }
        public ICommand CancelCommand {get;private set;}

        public virtual void Initialize()
        {
        }

        public event EventHandler RequestClose;

        public virtual bool Closing()
        {
            return false;
        }

        protected virtual void Closing(CloseAbort args)
        {   
        }

        protected virtual void Closed(){}

        private void OnClose()
        {
            var args = new CloseAbort() {Handled = false};
            Closing(args);

            EventHandler temp = RequestClose;
            if (temp != null && !args.Handled)
                temp(this, EventArgs.Empty);
            Closed();
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
        protected virtual T Get<T>(string name, T defaultValue)
        {
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
        protected virtual void Set<T>(string name, T val)
        {
            _values[name] = val;
            OnPropertyChanged(name);
            OnSetValue(name);
        }

        ///
        /// <param name="name"></param>
        protected virtual void OnSetValue(string name)
        {
        }

        protected virtual bool CanCancelExecute(object arg)
        {
            return true;
        }

        protected virtual void CancelExecute(object arg)
        {
            Close();
        }

        protected void Close()
        {
            EventAggregator.GetEvent<ARMCloseEvent>().Publish(new ARMCloseEventPayload(this));
        }

        #region [dispose]

        protected override void Dispose(bool disposing)
        {
            if (!Disposed && disposing)
            {
                if (_values != null)
                {
                    _values.Clear();
                }
                if (UnitOfWork != null)
                {
                    UnitOfWork.Dispose();
                    UnitOfWork = null;
                }
            }
            base.Dispose(disposing);
        }

        #endregion

    }//end ARMWorkspaceViewModelBase
}//end namespace MVVM