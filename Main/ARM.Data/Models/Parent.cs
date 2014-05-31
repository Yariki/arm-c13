﻿///////////////////////////////////////////////////////////
//  Parent.cs
//  Implementation of the Class Parent
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:44 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ARM.Core.Attributes;
using ARM.Core.Enums;

namespace ARM.Data.Models
{
    /// <summary>
    /// Модель батька
    /// </summary>
    [ARMMetadata(Metadata = eARMMetadata.Parent)]
    public class Parent : Person
    {
        /// <summary>
        /// Ініціалізіція нового екземпляра  <see cref="Parent"/>.
        /// </summary>
        public Parent()
        {
            
        }
        /// <summary>
        /// Отримує або задає ідентифікатор студента.
        /// </summary>
        public Guid? StudentId
        {
            get;
            set;
        }

        /// <summary>
        /// Отримує або задає студента.
        /// </summary>
        [ForeignKey("StudentId")]
        public virtual Student Child
        {
            get;
            set;
        }

        /// <summary>
        /// Отримує або задає ідентифікатор адреси.
        /// </summary>
        [ARMRequired]
        public Guid AddressId { get; set; }

        /// <summary>
        /// Отримує або задає адресу.
        /// </summary>
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        /// <summary>
        /// Отримує або задає список контрактів.
        /// </summary>
        public virtual IList<Contract> Contracts { get; set; }
    }//end Parent
}//end namespace Models