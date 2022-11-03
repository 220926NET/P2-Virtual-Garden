namespace Models.Validation;

public interface IValidate<T>
{
    bool isValid(T toCheck);
}