using Models;
using Services;
using DataAccess;
using Moq;

namespace Tests;

public class ServiceTests
{
    [Fact]
    public void SpinUpAllServices()
    {
        List<FriendRelationship> friends = new();
        var fdb = new Mock<IDBAccess<FriendRelationship>>();
        fdb.Setup(fdb => fdb.Add(It.IsAny<FriendRelationship>())).Returns((FriendRelationship r) =>
        {
            friends.Add(r);
            return r;
        });
        fdb.Setup(fdb => fdb.Delete(It.IsAny<FriendRelationship>())).Returns((FriendRelationship r) =>
        {
            friends.Remove(r);
            return r;
        });
        fdb.Setup(fdb => fdb.GetAll()).Returns(() =>
        {
            return friends;
        });

        List<Garden> gardens = new();
        var gdb = new Mock<IDBAccess<Garden>>();
        gdb.Setup(gdb => gdb.Add(It.IsAny<Garden>())).Returns((Garden r) =>
        {
            gardens.Add(r);
            return r;
        });
        gdb.Setup(gdb => gdb.Delete(It.IsAny<Garden>())).Returns((Garden r) =>
        {
            gardens.Remove(r);
            return r;
        });
        gdb.Setup(gdb => gdb.GetById(It.IsAny<Guid>())).Returns((Guid id) =>
        {
            Garden? garden = gardens.Find((Garden g) =>
            {
                return g.user_id == id;
            })!;
            if (garden == null) return new();
            return garden;
        });
        gdb.Setup(gdb => gdb.GetId(It.IsAny<string>())).Returns((string r) =>
        {
            return Guid.NewGuid();
        });
        gdb.Setup(gdb => gdb.Update(It.IsAny<Garden>())).Returns((Garden r) =>
        {
            foreach (Garden g in gardens)
            {
                if (r.user_id == g.user_id)
                {
                    gardens.Remove(g);
                    gardens.Add(r);
                    return r;
                }
            }
            return new();
        });
        List<Post> posts = new();
        var pdb = new Mock<IDBAccess<Post>>();
        pdb.Setup(pdb => pdb.Add(It.IsAny<Post>())).Returns((Post p) =>
        {
            posts.Add(p);
            return p;
        });
        pdb.Setup(pdb => pdb.GetAllById(It.IsAny<Guid>())).Returns((Guid id) =>
        {
            return posts.FindAll((Post p) =>
            {
                return id == p.reciver_id;
            });
        });

        List<User> users = new();
        var udb = new Mock<IDBAccess<User>>();
        udb.Setup(udb => udb.Add(It.IsAny<User>())).Returns((User usr) =>
        {
            users.Add(usr);
            return usr;
        });
        udb.Setup(udb => udb.GetAll()).Returns(users);

        var factory = new Mock<IDBAccessFactory>();
        factory.Setup(factory => factory.GetFriendDB()).Returns(fdb.Object);
        factory.Setup(factory => factory.GetGardenDB()).Returns(gdb.Object);
        factory.Setup(factory => factory.GetPostDB()).Returns(pdb.Object);
        factory.Setup(factory => factory.GetUserDB()).Returns(udb.Object);

        FriendServices fservice = new FriendServices(factory.Object);
        GardenServices gservice = new GardenServices(factory.Object);
        PostServices pservice = new PostServices(factory.Object);
        UserServices uservice = new UserServices(factory.Object);

        UserDto duncanDto = new UserDto { username = "duncan", password = "super secret" },
                rushayDto = new UserDto { username = "rushay", password = "super secret" },
                jallenDto = new UserDto { username = "jallen", password = "super secret" },
                chiDto = new UserDto { username = "Chi", password = "super secret" };

        UserValidator uv = new UserValidator();
        User duncan = uservice.Add(duncanDto);
        Assert.True(uv.isValid(duncan));
        Assert.False(uv.isValid(uservice.Add(duncanDto)));
        User rushay = uservice.Add(rushayDto);
        Assert.True(uv.isValid(rushay));
        User jallen = uservice.Add(jallenDto);
        Assert.True(uv.isValid(jallen));
        User chi = uservice.Add(chiDto);
        Assert.True(uv.isValid(chi));

        Assert.True(uv.isValid(uservice.Login(chiDto)));
        Assert.False(uv.isValid(uservice.Login(new UserDto { username = "jallen", password = "wrong" })));
        Assert.False(uv.isValid(uservice.Login(new UserDto { username = "not rushay", password = rushayDto.password })));
        Assert.False(uv.isValid(uservice.Login(new UserDto { username = "no one", password = "not correct" })));

        pservice.Add(new Post
        {
            id = Guid.NewGuid(),
            sender_id = chi.id,
            reciver_id = rushay.id,
            text = "Hi there",
            sender_name = "chi"
        });
        pservice.Add(new Post
        {
            id = Guid.NewGuid(),
            sender_id = duncan.id,
            reciver_id = rushay.id,
            text = "howdy there",
            sender_name = "duncan"
        });
        // Assert.True(pservice.GetAllById(rushay.id).Count == 0);
        // Assert.True(pservice.GetAllById(chi.id).Count == 1);
        // Assert.True(pservice.GetAllById(duncan.id).Count == 1);

        Garden g = new();
        g.user_id = rushay.id;
        g = gservice.Add(g);
        Assert.Equal(rushay.id, g.user_id);
        g = gservice.Update(g);
        Assert.Equal(rushay.id, g.user_id);
        g = gservice.GetById(rushay.id);
        Assert.Equal(rushay.id, g.user_id);
        g = gservice.Delete(g);
        Assert.Equal(rushay.id, g.user_id);
        Assert.NotEqual(Guid.Empty, gservice.GetId("test"));

        FriendRelationship f = new FriendRelationship { username = rushay.username, friendname = chi.username };
        FriendRelationship nf = fservice.Add(f);
        Assert.Equal(f, nf);
        nf = fservice.Delete(f);
        Assert.Equal(f, nf);
        Assert.True(0 == fservice.GetAll().Count);

        Assert.Throws<NotImplementedException>(() => fservice.GetAllById(Guid.Empty));
        Assert.Throws<NotImplementedException>(() => fservice.GetById(Guid.Empty));
        Assert.Throws<NotImplementedException>(() => fservice.GetId(""));
        Assert.Throws<NotImplementedException>(() => fservice.Update(f));
    }
}