using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Entities;

public class User
{
    public long Id { get; init; }
    public long Name { get; set; }
    public required DateTime JoinDate { get; init; }
    public List<Playlist> Playlists { get; set; } = [];
    
    public List<Like> Likes { get; set; } = [];
    public List<ArtistFollow> ArtistFollows { get; set; } = [];
    public List<PlaylistFollow> PlaylistFollows { get; set; } = [];
}