using System.ComponentModel.DataAnnotations;

namespace AgeCalculatorApp.Validators
{
    public class YearRangeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                return ValidationResult.Success;

            int currentYear = DateTime.Today.Year;
            if (value is int year)
            {
                if (year < 1 || year > currentYear)
                    return new ValidationResult("Must be in the past");
            }

            return ValidationResult.Success;
        }
    }
}
