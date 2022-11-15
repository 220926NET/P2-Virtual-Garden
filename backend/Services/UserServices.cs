using Models;
using DataAccess;
using System.Security.Cryptography;

namespace Services;
public class UserServices : IUserServices
{
    private readonly IDBAccess<User> _userDatabase;

    public UserServices(IDBAccessFactory factory)
    {
        _userDatabase = factory.GetUserDB();
    }

    public User Add(UserDto user)
    {
        bool usernameExists = false;
        List<User> users = GetAll();

        foreach (User previousUser in users)
        {
            if (user.username == previousUser.username)
            {
                usernameExists = true;
                break;
            }
        }

        User newUser = new User();

        if (!usernameExists)
        {
            CreatePasswordHash(user.password, out byte[] newPasswordHash, out byte[] newPasswordSalt);

            newUser.username = user.username;
            newUser.passwordHash = newPasswordHash;
            newUser.passwordSalt = newPasswordSalt;
            
        }

        return _userDatabase.Add(newUser);
    }

    public User Exists(string username)
    {
        return _userDatabase.Exists(username);
    }
    public User GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<User> GetAll()
    {
        return _userDatabase.GetAll();
    }

    public User Update(UserDto user)
    {
        throw new NotImplementedException();
    }

    public User Delete(UserDto user)
    {
        throw new NotImplementedException();
    }

    public User Login(UserDto loginUser)
    {
        List<User> users = GetAll();

        foreach (User user in users)
        {
            if (loginUser.username == user.username && VerifyPasswordHash(loginUser.password, user.passwordHash, user.passwordSalt)) return user;
        }

        return new User();
    }

    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (HMACSHA512 hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (HMACSHA512 hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }

}
