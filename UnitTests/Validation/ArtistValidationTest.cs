using MusicApp.Domain.EntitiesValidation;
using Tests.Builders;
using Tests.TestTools;
using Xunit;

namespace Tests.Validation;

public class ArtistValidationTest
{
    private readonly ArtistValidation _validation = new();

    [Fact]
    [Trait("Validation", "Perfect setting")]
    public async Task ArtistValidation_PerfectSetting_ReturnTrue()
    {
        var artist = ArtistBuilder.NewObject().Build();

        var validationResult = await _validation.ValidationAsync(artist);
        
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
    public async Task ArtistValidation_InvalidName_ReturnFalse(string name)
    {
        var artist = ArtistBuilder
            .NewObject()
            .WithName(name)
            .Build();

        var validationResult = await _validation.ValidationAsync(artist);
        
        Assert.False(validationResult.Valid);
    }
}