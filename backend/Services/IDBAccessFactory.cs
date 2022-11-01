using Models;
using DataAccess;

namespace Services;
public interface IDBAccessFactory
{
    public IDBAccess<User> GetUserDB();
    public IDBAccess<Post> getPostDB();
    IDBAccess<FriendRelationShip> getFriendDB();
}