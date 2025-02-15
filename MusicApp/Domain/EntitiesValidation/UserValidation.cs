using FluentValidation;
using MusicApp.Domain.Entities;
using MusicApp.Domain.Handler.Validation;

namespace MusicApp.Domain.EntitiesValidation;

public class UserValidation : Validate<User>
{
    public UserValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(u => u.Name)
            .NotEmpty()
            .Length(1, 200)
            .WithMessage("Name must be between {MinLength} a {MaxLength}");
    }
}