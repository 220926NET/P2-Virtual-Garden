namespace Models;

public class Tile
{
    public Guid id { get; set; } = Guid.NewGuid();
    public Guid garden_id { get; set; }
    public int position { get; set; }
    public Guid plant_id { get; set; }
    public DateTime plant_time { get; set; }
    public DateTime ground_time { get; set; }
}