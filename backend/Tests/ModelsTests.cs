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
        tile.plant_information = new Plant();
        tile.plant_information.growth_minuets = 0;
        tile.plant_information.id = Guid.NewGuid();
        tile.plant_information.image_path = " lol ";
        tile.plant_information.name = "test ";
        tile.plant_information.state = 0;
        tile.plant_information.worth = 0;
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
        p.image_path = "lol";
        p.state = 0;
        p.name = "place holder name";
        p.growth_minuets = 0;
        p.worth = 0;
        PlantValidator validator = new PlantValidator();
        Assert.NotNull(p);
        Assert.True(validator.isValid(p));
    }

    [Fact]
    public void PlantStateCreated()
    {
        PlantState p = new();
        PlantStateValidator validator = new PlantStateValidator();
        Assert.NotNull(p);
        Assert.False(validator.isValid(p));
    }

    [Fact]
    public void PlantStateValid()
    {
        PlantState p = new();
        p.plant_id = Guid.NewGuid();
        p.state = 0;
        p.image = "who's reading these lol";
        PlantStateValidator validator = new PlantStateValidator();
        Assert.NotNull(p);
        Assert.True(validator.isValid(p));
    }

    [Fact]
    public void FriendRelationshipCreated()
    {
        FriendRelationship p = new();
        FriendRelationshipValidator validator = new FriendRelationshipValidator();
        Assert.NotNull(p);
        Assert.False(validator.isValid(p));
    }

    [Fact]
    public void FriendRelationshipValid()
    {
        FriendRelationship p = new();
        p.username = "me";
        p.friendname = "someone else";
        FriendRelationshipValidator validator = new FriendRelationshipValidator();
        Assert.NotNull(p);
        Assert.True(validator.isValid(p));
    }

    [Fact]
    public void GardenCreated()
    {
        Garden p = new();
        p.tiles.Add(new());
        GardenValidator validator = new GardenValidator();
        Assert.NotNull(p);
        Assert.False(validator.isValid(p));
    }

    [Fact]
    public void GardenValid()
    {
        Garden p = new();
        p.user_id = Guid.NewGuid();
        p.tiles = new List<Tile>();
        Tile tile = new();
        tile.garden_id = Guid.NewGuid();
        tile.position = 0;
        tile.plant_information = new Plant();
        tile.plant_information.growth_minuets = 0;
        tile.plant_information.id = Guid.NewGuid();
        tile.plant_information.image_path = " lol ";
        tile.plant_information.name = "test ";
        tile.plant_information.state = 0;
        tile.plant_information.worth = 0;
        p.tiles.Add(tile);
        GardenValidator validator = new GardenValidator();
        Assert.NotNull(p);
        Assert.True(validator.isValid(p));
    }

    [Fact]
    public void PostToStringReturnsSomething()
    {
        Post p = new();
        Assert.True(!string.IsNullOrEmpty(p.ToString()));
    }

    [Fact]
    public void UserTokenCreated()
    {
        UserToken token = new();
        Assert.NotNull(token);
        Assert.False(new UserTokenValidator().isValid(token));
        token.token = " test ";
        token.expires = DateTime.Now;
        Assert.True(new UserTokenValidator().isValid(token));
    }
}