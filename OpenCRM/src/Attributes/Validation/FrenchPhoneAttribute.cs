using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace OpenCRM.Attributes.Validation;

public class FrenchPhoneAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
            return ValidationResult.Success;

        if (value is string phone && Regex.IsMatch(phone, @"^(\+33|0)[1-9]\d{8}$"))
            return ValidationResult.Success;

        return new ValidationResult("Invalid French phone number");
    }
}