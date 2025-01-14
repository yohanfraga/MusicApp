using FluentValidation;
using MusicApp.Domain.Entities;
using MusicApp.Domain.Handler.Validation;

namespace MusicApp.Domain.EntitiesValidation;

public class MusicValidation : Validate<Music>
{
    public MusicValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(m => m.Name)
            .NotEmpty()
            .Length(1, 200)
            .WithMessage("Name must be between {MinLength} a {MaxLength}");
    }
}