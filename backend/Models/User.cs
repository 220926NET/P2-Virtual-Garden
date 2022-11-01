namespace Models;

public class User
{
    public Guid id { get; set; } = Guid.NewGuid();
    public string username { get; set; } = "";
    public string password { get; set; } = "";
}