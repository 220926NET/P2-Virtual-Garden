using Models;
using DataAccess;

namespace Services;
public class UserServices : IUserServices
{
    IDBAccess<User> _userDatabase;

    public UserServices(IDBAccessFactory factory)
    {
        _userDatabase = factory.GetUserDB();
    }

    public User Add(User newUser)
    {
        List<User> users = GetAll();

        foreach (User user in users)
        {
            if (newUser.username == user.username)
            {
                newUser.username = null;
                newUser.password = null;
                return newUser;
            }
        }
        return _userDatabase.Add(newUser);
    }

    public User GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<User> GetAll()
    {
        return _userDatabase.GetAll();
    }

    public User Update(User t)
    {
        throw new NotImplementedException();
    }

    public User Delete(User t)
    {
        throw new NotImplementedException();
    }

    public User Login(User loginUser)
    {
        List<User> users = GetAll();

        foreach (User user in users)
        {
            if (loginUser.username == user.username && loginUser.password == user.password) return user;
        }

        return loginUser;
    }
}
