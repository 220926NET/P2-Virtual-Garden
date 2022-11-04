namespace Models;

public class GardenValidator : IValidate<Garden>
{
    public bool isValid(Garden toCheck)
    {
        TileValidator validator = new TileValidator();
        bool listCheck = true;
        foreach (Tile t in toCheck.tiles)
        {
            if (!validator.isValid(t))
            {
                listCheck = false;
                break;
            }
        }

        return toCheck.user_id != Guid.Empty && listCheck && toCheck.tiles.Count != 0;
    }
}