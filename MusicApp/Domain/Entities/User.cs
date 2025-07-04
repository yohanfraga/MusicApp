using Microsoft.AspNetCore.Identity;

namespace MusicApp.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public required string Name { get; set; }
    public required DateTime JoinDate { get; init; }

    public long? ArtistId { get; set; }
    public Artist? Artist { get; set; }

    public long? ImageId { get; set; }
    public Image? Image { get; set; }
    
    public List<Playlist>? Playlists { get; set; }
    public List<Like>? Likes { get; set; }
    public List<ArtistFollow>? ArtistFollows { get; set; }
    public List<PlaylistFollow>? PlaylistFollows { get; set; }
    public List<UserRole>? UserRoles { get; set; }
    public List<UserToken>? UserTokens { get; set; }
    public List<UserClaim>? UserClaims { get; set; }
    public List<UserLogin>? UserLogins { get; set; }
}