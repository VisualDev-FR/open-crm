using System;
using System.ComponentModel.DataAnnotations;

namespace OpenCRM.Attributes.Validation;

public class PasswordAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        return ValidationResult.Success;
    }
}