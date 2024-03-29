﻿///////////////////////////////////////////////////////////
//  IPaymentBll.cs
//  Implementation of the Interface IPaymentBll
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:42 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Interfaces.Payment
{

    /// <summary>
    /// Простір імен інтерфейсів для моделей даних - платіжки
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    internal class NamespaceDoc
    {
    }
    /// <summary>
    /// Інтерфейс бізнес логіки платіжок
    /// </summary>
    public interface IPaymentBll : IBll<Models.Payment>
    {
        /// <summary>
        /// Повернути список платіжок для списку рахунків.
        /// </summary>
        /// <param name="listInvoice">Список рахунків.</param>
        /// <returns></returns>
        IEnumerable<Models.Payment> GetInvoicesPayments(IEnumerable<Guid> listInvoice);
    } //end IPaymentBll
} //end namespace Payment