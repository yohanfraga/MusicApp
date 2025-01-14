using MusicApp.Domain.Entities;
using MusicApp.Domain.Enums;

namespace Tests.Builders;

public class ArtistFollowBuilder
{
    private long _artistId = 1;
    private long _userId = 1;
    private DateTime _followDate = new (2025, 01, 01);
    private User? _user;
    private Artist? _artist;
    
    public static ArtistFollowBuilder NewObject() => new();

    public ArtistFollow Build() =>
        new()
        {
            ArtistId = _artistId,
            UserId = _userId,
            FollowDate = _followDate,
            Artist = _artist,
            User = _user
        };

    public ArtistFollowBuilder WithArtistId(long artistId)
    {
        _artistId = artistId;

        return this;
    }
    
    public ArtistFollowBuilder WithUserId(long userId)
    {
        _userId = userId;

        return this;
    }
    
    public ArtistFollowBuilder WithFollowDate(DateTime followDate)
    {
        _followDate = followDate;

        return this;
    }
    
    public ArtistFollowBuilder WithArtist()
    {
        _artist = ArtistBuilder.NewObject().Build();

        return this;
    }
    
    public ArtistFollowBuilder WithUser()
    {
        _user = UserBuilder.NewObject().Build();

        return this;
    }
}