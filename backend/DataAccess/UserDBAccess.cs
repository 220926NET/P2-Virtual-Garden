using Microsoft.Data.SqlClient;
using Models;
using Serilog;

namespace DataAccess;
public class UserDBAccess : IDBAccess<User>
{
    private readonly SqlConnectionFactory _factory;

    public UserDBAccess(SqlConnectionFactory factory)
    {
        _factory = factory;
    }

    public User Add(User newUser)
    {
        User returnUser = new User();

        try
        {
            using SqlConnection connection = _factory.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand(@"INSERT INTO Users (id, username, passwordHash, passwordSalt) 
            VALUES (@id, @username, @passwordHash, @passwordSalt); 
            SELECT * FROM Users WHERE id = @id", connection);
            command.Parameters.AddWithValue("@id", newUser.id);
            command.Parameters.AddWithValue("@username", newUser.username);
            command.Parameters.AddWithValue("@passwordHash", newUser.passwordHash);
            command.Parameters.AddWithValue("@passwordSalt", newUser.passwordSalt);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                returnUser.id = (Guid)reader["id"];
                returnUser.username = (string)reader["username"];
                returnUser.passwordHash = (byte[])reader["passwordHash"];
                returnUser.passwordSalt = (byte[])reader["passwordSalt"];

            }

        }
        catch (SqlException e)
        {
            Log.Error(e, "An execption was thrown while adding the User.");
        }

        return returnUser;
    }

    public List<User> GetAll()
    {
        List<User> users = new List<User>();

        try
        {
            using SqlConnection connection = _factory.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand(@"SELECT * FROM Users;", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User user = new User();
                    user.id = (Guid)reader["id"];
                    user.username = (string)reader["username"];
                    user.passwordHash = (byte[])reader["passwordHash"];
                    user.passwordSalt = (byte[])reader["passwordSalt"];

                    users.Add(user);
                }
            }

        }
        catch (SqlException e)
        {
            Log.Error(e, "An execption was thrown while retrieving all Users.");
        }

        return users;
    }
    public User Exists(string username){
        User user = new User();

        try
        {
            using SqlConnection connection = _factory.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE username = @username;", connection);
            command.Parameters.AddWithValue("@username", username);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                user.username = (string)reader["username"];
            }
        }
        catch (SqlException e)
        {
            Log.Error(e, "An exception was thrown while verifying user.");
        }

        return user;
    }
    public User GetById(Guid id)
    {
        throw new NotImplementedException();
    }
    public List<User> GetAllById(Guid id)
    {
        throw new NotImplementedException();
    }

    public User Update(User t)
    {
        throw new NotImplementedException();
    }

    public User Delete(User t)
    {
        throw new NotImplementedException();
    }

     public Guid GetId(string userName)
    {
        try
        {
            using SqlConnection connection = _factory.GetConnection();
            connection.Open();
            SqlCommand cmd = new SqlCommand("select id from Users where [username] = @name;", connection);
            cmd.Parameters.AddWithValue("@name", userName);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows) if (reader.Read()) return (Guid)reader["id"];
        }
        catch (SqlException e)
        {
            Log.Error(e, "An exception was thrown while getting the plant's Guid");
        }
        return Guid.Empty;
    }
}