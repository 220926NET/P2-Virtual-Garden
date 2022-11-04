namespace Models.Validation;

public class UserValidatior : IValidate<User>
{
    public bool isValid(User toCheck)
    {
        return !string.IsNullOrEmpty(toCheck.username);
    }
}