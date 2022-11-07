namespace Models;

public class Plant
{
    public Guid id { get; set; } = Guid.NewGuid();
    public string name { get; set; } = "";
    public int growth_minuets { get; set; } = -1;
    public int worth { get; set; } = -1;
}