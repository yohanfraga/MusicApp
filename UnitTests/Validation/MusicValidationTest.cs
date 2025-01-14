using MusicApp.Domain.EntitiesValidation;
using Tests.Builders;
using Tests.TestTools;
using Xunit;

namespace Tests.Validation;

public class MusicValidationTest
{
    private readonly MusicValidation _validation = new();

    [Fact]
    [Trait("Validation", "Perfect setting")]
    public async Task MusicValidation_PerfectSetting_ReturnTrue()
    {
        var music = MusicBuilder.NewObject().Build();

        var validationResult = await _validation.ValidationAsync(music);
        
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
    public async Task MusicValidation_InvalidName_ReturnFalse(string name)
    {
        var music = MusicBuilder
            .NewObject()
            .WithName(name)
            .Build();

        var validationResult = await _validation.ValidationAsync(music);
        
        Assert.False(validationResult.Valid);
    }
}