namespace WebApplication1.Domain.Entities;

public abstract class ArtistFollow
{
    public required long ArtistId { get; set; }
    public required long UserId { get; set; }
    public required DateTime FollowDate { get; init; }
    
    public Artist? Artist { get; set; }
    public User? User { get; set; }
}