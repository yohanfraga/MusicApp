using FluentValidation;
using MusicApp.Domain.Entities;
using MusicApp.Domain.Handler.Validation;

namespace MusicApp.Domain.EntitiesValidation;

public class ArtistValidation : Validate<Artist>
{
    public ArtistValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(a => a.Name)
            .NotEmpty()
            .Length(1, 200)
            .WithMessage("Name must be between {MinLength} a {MaxLength}");
    }
}