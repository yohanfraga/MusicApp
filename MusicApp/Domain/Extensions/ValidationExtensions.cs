using FluentValidation.Results;

namespace MusicApp.Domain.Extensions;

public static class ValidationExtensions
{
    public static Dictionary<string, string> ToDictionary(this IEnumerable<ValidationFailure> errors) =>
        errors
            .GroupBy(error => error.PropertyName)
            .Select(group => 
                new KeyValuePair<string, string>(group.Key, group.FirstOrDefault()!.ErrorMessage))
            .ToDictionary();
}