namespace Models;

public interface IValidate<in T>
{
    bool isValid(T toCheck);
}