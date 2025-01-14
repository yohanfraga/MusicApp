using WebApplication1.Domain.Enums;

namespace WebApplication1.Domain.Entities;

public class Album
{
    public long Id { get; init; }
    public long Name { get; set; }
    public required int Duration { get; set; }
    public bool Public { get; set; }
    public EAlbumType Type { get; init; }
    public required DateTime ReleaseDate { get; set; }
    public List<Music> Musics { get; init; } = [];
    
    public required long ArtistId { get; init; }
    public Artist? Artist { get; init; }
}