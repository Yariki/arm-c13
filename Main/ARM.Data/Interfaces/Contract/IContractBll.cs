///////////////////////////////////////////////////////////
//  IContractBll.cs
//  Implementation of the Interface IContractBll
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:41 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Interfaces.Contract
{
    public interface IContractBll : IBll<Models.Contract>
    {
        IEnumerable<Models.Contract> GetContractsByStudent(IEnumerable<Guid> listOfStudentsId);
    } //end IContractBll
} //end namespace Contract