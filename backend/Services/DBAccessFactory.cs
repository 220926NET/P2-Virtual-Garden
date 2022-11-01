using Models;
using DataAccess;

namespace Services;

public class DBAccessFactory : IDBAccessFactory
{
    private readonly SqlConnectionFactory _connection = new SqlConnectionFactory();

    public IDBAccess<FriendRelationShip> getFriendDB()
    {
        return new FriendDBAccess(_connection);
    }

    public IDBAccess<Post> getPostDB()
    {
        return new PostDBAccess(_connection);
    }

    public IDBAccess<User> GetUserDB()
    {
        return new UserDBAccess(_connection);
    }
}