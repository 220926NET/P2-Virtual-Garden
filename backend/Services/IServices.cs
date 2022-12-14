namespace Services;

public interface IServices<T>
{
    T Add(T t);
    T GetById(Guid id);
    List<T> GetAll();
    List<T> GetAllById(Guid id);
    T Update(T t);
    T Delete(T t);
    Guid GetId(string plantName);
}