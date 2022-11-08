using Models;
using DataAccess;

namespace Services;

public class FriendServices : IServices<FriendRelationship>
{
    private readonly IDBAccess<FriendRelationship> _friendDatabase;

    public FriendServices(IDBAccessFactory factory)
    {
        _friendDatabase = factory.GetFriendDB();
    }

    public FriendRelationship Add(FriendRelationship t)
    {
        return _friendDatabase.Add(t);
    }

    public FriendRelationship Delete(FriendRelationship t)
    {
        return _friendDatabase.Delete(t);
    }

    public List<FriendRelationship> GetAll()
    {
        return _friendDatabase.GetAll();
    }

    public FriendRelationship GetById(int id)
    {
        throw new NotImplementedException();
    }

    public FriendRelationship GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public FriendRelationship Update(FriendRelationship t)
    {
        throw new NotImplementedException();
    }
}