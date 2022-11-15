using Microsoft.Data.SqlClient;
using Models;
using Serilog;
namespace DataAccess;

public class FriendDBAccess : IDBAccess<FriendRelationship>
{
    private readonly SqlConnectionFactory _factory;

    public FriendDBAccess(SqlConnectionFactory factory)
    {
        this._factory = factory;
    }

    public FriendRelationship Add(FriendRelationship t)
    {
        FriendRelationship temp = new();
        Guid u = Guid.Empty, f = Guid.Empty;
        try
        {
            using SqlConnection connection = _factory.GetConnection();
            connection.Open();

            SqlCommand cmd = new SqlCommand("select id from Users where username = @u", connection);
            cmd.Parameters.AddWithValue("@u", t.username);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                u = (Guid)reader["id"];
            }
            connection.Close();
            connection.Open();

            cmd = new SqlCommand("select id from Users where username = @f", connection);
            cmd.Parameters.AddWithValue("@f", t.friendname);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                f = (Guid)reader["id"];
            }
            connection.Close();
            connection.Open();

            cmd = new SqlCommand(@"
                insert into Friends (id, userId, friendId) VALUES (@id,@uid,@fid);
                SELECT * from Friends where id = @id;
            ", connection);
            cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@uid", u);
            cmd.Parameters.AddWithValue("@fid", f);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                if (u == (Guid)reader["userId"] && f == (Guid)reader["friendId"])
                {
                    temp = t;
                }
                else
                {
                    Log.Error("Database returned an unexpected friend relationship");
                }
            }
        }
        catch (SqlException e)
        {
            Log.Error(e, "An exception was thrown while register friend relationship");
        }
        return temp;
    }

    public FriendRelationship Delete(FriendRelationship t)
    {
        try
        {
            using SqlConnection connection = _factory.GetConnection();
            connection.Open();
            SqlCommand cmd = new SqlCommand("select id from Users where username = @uid;", connection);
            cmd.Parameters.AddWithValue("@uid", t.username);
            SqlDataReader reader = cmd.ExecuteReader();
            Guid u1 = Guid.Empty;
            if (reader.HasRows)
            {
                reader.Read();
                u1 = (Guid)reader["id"];
            }
            connection.Close();
            connection.Open();

            cmd = new SqlCommand("select id from Users where username = @uid;", connection);
            cmd.Parameters.AddWithValue("@uid", t.friendname);
            reader = cmd.ExecuteReader();
            Guid u2 = Guid.Empty;
            if (reader.HasRows)
            {
                reader.Read();
                u2 = (Guid)reader["id"];
            }

            connection.Close();
            connection.Open();

            cmd = new SqlCommand("delete from Friends where userId = @uid and friendId = @fid;", connection);
            cmd.Parameters.AddWithValue("@uid", u1);
            cmd.Parameters.AddWithValue("@fid", u2);
            cmd.ExecuteNonQuery();
            return t;
        }
        catch (SqlException e)
        {
            Log.Error(e, "An error occured during delete");
        }
        return new();
    }

    public List<FriendRelationship> GetAll()
    {
        List<FriendRelationship> temp = new();

        try
        {
            using SqlConnection connection = _factory.GetConnection();
            connection.Open();
            SqlCommand cmd = new("select * from Friends", connection);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Guid[] arr = new Guid[2];
                    arr[0] = (Guid)reader["userId"];
                    arr[1] = (Guid)reader["friendId"];
                    temp.Add(GetFriend(arr));
                }
            }
        }
        catch (SqlException e)
        {
            Log.Error(e, "Unable to get all relationships");
        }

        return temp;
    }

    private FriendRelationship GetFriend(Guid[] arr)
    {
        FriendRelationship temp = new();
        try
        {
            using SqlConnection connection = _factory.GetConnection();
            connection.Open();
            SqlCommand cmd = new SqlCommand("select username from Users where id = @uid;", connection);
            cmd.Parameters.AddWithValue("@uid", arr[0]);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                temp.username = (string)reader["username"];
            }
            connection.Close();
            connection.Open();

            cmd = new SqlCommand("select username from Users where id = @uid;", connection);
            cmd.Parameters.AddWithValue("@uid", arr[1]);
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                temp.friendname = (string)reader["username"];
            }
        }
        catch (SqlException e)
        {
            Log.Error(e, "Unable to get friend relationship");
        }
        return temp;
    }

    public FriendRelationship GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public FriendRelationship Exists(string username)
    {
        throw new NotImplementedException();
    }

    public FriendRelationship Update(FriendRelationship t)
    {
        throw new NotImplementedException();
    }

    public List<FriendRelationship> GetAllById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Guid GetId(string plantName)
    {
        throw new NotImplementedException();
    }
}
