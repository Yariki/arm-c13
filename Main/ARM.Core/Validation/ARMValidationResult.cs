﻿///////////////////////////////////////////////////////////
//  ARMValidationResult.cs
//  Implementation of the Class ARMValidationResult
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 4:59:44 PM
///////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Linq;
using ARM.Core.Interfaces;

namespace ARM.Core.Validation
{
  /// <summary>
  /// Класс, який представляє собою результат валідації
  /// </summary>
    public class ARMValidationResult : IARMValidationResult
    {
        private readonly IList<string> _listMessage = new List<string>();


        /// <summary>
        /// Додати повідомлення валідації
        /// </summary>
        /// <param name="mes">Повідомлення.</param>
        public void AddMessage(string mes)
        {
            _listMessage.Add(mes);
        }

        /// <summary>
        /// Очистати список повідомлень
        /// </summary>
        public void ClearMessages()
        {
            _listMessage.Clear();
        }

        /// <summary>
        /// Встановити або повернути стан валідації
        /// </summary>
        /// <value>
        ///   <c>true</c> якщо валідно; інакше, <c>false</c>.
        /// </value>
        public bool IsValid
        {
            get;
            set;
        }

        /// <summary>
        /// Поветнути всі повідомлення валідації
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetErrors()
        {
            return _listMessage.AsEnumerable();
        }
    }//end ARMValidationResult
}//end namespace Validation