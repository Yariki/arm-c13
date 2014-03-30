///////////////////////////////////////////////////////////
//  ARMGridViewModelBase.cs
//  Implementation of the Class ARMGridViewModelBase
//  Generated by Enterprise Architect
//  Created on:      30-Mar-2014 8:12:16 PM
///////////////////////////////////////////////////////////

using System.Collections.Generic;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Core.MVVM;

namespace ARM.Infrastructure.MVVM
{
    public class ARMGridViewModelBase<T> : ARMWorkspaceViewModelBase, IARMGridViewModel<T>
    {
        public ARMGridViewModelBase(IARMView view)
        :base(view)
        {
        }

        public IARMView View
        {
            get;
            set;
        }

        public IList<T> DataSource
        {
            get;
            set;
        }

        ///
        /// <param name="cmdType"></param>
        public void DoCommand(ToolbarCommand cmdType)
        {
        }

        public IARMToolboxViewModel Toolbox
        {
            get;
            set;
        }
    }//end ARMGridViewModelBase
}//end namespace MVVM