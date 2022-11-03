namespace Models.Validation;

public class TileValidatior : IValidate<Tile>
{
    public bool isValid(Tile toCheck)
    {
        return toCheck.garden_id != Guid.Empty && toCheck.id != Guid.Empty && toCheck.plant_id != Guid.Empty && toCheck.position != -1;
    }
}