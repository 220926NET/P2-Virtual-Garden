namespace Models;

public class UserValidator : IValidate<User>
{
    public bool isValid(User toCheck)
    {
        return !string.IsNullOrEmpty(toCheck.username);
    }
}