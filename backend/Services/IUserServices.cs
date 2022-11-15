using Models;

namespace Services;

public interface IUserServices
{
    User Login(UserDto user);
    User Add(UserDto user);
    User GetById(int id);
    User Exists(string username);
    List<User> GetAll();
    User Update(UserDto user);
    User Delete(UserDto user);
}