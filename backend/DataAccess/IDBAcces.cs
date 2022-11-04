namespace DataAccess;

public interface IDBAccess<T>
{
    T Add(T t);
    T GetById(Guid id);
    List<T> GetAll();
    T Update(T t);
    T Delete(T t);
}