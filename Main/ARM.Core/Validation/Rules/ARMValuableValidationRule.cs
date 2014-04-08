using ARM.Core.Interfaces;

namespace ARM.Core.Validation.Rules
{
    public class ARMValuableValidationRule : ARMValidationRule
    {
        protected override IARMValidationResult InternalEvalute(object val)
        {
            var result = new ARMValidationResult() { IsValid = true };

            if (val is int && ((int)val) < 0)
            {
                result.IsValid = false;
                result.AddMessage("Property 'int' should be equal or greater then '0'.");
                return result;
            }
            if (val is uint && (uint) val < 0)
            {
                result.IsValid = false;
                result.AddMessage("Property 'uint' should be equal or greater then '0'.");
                return result;
            }
            if (val is double && (double) val < 0.0)
            {
                result.IsValid = false;
                result.AddMessage("Property 'double' should be equal or greater then '0.0'.");
                return result;
            }
            if (val is float && (float) val < 0.0f)
            {
                result.IsValid = false;
                result.AddMessage("Property 'float' should be equal or greater then '0.0f'.");
                return result;
            }
            if (val is decimal && (decimal)val < 0)
            {
                result.IsValid = false;
                result.AddMessage("Property 'decimal' should be equal or greater then '0'.");
                return result;
            }


            return result;
        }
    }
}