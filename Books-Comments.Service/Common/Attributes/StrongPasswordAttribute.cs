using Books_Comments.Service.Common.Validations;
using System.ComponentModel.DataAnnotations;

namespace Books_Comments.Service.Common.Attributes;

public class StrongPasswordAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null) return new ValidationResult("Parol majburiy!");
        else
        {
            string password = value.ToString()!;
            if (password.Length < 8)
                return new ValidationResult("Parolda kamida 8 ta belgidan iborat bolishi kerak");
            else if (password.Length > 50)
                return new ValidationResult("Parolda kopida 50 ta belgidan iborat bolishi kerak");
            var result = PasswordValidators.IsStrong(password);

            if (result.IsValid is false) return new ValidationResult(result.Message);
            return ValidationResult.Success;
        }
    }
}
