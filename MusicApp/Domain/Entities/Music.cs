namespace WebApplication1.Domain.Entities;

public class Music
{
    public long Id { get; init; }
    public required string Name { get; set; }
    public int Duration { get; set; }
    public bool Public { get; set; }
    public required DateTime ReleaseDate { get; set; }
    public List<Like> Likes { get; set; } = [];
    
    public required long ArtistId { get; set; }
    public Artist? Artist { get; set; }
    
    public required long AlbumId { get; set; }
    public Album? Album { get; set; }
}