using Models;

namespace DataAccess;

public class FriendDBAccess : IDBAccess<FriendRelationShip>
{
    private readonly SqlConnectionFactory _connection;

    public FriendDBAccess(SqlConnectionFactory connection)
    {
        this._connection = connection;
    }

    public FriendRelationShip Add(FriendRelationShip t)
    {
        throw new NotImplementedException();
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
