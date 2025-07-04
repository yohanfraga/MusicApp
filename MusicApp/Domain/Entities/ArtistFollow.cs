namespace MusicApp.Domain.Entities;

public class ArtistFollow
{
    public required long ArtistId { get; set; }
    public required Guid UserId { get; set; }
    public required DateTime FollowDate { get; init; }
    
    public Artist? Artist { get; set; }
    public User? User { get; set; }
}