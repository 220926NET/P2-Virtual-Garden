namespace Models.Validation;

public class PlantValidatior : IValidate<Plant>
{
    public bool isValid(Plant toCheck)
    {
        return !string.IsNullOrEmpty(toCheck.name) && toCheck.growth_minuets != -1 && toCheck.worth != -1 && toCheck.id != Guid.Empty;
    }
}