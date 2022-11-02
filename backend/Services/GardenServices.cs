using Models;
using DataAccess;

namespace Services;

public class GardenServices : IServices<Garden>
{
    private readonly IDBAccess<Garden> _gardenDatabase;

    public GardenServices(IDBAccessFactory factory)
    {
        _gardenDatabase = factory.GetGardenDB();
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