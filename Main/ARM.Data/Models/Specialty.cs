﻿///////////////////////////////////////////////////////////
//  Specialty.cs
//  Implementation of the Class Specialty
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:45 PM
///////////////////////////////////////////////////////////

using System;
using System.ComponentModel.DataAnnotations;
using ARM.Core.Attributes;
using ARM.Core.Enums;
using ARM.Resource.AppResource;

namespace ARM.Data.Models
{
    /// <summary>
    /// Модель спеціальності
    /// </summary>
    [ARMMetadata(Metadata = eARMMetadata.Specialty)]
    public class Specialty : BaseNamedModel
    {
        /// <summary>
        /// Ініціалізіція нового екземпляра  <see cref="Specialty"/>.
        /// </summary>
        public Specialty()
        {
            
        }
        /// <summary>
        /// Отримує або задає ідентифікатор факультету.
        /// </summary>
        [ARMRequired]
        public Guid? FacultyId { get; set; }

        /// <summary>
        /// Отримує або задає факультет.
        /// </summary>
        [ARMGrid(Order = 2)]
        [Display(ResourceType = typeof(Resources), Name = "Model_Speciality_Faculty")]
        public virtual Faculty Faculty { get; set; }

        /// <summary>
        /// Зручне представлення моделі для користувача. Повертає певне значення у вигляді рядка для відображеня в інтерфейсі.
        /// </summary>
        public override string Display
        {
            get { return Name; }
        }
    } //end Specialty
} //end namespace Models