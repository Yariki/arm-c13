///////////////////////////////////////////////////////////
//  IARMGridViewModel.cs
//  Implementation of the Interface IARMGridViewModel
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 4:59:44 PM
///////////////////////////////////////////////////////////

using System.Collections.Generic;
using ARM.Core.Enums;

namespace ARM.Core.Interfaces
{
    public interface IARMGridViewModel<T> : IARMViewModel
    {
        IList<T> DataSource
        {
            get;
            set;
        }

        ///
        /// <param name="cmdType"></param>
        void DoCommand(ToolbarCommand cmdType);

        IARMToolboxViewModel Toolbox
        {
            get;
            set;
        }
    }//end IARMGridViewModel
}//end namespace Interfaces