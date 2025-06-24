namespace MusicApp.Domain.Entities;

public class Artist
{
    public long Id { get; init; }
    public required string Name { get; set; }
    public required DateTime JoinDate { get; init; }

    public long? ImageId { get; set; }
    public Image? Image { get; set; }

    public List<Album>? Albums { get; set; }
    public List<ArtistFollow>? Follows { get; set; }
}