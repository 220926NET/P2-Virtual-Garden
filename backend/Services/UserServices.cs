using Models;
using DataAccess;

namespace Services;
public class UserServices : IServices<User>
{
    IDBAccess<User> _userDatabase;

    public UserServices(IDBAccess<User> userDatabase)
    {
        _userDatabase = userDatabase;
    }

    public User Add(User newUser)
    {
        return _userDatabase.Add(newUser);
    }

    public User GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public User Update(User t)
    {
        throw new NotImplementedException();
    }

    public User Delete(User t)
    {
        throw new NotImplementedException();
    }
}
