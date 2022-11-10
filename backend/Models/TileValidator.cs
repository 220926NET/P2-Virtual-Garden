namespace Models;

public class TileValidator : IValidate<Tile>
{
    public bool isValid(Tile toCheck)
    {
        return toCheck.garden_id != Guid.Empty && toCheck.id != Guid.Empty && new PlantValidator().isValid(toCheck.plant_information) && toCheck.position != -1;
    }
}