using Models;
using DataAccess;

namespace Services;
public interface IDBAccessFactory
{
    public IDBAccess<User> GetUserDB();
    public IDBAccess<Post> GetPostDB();
    IDBAccess<FriendRelationship> GetFriendDB();
    IDBAccess<Garden> GetGardenDB();
}