///////////////////////////////////////////////////////////
//  IARMWorkspaceViewModel.cs
//  Implementation of the Interface IARMWorkspaceViewModel
//  Generated by Enterprise Architect
//  Created on:      30-Mar-2014 11:24:23 PM
///////////////////////////////////////////////////////////

using System;
using System.Windows.Input;

namespace ARM.Core.Interfaces
{
    public interface IARMWorkspaceViewModel : IARMViewModel
    {
        ICommand CloseCommand { get; }

        event EventHandler RequestClose;
    }//end IARMWorkspaceViewModel
}//end namespace Interfaces