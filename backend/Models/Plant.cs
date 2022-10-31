namespace Models;

public class Plant
{
    public Guid id { get; set; }
    public string name { get; set; } = "";
    public int growth_minuets { get; set; }
    public int worth { get; set; }
}