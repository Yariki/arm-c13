﻿///////////////////////////////////////////////////////////
//  IARMValidatableViewModel.cs
//  Implementation of the Interface IARMValidatableViewModel
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 4:59:44 PM
///////////////////////////////////////////////////////////

using System.ComponentModel;

namespace ARM.Core.Interfaces
{
  /// <summary>
  /// Інтерфейс для моделі предатсвлення, яка проводить валідацію моделі даних
  /// </summary>
    public interface IARMValidatableViewModel : IARMDataViewModel, IDataErrorInfo
    {
      /// <summary>
      /// Повертає або встановлює чи модель є валідна
      /// </summary>
      /// <value>
      ///   <c>true</c> якщо обєкт валідний; інакше, <c>false</c>.
      /// </value>
        bool IsValid { get; set; }
    }//end IARMValidatableViewModel
}//end namespace Interfaces