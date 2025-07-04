namespace MusicApp.Domain.Entities;

public class Playlist
{
    public long Id { get; init; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required DateTime CreateDate { get; init; }
    public int Duration { get; set; }
    public bool IsPublic { get; set; }

    public long? ImageId { get; set; }
    public Image? Image { get; set; }

    public required Guid UserId { get; init; }
    public User? User { get; init; }

    public List<PlaylistFollow>? Follows { get; set; }
    public List<PlaylistMusic>? Musics { get; set; }
}