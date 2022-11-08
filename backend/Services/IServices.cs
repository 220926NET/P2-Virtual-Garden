namespace Services;

public interface IServices<T>
{
    T Add(T t);
    T GetById(Guid id);
    List<T> GetAll();
    T Update(T t);
    T Delete(T t);
}