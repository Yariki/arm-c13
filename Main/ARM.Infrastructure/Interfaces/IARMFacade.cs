///////////////////////////////////////////////////////////
//  IARMFacade.cs
//  Implementation of the Interface IARMFacade
//  Generated by Enterprise Architect
//  Created on:      30-Mar-2014 8:12:16 PM
///////////////////////////////////////////////////////////

using ARM.Core.Interfaces;
using ARM.Data.Models;

namespace ARM.Infrastructure.Interfaces
{
    public interface IARMFacade
    {
        IARMLoggerFacade Logger { get; }

        IARMMessageBoxFacade MessageBox { get; }

        User CurrentUser { get; set; }
    } //end IARMFacade
} //end namespace Interfaces