namespace Books_Comments.Service.Common.Validations;

public class PasswordValidators
{
    public static (bool IsValid, string Message) IsStrong(string password)
    {
        bool isDigit = password.Any(x => char.IsDigit(x));
        bool isLower = password.Any(x => char.IsLower(x));
        bool isUpper = password.Any(x => char.IsUpper(x));
        if (!isLower)
            return (IsValid: false, Message: "Parolda 1 ta kichik harf bolishi kerak!");
        if (!isUpper)
            return (IsValid: false, Message: "Parolda 1 ta katta harf bolishi kerak!");
        if (!isDigit)
            return (IsValid: false, Message: "Parolda 1 ta raqam bolishi kerak!");

        return (IsValid: true, Message: "Password is strong");
    }
}
