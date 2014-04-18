///////////////////////////////////////////////////////////
//  BaseModel.cs
//  Implementation of the Class BaseModel
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:38 PM
///////////////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using ARM.Core.Attributes;
using ARM.Core.Interfaces.Data;
using ARM.Resource.AppResource;

namespace ARM.Data.Models
{
    public abstract class BaseModel : IARMModel
    {
        protected BaseModel()
        {
            DateModified = DateTime.Now;
        }

        public Guid Id
        {
            get;
            set;
        }

        [ARMGrid(Order = int.MaxValue)]
        [Display(ResourceType =   typeof(ARM.Resource.AppResource.Resources),Name = "Model_DateModified")]
        public DateTime DateModified
        {
            get;
            set;
        }

        public string ModifiedBy
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }//end BaseModel
}//end namespace Models