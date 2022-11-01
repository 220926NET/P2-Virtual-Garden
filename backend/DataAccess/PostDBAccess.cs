using Microsoft.Data.SqlClient;
using Models;

namespace DataAccess;

public class PostDBAccess : IDBAccess<Post>
{
    private readonly SqlConnectionFactory _factory;

    public PostDBAccess(SqlConnectionFactory factory)
    {
        _factory = factory;
    }

    public Post Add(Post t)
    {
        throw new NotImplementedException();
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