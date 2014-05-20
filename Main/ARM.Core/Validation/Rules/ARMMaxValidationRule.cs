﻿///////////////////////////////////////////////////////////
//  ARMMaxValidationRule.cs
//  Implementation of the Class ARMMaxValidationRule
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 4:59:42 PM
///////////////////////////////////////////////////////////

using System;

namespace ARM.Core.Validation.Rules
{
  /// <summary>
  /// Класс-правило для валідації числових значень
  /// </summary>
    public class ARMMaxValidationRule : ARMNumericValidationRule
    {
      /// <summary>
      /// Ініціалізує новий екземпляр класу <see cref="ARMMaxValidationRule"/>.
      /// </summary>
        public ARMMaxValidationRule()
        {
        }

        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="ARMMaxValidationRule"/>.
        /// </summary>
        /// <param name="min">Максимальне границя</param>
        /// <param name="max">Мінімальна границя</param>
        public ARMMaxValidationRule(double min, double max) : base(min,max)
        {
        }

        /// <summary>
        /// Валідація значення.
        /// </summary>
        /// <param name="val">Значення для валідації.</param>
        /// <returns></returns>
        protected override ARM.Core.Interfaces.IARMValidationResult InternalEvalute(object val)
        {
            var result = new ARMValidationResult() {IsValid = true};
            if (val != null)
            {
                double v = Convert.ToDouble(val);
                result.IsValid = v < Max;
                if (!result.IsValid)
                {
                    result.AddMessage(string.Format("Value shouldn't be greater {0}.",Max));
                }
            }
            return result;
        }
    }//end ARMMaxValidationRule
}//end namespace Rules