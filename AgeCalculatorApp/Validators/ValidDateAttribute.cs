﻿using System.ComponentModel.DataAnnotations;
using Input =  AgeCalculatorApp.Layout.MainLayout.Input;

namespace AgeCalculatorApp.Validators
{
    public class ValidDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                return new ValidationResult("This field is required");

            var day = (int) value;

            if (day < 1 || day > 31)
                return new ValidationResult("Must be a valid day");

            Input model = (Input)validationContext.ObjectInstance;

            if (model is null || model.Month is null || model.Year is null)
                return ValidationResult.Success;
            var isValidDate = DateTime.TryParse($"{value}/{model.Month}/{model.Year}", out _);

            var foo = isValidDate ? "valid" : "invalid";
            Console.WriteLine($"Date is {foo}");

            if (!isValidDate)
                return new ValidationResult("Must be a valid date");
            
            return ValidationResult.Success;
        }
    }
}
