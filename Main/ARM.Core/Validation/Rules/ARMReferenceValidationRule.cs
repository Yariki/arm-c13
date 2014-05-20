using ARM.Core.Interfaces;

namespace ARM.Core.Validation.Rules
{
  /// <summary>
  /// Класс-правило для валідації ссилочних типів
  /// </summary>
    public class ARMReferenceValidationRule : ARMValidationRule
    {
      /// <summary>
      /// Валідація зрачення
      /// </summary>
      /// <param name="val">Значення.</param>
      /// <returns></returns>
        protected override IARMValidationResult InternalEvalute(object val)
        {
            var result = new ARMValidationResult() { IsValid = true };
            if (val is string && string.IsNullOrEmpty(val as string))
            {
                result.IsValid = false;
                result.AddMessage("Property sholdn't be equal 'NULL' or be empty.");
                return result;
            }

            if (ReferenceEquals(val, null))
            {
                result.IsValid = false;
                result.AddMessage("Property sholdn't be equal 'NULL'.");
                return result;
            }

            return result;
        }
    }
}