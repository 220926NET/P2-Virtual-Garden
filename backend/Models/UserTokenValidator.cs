namespace Models;

public class UserTokenValidator : IValidate<UserToken>
{
    public bool isValid(UserToken toCheck)
    {
        return !string.IsNullOrEmpty(toCheck.token) && toCheck.expires != DateTime.MinValue;
    }
}