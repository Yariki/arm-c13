﻿///////////////////////////////////////////////////////////
//  IARMModel.cs
//  Implementation of the Interface IARMModel
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 4:59:44 PM
///////////////////////////////////////////////////////////

using System;

namespace ARM.Core.Interfaces.Data
{
    /// <summary>
    /// Простір імен, який містить єдиний інтерфейс для всіх моделей даних апліікації.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    internal class NamespaceDoc
    {
    }

    /// <summary>
    /// базовий інтерфейс для моделей даних
    /// </summary>
    public interface IARMModel
    {
        /// <summary>
        /// ідентифікатор моделі в БД
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// зручне представлення моделі для користувача. Повертає певне значення у вигляді рядка для відображеня в інтерфейсі
        /// </summary>
        string Display { get; }
    }//end IARMModel
}//end namespace Data