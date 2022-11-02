using Models;

namespace Services;

public interface IUserServices : IServices<User>
{
    User Login(User user);
}