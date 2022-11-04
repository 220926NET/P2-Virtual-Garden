namespace Models;

public interface IValidate<T>
{
    bool isValid(T toCheck);
}