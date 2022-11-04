using Models;

namespace Tests;

public class ModelsTests
{
    [Fact]
    public void UserCreated()
    {
        User usr = new();
        UserValidator validator = new UserValidator();
        Assert.NotNull(usr);
        Assert.False(validator.isValid(usr));
    }

    [Fact]
    public void UserValid()
    {
        User usr = new();
        usr.username = "test name";
        UserValidator validator = new UserValidator();
        Assert.NotNull(usr);
        Assert.True(validator.isValid(usr));
    }

    [Fact]
    public void TileCreated()
    {
        Tile tile = new();
        TileValidator validator = new TileValidator();
        Assert.NotNull(tile);
        Assert.False(validator.isValid(tile));
    }

    [Fact]
    public void TileValid()
    {
        Tile tile = new();
        tile.garden_id = Guid.NewGuid();
        tile.position = 0;
        tile.plant_id = Guid.NewGuid();
        TileValidator validator = new TileValidator();
        Assert.NotNull(tile);
        Assert.True(validator.isValid(tile));
    }
}