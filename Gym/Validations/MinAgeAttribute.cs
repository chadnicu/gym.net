using System.ComponentModel.DataAnnotations;

namespace Gym.Validations
{
    public class MinAgeAttribute:ValidationAttribute
    {
            private readonly int _minAge;

            public MinAgeAttribute(int minAge)
            {
                _minAge = minAge;
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is DateTime birthDate)
                {
                    var age = DateTime.Now.Year - birthDate.Year;

                    if (birthDate > DateTime.Now.AddYears(-age))
                    {
                        age--;
                    }

                    if (age >= _minAge)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult($"You must be at least {_minAge} years old.");
                    }
                }

                return new ValidationResult("Invalid date format.");
        }

    }
}
