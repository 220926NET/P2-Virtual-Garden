using Microsoft.Data.SqlClient;
using Models;
using Serilog;

namespace DataAccess;
public class UserDBAccess : IDBAccess<User>
{
    private SqlConnectionFactory _factory;

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

            SqlCommand command = new SqlCommand(@"INSERT INTO Users (id, username, password) 
            VALUES (@id, @username, @password); 
            SELECT * FROM Users WHERE id = @id", connection);
            command.Parameters.AddWithValue("@id", newUser.id);
            command.Parameters.AddWithValue("@username", newUser.username);
            command.Parameters.AddWithValue("@password", newUser.password);

            SqlDataReader reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                reader.Read();
                returnUser.id = (Guid) reader["id"];
                returnUser.username = (string) reader["username"];
                returnUser.password = (string) reader["password"];
                
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

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    User user = new User();
                    user.id = (Guid) reader["id"];
                    user.username = (string) reader["username"];
                    user.password = (string) reader["password"];

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

    public User GetById(int id)
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
}
