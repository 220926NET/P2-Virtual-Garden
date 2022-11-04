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
    public void PostCreated()
    {
        Post p = new();
        PostValidator validator = new PostValidator();
        Assert.NotNull(p);
        Assert.False(validator.isValid(p));
    }

    [Fact]
    public void PostValid()
    {
        Post p = new();
        p.sender_id = Guid.NewGuid();
        p.reciver_id = Guid.NewGuid();
        p.text = "some text";
        PostValidator validator = new PostValidator();
        Assert.NotNull(p);
        Assert.True(validator.isValid(p));
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

    [Fact]
    public void PlantCreated()
    {
        Plant p = new();
        PlantValidator validator = new PlantValidator();
        Assert.NotNull(p);
        Assert.False(validator.isValid(p));
    }

    [Fact]
    public void PlantValid()
    {
        Plant p = new();
        p.name = "place holder name";
        p.growth_minuets = 0;
        p.worth = 0;
        PlantValidator validator = new PlantValidator();
        Assert.NotNull(p);
        Assert.True(validator.isValid(p));
    }
}