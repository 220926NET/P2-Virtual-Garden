namespace Models;

public class PlantValidator : IValidate<Plant>
{
    public bool isValid(Plant toCheck)
    {
        return !string.IsNullOrEmpty(toCheck.image_path) && !string.IsNullOrEmpty(toCheck.name) && toCheck.growth_minuets != -1 && toCheck.worth != -1 && toCheck.id != Guid.Empty;
    }
}