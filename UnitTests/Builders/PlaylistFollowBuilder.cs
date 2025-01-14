using MusicApp.Domain.Entities;
using MusicApp.Domain.Enums;

namespace Tests.Builders;

public class PlaylistFollowBuilder
{
    private long _playlistId = 1;
    private long _userId = 1;
    private DateTime _followDate = new (2025, 01, 01);
    private User? _user;
    private Playlist? _playlist;
    
    public static PlaylistFollowBuilder NewObject() => new();

    public PlaylistFollow Build() =>
        new()
        {
            PlaylistId = _playlistId,
            UserId = _userId,
            FollowDate = _followDate,
            Playlist = _playlist,
            User = _user
        };

    public PlaylistFollowBuilder WithPlaylistId(long playlistId)
    {
        _playlistId = playlistId;

        return this;
    }
    
    public PlaylistFollowBuilder WithUserId(long userId)
    {
        _userId = userId;

        return this;
    }
    
    public PlaylistFollowBuilder WithFollowDate(DateTime followDate)
    {
        _followDate = followDate;

        return this;
    }
    
    public PlaylistFollowBuilder WithPlaylist()
    {
        _playlist = PlaylistBuilder.NewObject().Build();

        return this;
    }
    
    public PlaylistFollowBuilder WithUser()
    {
        _user = UserBuilder.NewObject().Build();

        return this;
    }
}