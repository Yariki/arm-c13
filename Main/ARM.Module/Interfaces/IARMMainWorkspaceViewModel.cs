///////////////////////////////////////////////////////////
//  IARMMainWorkspaceViewModel.cs
//  Implementation of the Interface IARMMainWorkspaceViewModel
//  Generated by Enterprise Architect
//  Created on:      01-Apr-2014 1:37:55 AM
///////////////////////////////////////////////////////////

using System.Collections.ObjectModel;
using ARM.Core.Interfaces;

namespace ARM.Module.Interfaces
{
    public interface IARMMainWorkspaceViewModel : IARMViewModel
    {
        ObservableCollection<IARMWorkspaceViewModel> Items
        {
            get;
            set;
        }

        IARMWorkspaceViewModel CurrentWorkspace
        {
            get;
            set;
        }

        IARMView MenuView
        {
            get;
            set;
        }

        IARMView ToolboxView
        {
            get;
            set;
        }

        IARMView StatusBarView
        {
            get;
            set;
        }

        IARMMainMenuViewModel Menu();

        IARMMainToolboxViewModel Toolbox();

        IARMMainStatusBarViewModel StatusBar();
    }//end IARMMainWorkspaceViewModel
}//end namespace Interfaces