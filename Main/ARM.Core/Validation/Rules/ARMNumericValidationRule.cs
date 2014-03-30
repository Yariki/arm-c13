///////////////////////////////////////////////////////////
//  ARMNumericValidationRule.cs
//  Implementation of the Class ARMNumericValidationRule
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 4:59:43 PM
///////////////////////////////////////////////////////////

namespace ARM.Core.Validation.Rules
{
    public abstract class ARMNumericValidationRule : ARMValidationRule
    {
        public ARMNumericValidationRule()
        {
        }

        ~ARMNumericValidationRule()
        {
        }

        ///
        /// <param name="min"></param>
        /// <param name="max"></param>
        protected ARMNumericValidationRule(decimal min, decimal max)
        {
        }

        protected decimal Max
        {
            get;
            set;
        }

        protected decimal Min
        {
            get;
            set;
        }
    }//end ARMNumericValidationRule
}//end namespace Rules