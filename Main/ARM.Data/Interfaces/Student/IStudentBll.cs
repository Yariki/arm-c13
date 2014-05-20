﻿///////////////////////////////////////////////////////////
//  IStudentBll.cs
//  Implementation of the Interface IStudentBll
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:43 PM
///////////////////////////////////////////////////////////

using System.Collections.Generic;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Interfaces.Student
{
    /// <summary>
    /// Інтерфейс бізнес логіки студентів
    /// </summary>
    public interface IStudentBll : IBll<Models.Student>
    {
        IEnumerable<Models.Student> GetAllForeignStudent();
    } //end IStudentBll
} //end namespace Student