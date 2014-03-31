///////////////////////////////////////////////////////////
//  IARMToolboxCommand.cs
//  Implementation of the Interface IARMToolboxCommand
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 4:59:44 PM
///////////////////////////////////////////////////////////

using System.Windows.Input;
using ARM.Core.Enums;

namespace ARM.Core.Interfaces
{
    public interface IARMToolboxCommand : ICommand
    {
        string Image
        {
            get;
        }

		string ResourceName
		{
			get;
		}
		
        string Tooltip
        {
            get;
        }

        object Tag
        {
            get;
        }

        ToolbarCommand Type
        {
            get;
        }
		
		int Order{get;}
    }//end IARMToolboxCommand
}//end namespace Interfaces