using ARM.Core.Interfaces;

namespace ARM.Core.Validation.Rules
{
    public class ARMReferenceValidationRule : ARMValidationRule
    {
        protected override IARMValidationResult InternalEvalute(object val)
        {
            var result = new ARMValidationResult(){IsValid = true};
            if (ReferenceEquals(val, null))
            {
                result.IsValid = false;
                result.AddMessage("Property sholdn't be equal 'NULL'");
            }
            return result;
        }
    }
}