using Models;
using DataAccess;

namespace Services;

public class FriendServices : IServices<FriendRelationship>
{
    private readonly IDBAccess<FriendRelationship> _friendDatabase;

    public FriendServices(IDBAccessFactory factory)
    {
        _friendDatabase = factory.getFriendDB();
    }

    public FriendRelationship Add(FriendRelationship t)
    {
        return _friendDatabase.Add(t);
    }

    public FriendRelationship Delete(FriendRelationship t)
    {
        throw new NotImplementedException();
    }

    public List<FriendRelationship> GetAll()
    {
        throw new NotImplementedException();
    }

    public FriendRelationship GetById(int id)
    {
        throw new NotImplementedException();
    }

    public FriendRelationship Update(FriendRelationship t)
    {
        throw new NotImplementedException();
    }
}