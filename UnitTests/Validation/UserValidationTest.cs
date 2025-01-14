using MusicApp.Domain.EntitiesValidation;
using Tests.Builders;
using Tests.TestTools;
using Xunit;

namespace Tests.Validation;

public class UserValidationTest
{
    private readonly UserValidation _validation = new();

    [Fact]
    [Trait("Validation", "Perfect setting")]
    public async Task UserValidation_PerfectSetting_ReturnTrue()
    {
        var user = UserBuilder.NewObject().Build();

        var validationResult = await _validation.ValidationAsync(user);
        
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
    public async Task UserValidation_InvalidName_ReturnFalse(string name)
    {
        var user = UserBuilder
            .NewObject()
            .WithName(name)
            .Build();

        var validationResult = await _validation.ValidationAsync(user);
        
        Assert.False(validationResult.Valid);
    }
}