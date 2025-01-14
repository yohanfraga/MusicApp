using Microsoft.OpenApi.Validations.Rules;
using FluentValidation;

namespace WebApplication1.Domain.EntitiesValidation;

public class UserValidation 
{
    public UserValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(u => u.Name)
            .NotEmpty()
            .Length(1, 150)
            .WithMessage(a => !string.IsNullOrWhiteSpace(a.State)
                ? "Name must be between {MinLength} a {MaxLength}"
                : "Name is required");
    }
}