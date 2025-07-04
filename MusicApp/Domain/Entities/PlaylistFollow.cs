namespace MusicApp.Domain.Entities;

public class PlaylistFollow
{
    public required long PlaylistId { get; set; }
    public required Guid UserId { get; set; }
    public required DateTime FollowDate { get; init; }
    
    public Playlist? Playlist { get; set; }
    public User? User { get; set; }
}