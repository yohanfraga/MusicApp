using FluentValidation;
using MusicApp.Domain.Entities;
using MusicApp.Domain.Handler.Validation;

namespace MusicApp.Domain.EntitiesValidation;

public class PlaylistValidation : Validate<Playlist>
{
    public PlaylistValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .Length(1, 200)
            .WithMessage("Name must be between {MinLength} a {MaxLength}");
        
        RuleFor(p => p.Description)
            .NotEmpty()
            .Length(1, 200)
            .WithMessage("Name must be between {MinLength} a {MaxLength}");
    }
}