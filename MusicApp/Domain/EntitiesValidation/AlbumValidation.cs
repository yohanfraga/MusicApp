using FluentValidation;
using MusicApp.Domain.Entities;

namespace MusicApp.Domain.EntitiesValidation;

public class AlbumValidation : AbstractValidator<Album>
{
    public AlbumValidation()
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