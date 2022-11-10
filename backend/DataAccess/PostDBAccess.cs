using Microsoft.Data.SqlClient;
using Models;
using Serilog;

namespace DataAccess;

public class PostDBAccess : IDBAccess<Post>
{
    private readonly SqlConnectionFactory _factory;

    public PostDBAccess(SqlConnectionFactory factory)
    {
        _factory = factory;
    }

    public Post Add(Post t)
    {
        Post temp = new Post();

        try
        {
            using SqlConnection connection = _factory.GetConnection();
            connection.Open();

            SqlCommand cmd = new SqlCommand(@"
                insert into Posts (id,senderId,receiverId,text,time) 
                    values (@id,@uid,@rid,@text,@time); 
                select * from Posts where id = @id;", connection);
            cmd.Parameters.AddWithValue("@id", temp.id);
            cmd.Parameters.AddWithValue("@uid", t.sender_id);
            cmd.Parameters.AddWithValue("@rid", t.reciver_id);
            cmd.Parameters.AddWithValue("@text", t.text);
            cmd.Parameters.AddWithValue("@time", temp.time);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                temp.sender_id = (Guid)reader["senderId"];
                temp.reciver_id = (Guid)reader["receiverId"];
                temp.text = (string)reader["text"];
            }
        }
        catch (SqlException e)
        {
            Log.Error(e, "An exception was thrown while adding the post");
        }
        return temp;
    }

    public Post Delete(Post t)
    {
        throw new NotImplementedException();
    }

    public List<Post> GetAllById(Guid id)
    {
        List<Post> posts = new List<Post>();
        try
        {
            using SqlConnection connection = _factory.GetConnection();
            connection.Open();

            SqlCommand cmd = new SqlCommand(@"
                SELECT senderId, [text], [time], u.username
                FROM Posts p
                JOIN Users u ON u.id = p.receiverId
                WHERE receiverId = @id
                ORDER BY [time] DESC", connection);
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read()){
                    Post post = new Post();
                    
                    post.text = (string)reader["text"];
                    post.time = (DateTime)reader["time"];
                    post.sender_name = (string)reader["username"];
                    
                    posts.Add(post);
                }
            }
        }
        catch (SqlException e)
        {
            Log.Error(e, "An exception was thrown while adding the post");
        }
        return posts;
        
    }

    public List<Post> GetAll()
    {
        throw new NotImplementedException();
    }

    public Post GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Post Update(Post t)
    {
        throw new NotImplementedException();
    }
}