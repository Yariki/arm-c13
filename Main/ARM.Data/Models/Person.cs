﻿///////////////////////////////////////////////////////////
//  Person.cs
//  Implementation of the Class Person
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:44 PM
///////////////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;
using ARM.Core.Attributes;
using ARM.Resource.AppResource;

namespace ARM.Data.Models
{
    /// <summary>
    /// Базова модель дял персон
    /// </summary>
    public abstract class Person : BaseModel
    {
        [Display(ResourceType = typeof (Resources), Name = "Model_Person_FirstName")]
        [ARMGrid(Order = 1)]
        [ARMRequired]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof (Resources), Name = "Model_Person_MiddleName")]
        [ARMGrid(Order = 3)]
        public String MiddleName { get; set; }

        [Display(ResourceType = typeof (Resources), Name = "Model_Person_LastName")]
        [ARMGrid(Order = 2)]
        [ARMRequired]
        public string LastName { get; set; }

        [ARMGrid(Order = 4)]
        [Display(ResourceType = typeof (Resources), Name = "Model_Person_Email")]
        public string Email { get; set; }

        [ARMGrid(Order = 5)]
        [Display(ResourceType = typeof (Resources), Name = "Model_Person_PhoneMobile")]
        public string PhoneMobile { get; set; }

        [ARMGrid(Order = 6)]
        [Display(ResourceType = typeof (Resources), Name = "Model_Person_PhoneHome")]
        public string PhoneHome { get; set; }

        [ARMGrid(Order = 7)]
        [Display(ResourceType = typeof (Resources), Name = "Model_Person_Sex")]
        public SexType Sex { get; set; }

        public override string Display
        {
            get { return string.Format("{0} {1} {2}", LastName, MiddleName, FirstName); }
        }
    } //end Person
} //end namespace Models