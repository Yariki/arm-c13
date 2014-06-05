﻿///////////////////////////////////////////////////////////
//  IMarkBll.cs
//  Implementation of the Interface IMarkBll
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:42 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Interfaces.Mark
{
    /// <summary>
    /// Простір імен інтерфейсів для моделей даних - оцінками
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    internal class NamespaceDoc
    {
    }
    /// <summary>
    /// Інтерфейс бізнес логіки оцінок
    /// </summary>
    public interface IMarkBll : IBll<Models.Mark>
    {
        /// <summary>
        /// Повернути список оцінок за списком студентів та класів.
        /// </summary>
        /// <param name="listStudents">Список студентів.</param>
        /// <param name="listClasses">Список заннять.</param>
        /// <returns></returns>
        IQueryable<Models.Mark> GetMarkAccordingStudentsAndClasses(IEnumerable<Guid> listStudents,
            IEnumerable<Guid> listClasses);

        /// <summary>
        /// Отримати суму балыв для студента по заняттю.
        /// </summary>
        /// <param name="studendId">Ідентифікатор студента.</param>
        /// <param name="classId">Ідентифікатор заннятя.</param>
        /// <returns></returns>
        decimal? GetSumRateForStudentAndClass(Guid studendId, Guid classId);


    } //end IMarkBll
} //end namespace Mark