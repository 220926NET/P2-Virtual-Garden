using Models;
using Services;
using DataAccess;
using Moq;

namespace Tests;

public class ServiceTests
{
    [Fact]
    public void UserServiceTest()
    {
        UserDto test = new UserDto { username = "test", password = "test" };

        List<User> users = new List<User>();

        var repo = new Mock<IDBAccess<User>>();
        repo.Setup(repo => repo.GetAll()).Returns(users);
        repo.Setup(repo => repo.Add(It.IsAny<User>())).Returns((User usr) => usr);

        var factory = new Mock<IDBAccessFactory>();
        factory.Setup(factory => factory.GetUserDB()).Returns(repo.Object);

        UserServices service = new UserServices(factory.Object);
        User temp = service.Add(test);
        Assert.True(new UserValidator().isValid(temp));
        users.Add(temp);

        User temp2 = service.Add(test);
        Assert.False(new UserValidator().isValid(temp2));

        User t3 = service.Login(test);
        Assert.True(new UserValidator().isValid(t3));

        Assert.Throws<NotImplementedException>(() => service.GetById(0));
        Assert.Throws<NotImplementedException>(() => service.Update(test));
        Assert.Throws<NotImplementedException>(() => service.Delete(test));
    }
}