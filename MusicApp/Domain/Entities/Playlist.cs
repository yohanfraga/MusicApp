namespace WebApplication1.Domain.Entities;

public class Playlist
{
    public long Id { get; init; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required DateTime CreateDate { get; init; }
    public int Duration { get; set; }
    public bool Public { get; set; }
    public List<Music> Musics { get; set; } = [];

    public required long UserId { get; init; }
    public User? User { get; init; }

    public List<PlaylistFollow> Follows { get; set; } = [];
}