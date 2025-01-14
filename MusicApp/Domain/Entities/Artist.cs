namespace MusicApp.Domain.Entities;

public class Artist
{
    public long Id { get; init; }
    public long Name { get; set; }
    public required DateTime JoinDate { get; init; }

    public List<Album> Albums { get; set; } = [];
    public List<ArtistFollow> Follows { get; set; } = [];
}