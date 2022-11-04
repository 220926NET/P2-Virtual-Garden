namespace Models;

public class GardenValidator : IValidate<Garden>
{
    public bool isValid(Garden toCheck)
    {
        return toCheck.user_id != Guid.Empty;
    }
}