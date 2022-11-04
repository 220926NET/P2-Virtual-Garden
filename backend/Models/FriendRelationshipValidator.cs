namespace Models;

public class FriendRelationshipValidator : IValidate<FriendRelationship>
{
    public bool isValid(FriendRelationship toCheck)
    {
        return !string.IsNullOrEmpty(toCheck.username) && !string.IsNullOrEmpty(toCheck.friendname);
    }
}