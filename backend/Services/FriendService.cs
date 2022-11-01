using Models;
using DataAccess;

namespace Services;

public class FriendServices : IServices<FriendRelationShip>
{
    private readonly IDBAccess<FriendRelationShip> _friendDatabase;

    public FriendServices(IDBAccessFactory factory)
    {
        _friendDatabase = factory.getFriendDB();
    }

    public FriendRelationShip Add(FriendRelationShip t)
    {
        return _friendDatabase.Add(t);
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