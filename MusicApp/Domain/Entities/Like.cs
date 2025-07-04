namespace MusicApp.Domain.Entities;

public class Like
{
    public required long MusicId { get; set; }
    public required Guid UserId { get; set; }
    public required DateTime LikedDate { get; init; }

    public Music? Music { get; set; }
    public User? User { get; set; }
}