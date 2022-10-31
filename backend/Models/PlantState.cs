namespace Models;

public class PlantState
{
    public Guid plant_id { get; set; }
    public int state { get; set; }
    public string image { get; set; } = "";
}