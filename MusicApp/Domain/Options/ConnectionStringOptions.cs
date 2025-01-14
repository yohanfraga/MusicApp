namespace WebApplication1.Domain.Options;
public sealed class ConnectionStringOptions
{
    public const string SectionName = "ConnectionStrings";
    public required string DefaultConnection { get; init; }
}
