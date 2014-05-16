﻿///////////////////////////////////////////////////////////
//  ARMRangeValidationRule.cs
//  Implementation of the Class ARMRangeValidationRule
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 4:59:43 PM
///////////////////////////////////////////////////////////

using System;
using ARM.Core.Attributes;

namespace ARM.Core.Validation.Rules
{
  /// <summary>
  /// Класс-правило для валідації входження знаяення в певний діапазон значень
  /// </summary>
    public class ARMRangeValidationRule : ARMNumericValidationRule
    {

      /// <summary>
      /// Ініціалізує новий екземпляр класу <see cref="ARMRangeValidationRule"/>.
      /// </summary>
      /// <param name="min">Мінімальна границя.</param>
      /// <param name="max">Максимальна границя.</param>
        public ARMRangeValidationRule(double min, double max) : base(min,max)
        {
        }

        /// <summary>
        /// Валідація значення
        /// </summary>
        /// <param name="val">Значення.</param>
        /// <returns></returns>
        protected override ARM.Core.Interfaces.IARMValidationResult InternalEvalute(object val)
        {
            var result = new ARMValidationResult() { IsValid = true };
            if (val != null)
            {

                double v = Convert.ToDouble(val);
                result.IsValid = Min < v &&  v < Max;
                if (!result.IsValid)
                {
                    result.AddMessage(string.Format("Value shouldn't be beetwen {0} - {1}.",Min,Max));
                }
            }
            return result;
        }
    }//end ARMRangeValidationRule
}//end namespace Rules