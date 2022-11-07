namespace Models;

public class PlantState
{
    public Guid plant_id { get; set; } = Guid.Empty;
    public int state { get; set; } = -1;
    public string image { get; set; } = "";
}