using MusicApp.Domain.Enums;

namespace MusicApp.Domain.Entities;

public class Album
{
    public long Id { get; init; }
    public required string Name { get; set; }
    public required int Duration { get; set; }
    public bool IsPublic { get; set; }
    public EAlbumType Type { get; init; }
    public required DateTime ReleaseDate { get; set; }
    
    public required long ArtistId { get; init; }
    public Artist? Artist { get; init; }

    public long? ImageId { get; set; }
    public Image? Image { get; set; }

    public List<Music>? Musics { get; init; }
}