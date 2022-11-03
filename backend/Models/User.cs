namespace Models;

public class User
{
    public Guid id { get; set; } = Guid.NewGuid();
    public string username { get; set; } = string.Empty;
    public byte[] passwordHash { get; set; } = Array.Empty<byte>();
    public byte[] passwordSalt { get; set; } = Array.Empty<byte>();
    
}