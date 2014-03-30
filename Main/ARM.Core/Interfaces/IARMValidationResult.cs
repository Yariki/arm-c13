///////////////////////////////////////////////////////////
//  IARMValidationResult.cs
//  Implementation of the Interface IARMValidationResult
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 4:59:44 PM
///////////////////////////////////////////////////////////

using System.Collections.Generic;

namespace ARM.Core.Interfaces
{
    public interface IARMValidationResult
    {
        bool IsValid
        {
            get;
            set;
        }

        IEnumerable<string> GetErrors();
    }//end IARMValidationResult
}//end namespace Interfaces