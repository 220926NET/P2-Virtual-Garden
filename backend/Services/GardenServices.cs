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
        return _gardenDatabase.Add(t);
    }

    public Garden Delete(Garden t)
    {
        return _gardenDatabase.Delete(t);
    }

    public List<Garden> GetAll()
    {
        throw new NotImplementedException();
    }


    public Garden GetById(Guid id)
    {
        return _gardenDatabase.GetById(id);
    }

    public Garden Update(Garden t)
    {
        return _gardenDatabase.Update(t);
    }
}