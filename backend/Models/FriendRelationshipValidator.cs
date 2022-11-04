namespace Models;

public class FriendRealationshipValidator : IValidate<FriendRelationship>
{
    public bool isValid(FriendRelationship toCheck)
    {
        return !string.IsNullOrEmpty(toCheck.username) && !string.IsNullOrEmpty(toCheck.username);
    }
}