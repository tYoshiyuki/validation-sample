using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ValidationSample.Attributes
{
    public class AlphaNumericAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Regex.IsMatch(value?.ToString(), @"[^a-zA-z0-9]"))
            {
                return new ValidationResult(this.ErrorMessage ?? $"{ validationContext.DisplayName }は英数字で入力してください。");
            }

            return ValidationResult.Success;
        }
    }
}
