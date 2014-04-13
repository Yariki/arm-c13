///////////////////////////////////////////////////////////
//  IARMDataViewModel.cs
//  Implementation of the Interface IARMDataViewModel
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 4:59:44 PM
///////////////////////////////////////////////////////////

using System;
using ARM.Core.Enums;

namespace ARM.Core.Interfaces
{
    public interface IARMDataViewModel : IARMWorkspaceViewModel
    {
        object DataObject { get; }

        /// 
        ///  <param name="obj"></param>
        /// <param name="mode"></param>
        void SetBusinessObject(ViewMode mode,eARMMetadata metadata, Guid id);

        ViewMode Mode { get; }

        eARMMetadata Metadata { get; }

        bool HasChanges { get; set; }

        bool Closing();
    }//end IARMDataViewModel
}//end namespace Interfaces