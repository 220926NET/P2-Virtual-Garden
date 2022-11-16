using Models;
using DataAccess;

namespace Services;

public class DBAccessFactory : IDBAccessFactory
{
    private readonly SqlConnectionFactory _connection;

    public DBAccessFactory(string connString){
        _connection= new SqlConnectionFactory(connString);

    }
    public IDBAccess<FriendRelationship> GetFriendDB()
    {
        return new FriendDBAccess(_connection);
    }

    public IDBAccess<Garden> GetGardenDB()
    {
        return new GardenDBAccess(_connection);
    }

    public IDBAccess<Post> GetPostDB()
    {
        return new PostDBAccess(_connection);
    }

    public IDBAccess<User> GetUserDB()
    {
        return new UserDBAccess(_connection);
    }
}