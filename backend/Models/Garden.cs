namespace Models;

public class Garden
{
    public Guid id { get; set; } = Guid.NewGuid();
    public Guid user_id { get; set; } = Guid.Empty;
    public List<Tile> tiles { get; set; } = new List<Tile>();
}