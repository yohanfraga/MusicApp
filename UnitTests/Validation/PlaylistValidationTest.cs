using MusicApp.Domain.EntitiesValidation;
using Tests.Builders;
using Tests.TestTools;
using Xunit;

namespace Tests.Validation;

public class PlaylistValidationTest
{
    private readonly PlaylistValidation _validation = new();

    [Fact]
    [Trait("Validation", "Perfect setting")]
    public async Task PlaylistValidation_PerfectSetting_ReturnTrue()
    {
        var playlist = PlaylistBuilder.NewObject().Build();

        var validationResult = await _validation.ValidationAsync(playlist);
        
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
    [Trait("Validation", "Invalid description")]
    [MemberData(nameof(InvalidName))]
    public async Task PlaylistValidation_InvalidName_ReturnFalse(string name)
    {
        var playlist = PlaylistBuilder
            .NewObject()
            .WithName(name)
            .Build();

        var validationResult = await _validation.ValidationAsync(playlist);
        
        Assert.False(validationResult.Valid);
    }
    
    public static IEnumerable<object[]> InvalidDescription()
    {
        yield return ["   "];
        yield return [" "];
        yield return [string.Empty];
        yield return [UtilTools.GenerateStringByLength(201)];
    }
    
    [Theory]
    [Trait("Validation", "Invalid street")]
    [MemberData(nameof(InvalidDescription))]
    public async Task PlaylistValidation_InvalidDescription_ReturnFalse(string description)
    {
        var playlist = PlaylistBuilder
            .NewObject()
            .WithDescription(description)
            .Build();

        var validationResult = await _validation.ValidationAsync(playlist);
        
        Assert.False(validationResult.Valid);
    }
}