using Models;
using DataAccess;

namespace Services;

public class DBAccessFactory : IDBAccessFactory
{
    private readonly SqlConnectionFactory _connection = new SqlConnectionFactory();

    public IDBAccess<User> GetUserDB()
    {
        return new UserDBAccess(_connection);
    }
}