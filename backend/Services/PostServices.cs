using Models;
using DataAccess;

namespace Services;

public class PostServices : IServices<Post>
{
    private readonly IDBAccess<Post> _postDatabase;

    public PostServices(IDBAccessFactory factory)
    {
        _postDatabase = factory.getPostDB();
    }

    public Post Add(Post t)
    {
        return _postDatabase.Add(t);
    }

    public Post Delete(Post t)
    {
        throw new NotImplementedException();
    }

    public List<Post> GetAll()
    {
        throw new NotImplementedException();
    }

    public Post GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Post Update(Post t)
    {
        throw new NotImplementedException();
    }
}