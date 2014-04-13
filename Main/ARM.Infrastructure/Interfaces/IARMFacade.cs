///////////////////////////////////////////////////////////
//  IARMFacade.cs
//  Implementation of the Interface IARMFacade
//  Generated by Enterprise Architect
//  Created on:      30-Mar-2014 8:12:16 PM
///////////////////////////////////////////////////////////

using ARM.Core.Interfaces;

namespace ARM.Infrastructure.Interfaces
{
    public interface IARMFacade
    {
        IARMLoggerFacade Logger
        {
            get;
            set;
        }

        IARMMessageBoxFacade MessageBox
        {
            get;
            set;
        }
    }//end IARMFacade
}//end namespace Interfaces