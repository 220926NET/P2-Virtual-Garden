namespace Models;

public class Post
{
    public Guid id { get; set; } = Guid.NewGuid();
    public Guid sender_id { get; set; } = Guid.Empty;
    public Guid reciver_id { get; set; } = Guid.Empty;
    public string text { get; set; } = "";
    public DateTime time { get; set; } = DateTime.Now;

    public override string ToString()
    {
        return $"id :{id}, sender id: {sender_id}, receiver id: {reciver_id}, text: {text}, time: {time.ToUniversalTime()}";
    }
}