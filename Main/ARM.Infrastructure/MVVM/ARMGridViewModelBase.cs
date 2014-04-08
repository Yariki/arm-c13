///////////////////////////////////////////////////////////
//  ARMGridViewModelBase.cs
//  Implementation of the Class ARMGridViewModelBase
//  Generated by Enterprise Architect
//  Created on:      30-Mar-2014 8:12:16 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Core.MVVM;
using ARM.Data.Layer.Interfaces;
using ARM.Data.UnitOfWork.Implementation;
using ARM.Infrastructure.Interfaces.Grid;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Xceed.Wpf.Toolkit;

namespace ARM.Infrastructure.MVVM
{
    public abstract class ARMGridViewModelBase<T> : ARMWorkspaceViewModelBase, IARMGridViewModel<T>
    {
        private IBll<T> _bll = null; 

        public ARMGridViewModelBase(IRegionManager regionManager,IUnityContainer unityContainer,IEventAggregator eventAggregator, IARMGridView view)
        :base(regionManager,unityContainer,eventAggregator, view)
        {
            Toolbox = UnityContainer.Resolve<IARMToolboxViewModel>();
            Toolbox.SetActions(OnToolboxExecute,OnToolboxCanExecute);
            Toolbox.InitializeCommands();

            Init();
        }

        public IEnumerable<T> DataSource
        {
            get;
            private set;
        }

        ///
        /// <param name="cmdType"></param>
        public void DoCommand(ToolbarCommand cmdType)
        {
        }

        public IARMToolboxViewModel Toolbox
        {
            get;
            private set;
        }

        public Type EntityType
        {
            get { return typeof (T); }
        }

        public abstract string Title { get; }

        #region [protected]

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!Disposed)
            {
                if (disposing)
                {
                    if(_bll != null)
                        _bll.Dispose();
                    DataSource = null;
                }
            }
        }

        #endregion

        #region [toolbox commands]

        private void OnToolboxExecute(ToolbarCommand cmd)
        {
            MessageBox.Show(cmd.ToString());
        }

        private bool OnToolboxCanExecute(ToolbarCommand cmd)
        {
            return true;
        }

        #endregion


        #region [private]

        private void Init()
        {
            _bll = UnityContainer.Resolve<IBll<T>>();
            if (_bll != null)
            {
                var list = _bll.GetAll().ToList();
                DataSource = list;
                OnPropertyChanged(() => DataSource);
            }
        }

        #endregion

    }//end ARMGridViewModelBase
}//end namespace MVVM