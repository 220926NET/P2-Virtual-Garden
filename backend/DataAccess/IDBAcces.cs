namespace DataAccess;

public interface IDBAccess<T>
{
    T Add(T t);
    T GetById(Guid id);
    T Exists(string username);
    List<T> GetAll();
    List<T> GetAllById(Guid id);
    T Update(T t);
    T Delete(T t);
    Guid GetId(string plantName);
}