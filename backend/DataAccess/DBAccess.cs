using Microsoft.Data.SqlClient;

namespace DataAccess;
public class DBAccess
{
    private SqlConnectionFactory _factory;

    public DBAccess(SqlConnectionFactory factory)
    {
        _factory = factory;
    }

    public void Add(Guid id, string username, string password)
    {
        try
        {
            using SqlConnection connection = _factory.GetConnection();
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Users (id, username, password) VALUES (@id, @username, @password)", connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            int result = command.ExecuteNonQuery();
        }
        catch (SqlException)
        {
            Console.WriteLine("Something went wrong connecting to the DB...");
        }
    }
}
