using FluentValidation;
using MusicApp.Domain.Entities;
using MusicApp.Domain.Handler.Validation;

namespace MusicApp.Domain.EntitiesValidation;

public class AlbumValidation : Validate<Album>
{
    public AlbumValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(a => a.Name)
            .NotEmpty()
            .Length(1, 200)
            .WithMessage("Name must be between {MinLength} a {MaxLength}");
        
        RuleForEach(a => a.Musics).SetValidator(new MusicValidation());
    }
}