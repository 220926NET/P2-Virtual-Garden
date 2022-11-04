namespace Models;

public class PlantStateValidator : IValidate<PlantState>
{
    public bool isValid(PlantState toCheck)
    {
        return !string.IsNullOrEmpty(toCheck.image) && toCheck.plant_id != Guid.Empty && toCheck.state != -1;
    }
}