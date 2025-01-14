using FluentValidation;
using FluentValidation.Results;
using MusicApp.Domain.Handler.Validation.Interface;

namespace MusicApp.Domain.Handler.Validation;
public abstract class Validate<T> : AbstractValidator<T>, IValidate<T> where T : class
{
    private ValidationResult? _validationResult;

    private void CreateResult(T entity) => _validationResult ??= Validate(entity);

    private async Task CreateResultAsync(T entity) => _validationResult ??= await ValidateAsync(entity);

    private Dictionary<string, string> GetErrors() => ToDictionary(_validationResult!.Errors);


    public async Task<ValidationResponse> ValidationAsync(T entity)
    {
        await CreateResultAsync(entity);

        return ValidationResponse.CreateResponse(GetErrors());
    }

    public ValidationResponse Validation(T entity)
    {
        CreateResult(entity);

        return ValidationResponse.CreateResponse(GetErrors());
    }
    
    private static Dictionary<string, string> ToDictionary(IEnumerable<ValidationFailure> errors)
    {
        var dictionary = new Dictionary<string, string>();

        foreach (var error in errors)
        {
            if (!dictionary.ContainsKey(error.PropertyName))
                dictionary.Add(error.PropertyName, error.ErrorMessage);
        }

        return dictionary;
    }
}

