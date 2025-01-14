using MusicApp.Domain.Entities;

namespace Tests.Builders;

public class UserBuilder
{
    private long _id = 1;
    private string _name = "Name";
    private DateTime _joinDate = new (2025, 01, 01);
    private readonly List<Playlist> _playlists = [];
    private readonly List<Like> _likes = [];
    private readonly List<ArtistFollow> _artistFollows = [];
    private readonly List<PlaylistFollow> _playlistFollows = [];
    
    public static UserBuilder NewObject() => new();

    public User Build() =>
        new()
        {
            Id = _id,
            Name = _name,
            JoinDate = _joinDate,
            Playlists = _playlists,
            Likes = _likes,
            ArtistFollows = _artistFollows,
            PlaylistFollows = _playlistFollows
        };

    public UserBuilder WithId(long id)
    {
        _id = id;

        return this;
    }
    
    public UserBuilder WithName(string name)
    {
        _name = name;

        return this;
    }
    
    public UserBuilder WithJoinDate(DateTime joinDate)
    {
        _joinDate = joinDate;

        return this;
    }
    
    public UserBuilder WithPlaylist()
    {
        _playlists.Add(PlaylistBuilder.NewObject().Build());

        return this;
    }
    
    public UserBuilder WithLike()
    {
        _likes.Add(LikeBuilder.NewObject().Build());

        return this;
    }
    
    public UserBuilder WithArtistFollow()
    {
        _artistFollows.Add(ArtistFollowBuilder.NewObject().Build());

        return this;
    }
    
    public UserBuilder WithPlaylistFollow()
    {
        _playlistFollows.Add(PlaylistFollowBuilder.NewObject().Build());

        return this;
    }
}