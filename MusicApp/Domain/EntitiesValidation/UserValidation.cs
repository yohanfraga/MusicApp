using FluentValidation;
using MusicApp.Domain.Entities;

namespace MusicApp.Domain.EntitiesValidation;

public class UserValidation : AbstractValidator<User>
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
            .WithMessage("Name must be between {MinLength} a {MaxLength}");
    }
}