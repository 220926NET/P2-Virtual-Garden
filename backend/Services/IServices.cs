namespace Services;

public interface IServices<T>
{
    T Add(T t);
    T GetById(int id);
    List<T> GetAll();
    List<T> GetAllById(Guid id);
    T Update(T t);
    T Delete(T t);
}