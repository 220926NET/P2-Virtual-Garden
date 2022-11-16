using Microsoft.Data.SqlClient;
using Microsoft.Azure; //Namespace for CloudConfigurationManager



namespace DataAccess;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;
    public SqlConnectionFactory(string connString){
        _connectionString = connString;
    }

    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}

