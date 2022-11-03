namespace Models.Validation;

public class FriendRealationshipValidatior : IValidate<FriendRelationship>
{
    public bool isValid(FriendRelationship toCheck)
    {
        return !string.IsNullOrEmpty(toCheck.username) && !string.IsNullOrEmpty(toCheck.username);
    }
}