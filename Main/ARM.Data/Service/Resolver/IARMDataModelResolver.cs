using System;
using System.Collections.Generic;
using ARM.Core.Enums;

namespace ARM.Data.Sevice.Resolver
{
    /// <summary>
    /// Інтерфейс, який відповідає за реалізацію функціональності вибору елемента
    /// у відповідності до його метадати та ідентифікатора.
    /// Викоритовуєтьсяь для вибірки існуючого елемента або для створення нового
    /// </summary>
    public interface IARMDataModelResolver
    {
        /// <summary>
        /// Отримує елемент.
        /// </summary>
        /// <param name="metadata">Метадата.</param>
        /// <param name="id">Ідентифікатор.</param>
        /// <param name="isIdEmpty">Чи може приймати пустий ідентифікатор.</param>
        /// <returns></returns>
        object GetDataModel(eARMMetadata metadata, Guid id, bool isIdEmpty);

        /// <summary>
        /// Отримує всі елементи по метадаті.
        /// </summary>
        /// <param name="metadata">Метадата.</param>
        /// <returns></returns>
        IEnumerable<object> GetAllByMetadata(eARMMetadata metadata);
    }
}