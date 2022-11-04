using Models;
using DataAccess;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Services;
public class UserServices : IUserServices
{
    IDBAccess<User> _userDatabase;

    public UserServices(IDBAccessFactory factory)
    {
        _userDatabase = factory.GetUserDB();
    }

    public User Add(UserDto registerUser)
    {
        bool usernameExists = false;
        List<User> users = GetAll();

        foreach (User user in users)
        {
            if (registerUser.username == user.username)
            {
                usernameExists = true;
                break;
            }
        }

        User newUser = new User();

        if (!usernameExists)
        {
            CreatePasswordHash(registerUser.password, out byte[] newPasswordHash, out byte[] newPasswordSalt);

            newUser.username = registerUser.username;
            newUser.passwordHash = newPasswordHash;
            newUser.passwordSalt = newPasswordSalt;
            
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

    public User Update(UserDto t)
    {
        throw new NotImplementedException();
    }

    public User Delete(UserDto t)
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

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (HMACSHA512 hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (HMACSHA512 hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }

    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim> 
        {
            new Claim(ClaimTypes.Name, user.username)
        };

        SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(""));
        
        return "";
    }

}
