namespace Models;

public class Post
{
    public Guid id { get; set; } = Guid.NewGuid();
    public Guid sender_id { get; set; }
    public Guid reciver_id { get; set; }
    public string text { get; set; } = "";
    public DateTime time { get; set; } = DateTime.Now;
}