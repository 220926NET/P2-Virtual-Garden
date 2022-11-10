namespace Models;

public class Tile
{
    public Guid id { get; set; } = Guid.NewGuid();
    public Guid garden_id { get; set; } = Guid.Empty;
    public int position { get; set; } = -1;
    public Plant plant_information { get; set; } = new();
    public DateTime plant_time { get; set; } = DateTime.Now;
    public DateTime ground_time { get; set; } = DateTime.Now;
}