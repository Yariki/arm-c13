///////////////////////////////////////////////////////////
//  IARMValidatableViewModel.cs
//  Implementation of the Interface IARMValidatableViewModel
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 4:59:44 PM
///////////////////////////////////////////////////////////

using System.ComponentModel;

namespace ARM.Core.Interfaces
{
    public interface IARMValidatableViewModel : IARMDataViewModel, IDataErrorInfo
    {
        void InitializeValidationRules();
    }//end IARMValidatableViewModel
}//end namespace Interfaces