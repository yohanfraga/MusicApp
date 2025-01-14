namespace WebApplication1.Domain.Entities;

public abstract class Like
{
    public required long MusicId { get; set; }
    public required long UserId { get; set; }
    public required DateTime LikedDate { get; init; }

    public Music? Music { get; set; }
    public User? User { get; set; }
}