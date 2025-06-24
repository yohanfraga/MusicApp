namespace MusicApp.Domain.Entities;

public sealed class Image
{
    public long Id { get; init; }
    public required string Name { get; set; }
    public required string Extension { get; set; }
    public byte[]? Bytes { get; set; }
} 