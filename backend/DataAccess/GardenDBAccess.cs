using Microsoft.Data.SqlClient;
using Models;
using Serilog;

namespace DataAccess;

public class GardenDBAccess : IDBAccess<Garden>
{
    private readonly SqlConnectionFactory _factory;

    public GardenDBAccess(SqlConnectionFactory factory)
    {
        _factory = factory;
    }

    public Garden Add(Garden t)
    {
        throw new NotImplementedException();
    }

    public Garden Delete(Garden t)
    {
        throw new NotImplementedException();
    }

    public List<Garden> GetAll()
    {
        throw new NotImplementedException();
    }

    public Garden GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Garden Update(Garden t)
    {
        throw new NotImplementedException();
    }
}