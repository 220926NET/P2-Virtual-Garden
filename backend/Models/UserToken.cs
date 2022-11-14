namespace Models;

public class UserToken
{
    public string token { get; set; } = "";

    public DateTime expires { get; set; } = DateTime.MinValue;
}