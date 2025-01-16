using FluentValidation;
using FluentValidation.Results;
using MusicApp.Domain.Extensions;
using MusicApp.Domain.Handler.Validation.Interface;

namespace MusicApp.Domain.Handler.Validation;
public abstract class Validate<T> : AbstractValidator<T>, IValidate<T> where T : class
{
    private ValidationResult? _validationResult;

    private async Task GetValidationResultAsync(T entity) => _validationResult ??= await ValidateAsync(entity);

    public async Task<ValidationResponse> ValidationAsync(T entity)
    {
        await GetValidationResultAsync(entity);

        var errorsDictionary = _validationResult!.Errors.ToDictionary();
        
        return ValidationResponse.CreateResponse(errorsDictionary);
    }
}

