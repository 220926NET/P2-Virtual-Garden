namespace Models.Validation;

public class PostValidatior : IValidate<Post>
{
    public bool isValid(Post toCheck)
    {
        return toCheck.id != Guid.Empty && toCheck.reciver_id != Guid.Empty && toCheck.sender_id != Guid.Empty && !string.IsNullOrEmpty(toCheck.text);
    }
}