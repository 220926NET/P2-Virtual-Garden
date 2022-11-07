namespace Models;

public class TileValidator : IValidate<Tile>
{
    public bool isValid(Tile toCheck)
    {
        return toCheck.garden_id != Guid.Empty && toCheck.id != Guid.Empty && toCheck.plant_id != Guid.Empty && toCheck.position != -1;
    }
}