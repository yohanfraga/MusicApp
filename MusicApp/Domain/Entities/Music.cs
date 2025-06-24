namespace MusicApp.Domain.Entities;

public class Music
{
    public long Id { get; init; }
    public required string Name { get; set; }
    public int Duration { get; set; }
    public bool IsPublic { get; set; }
    public required DateTime ReleaseDate { get; set; }

    public required long AlbumId { get; set; }
    public Album? Album { get; set; }

    public long? ImageId { get; set; }
    public Image? Image { get; set; }

    public long? AudioId { get; set; }
    public Audio? Audio { get; set; }
    
    public List<Like>? Likes { get; set; }
    public List<PlaylistMusic>? Playlists { get; set; }
}