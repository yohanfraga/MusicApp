using MusicApp.Domain.EntitiesValidation;
using Tests.Builders;
using Tests.TestTools;
using Xunit;

namespace Tests.Validation;

public class AlbumValidationTest
{
    private readonly AlbumValidation _validation = new();

    [Fact]
    [Trait("Validation", "Perfect setting")]
    public async Task AlbumValidation_PerfectSetting_ReturnTrue()
    {
        var album = AlbumBuilder.NewObject().Build();

        var validationResult = await _validation.ValidationAsync(album);
        
        Assert.True(validationResult.Valid);
    }
    
    public static IEnumerable<object[]> InvalidName()
    {
        yield return ["   "];
        yield return [" "];
        yield return [string.Empty];
        yield return [UtilTools.GenerateStringByLength(201)];
    }
    
    [Theory]
    [Trait("Validation", "Invalid name")]
    [MemberData(nameof(InvalidName))]
    public async Task AlbumValidation_InvalidName_ReturnFalse(string name)
    {
        var album = AlbumBuilder
            .NewObject()
            .WithName(name)
            .Build();

        var validationResult = await _validation.ValidationAsync(album);
        
        Assert.False(validationResult.Valid);
    }
}