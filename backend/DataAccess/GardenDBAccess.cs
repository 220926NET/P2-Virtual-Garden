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

    public Garden Add(Garden garden)
    {
        Garden temp = new();

        try
        {

        }
        catch (SqlException e)
        {
            Log.Error(e, "An error occured while creating a new garden resource");
        }

        return temp;
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