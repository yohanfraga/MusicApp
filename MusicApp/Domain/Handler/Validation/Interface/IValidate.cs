namespace MusicApp.Domain.Handler.Validation.Interface;

public interface IValidate<T> where T : class
{
    Task<ValidationResponse> ValidationAsync(T entity);
    ValidationResponse Validation(T entity);
}