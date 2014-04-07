///////////////////////////////////////////////////////////
//  IARMToolboxViewModel.cs
//  Implementation of the Interface IARMToolboxViewModel
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 4:59:44 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using ARM.Core.Enums;

namespace ARM.Core.Interfaces
{
    public interface IARMToolboxViewModel : IARMViewModel
    {
        IEnumerable<IARMToolboxCommand> Commands
        {
            get;
        }

        void InitializeCommands();

        void AddCommand(IARMToolboxCommand cmd);

        void SetActions(Action<ToolbarCommand> action, Func<ToolbarCommand, bool> predicate);

    }//end IARMToolboxViewModel
}//end namespace Interfaces