﻿///////////////////////////////////////////////////////////
//  IARMDataViewModel.cs
//  Implementation of the Interface IARMDataViewModel
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 4:59:44 PM
///////////////////////////////////////////////////////////

using System;
using ARM.Core.Enums;

namespace ARM.Core.Interfaces
{
    /// <summary>
    /// базовий інтерфейс для моделей представлення
    /// </summary>
    public interface IARMDataViewModel : IARMWorkspaceViewModel
    {
        /// <summary>
        /// модель даних.
        /// </summary>
        object DataObject { get; }

        /// <summary>
        /// встановлення режиму роботи та моделі даних (у відповідності до метаданих та ідентифікатора)
        /// </summary>
        /// <param name="mode">Режим роботи.</param>
        /// <param name="metadata">Метадата.</param>
        /// <param name="id">Ідентифікатор.</param>
        /// <param name="isIdEmpty">Флаг, чи може фдентифікатор бути пустим.</param>
        void SetBusinessObject(ViewMode mode, eARMMetadata metadata, Guid id, bool isIdEmpty);

        /// <summary>
        /// втсановлення режиму роботи та моделі даних
        /// </summary>
        /// <param name="mode">Режим.</param>
        /// <param name="metadata">Метадата.</param>
        /// <param name="data">Модель даних.</param>
        void SetBusinessObject(ViewMode mode, eARMMetadata metadata, object data);

        /// <summary>
        /// Повернути модель даних у відповідності до переданого типу
        /// </summary>
        /// <typeparam name="TObj">Тип, до якого приводиться модель даних.</typeparam>
        /// <returns></returns>
        TObj GetBusinessObject<TObj>();

        /// <summary>
        /// Режим роботи
        /// </summary>
        /// <value>
        /// Режим.
        /// </value>
        ViewMode Mode { get; }

        /// <summary>
        /// Метадата моделі даних
        /// </summary>
        eARMMetadata Metadata { get; }

        /// <summary>
        /// Повертає або втановлює наявніть змін у моделі
        /// </summary>
        /// <value>
        /// <c>true</c> якщо зміни присутні; в іншому випадку, <c>false</c>.
        /// </value>
        bool HasChanges { get; set; }

        /// <summary>
        /// Обробка закриття моделі
        /// </summary>
        /// <returns></returns>
        bool Closing();
    }//end IARMDataViewModel
}//end namespace Interfaces