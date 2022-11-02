using Microsoft.Data.SqlClient;
using Models;
using Serilog;
namespace DataAccess;

public class FriendDBAccess : IDBAccess<FriendRelationShip>
{
    private readonly SqlConnectionFactory _factory;

    public FriendDBAccess(SqlConnectionFactory factory)
    {
        this._factory = factory;
    }

    public FriendRelationShip Add(FriendRelationShip t)
    {
        FriendRelationShip temp = new();
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

    public FriendRelationShip Delete(FriendRelationShip t)
    {
        throw new NotImplementedException();
    }

    public List<FriendRelationShip> GetAll()
    {
        throw new NotImplementedException();
    }

    public FriendRelationShip GetById(int id)
    {
        throw new NotImplementedException();
    }

    public FriendRelationShip Update(FriendRelationShip t)
    {
        throw new NotImplementedException();
    }
}
