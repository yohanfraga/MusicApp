using MusicApp.Domain.Entities;
using MusicApp.Domain.Enums;

namespace Tests.Builders;

public class LikeBuilder
{
    private long _musicId = 1;
    private long _userId = 1;
    private DateTime _likedDate = new (2025, 01, 01);
    private User? _user;
    private Music? _music;
    
    public static LikeBuilder NewObject() => new();

    public Like Build() =>
        new()
        {
            MusicId = _musicId,
            UserId = _userId,
            LikedDate = _likedDate,
            Music = _music,
            User = _user
        };

    public LikeBuilder WithMusicId(long musicId)
    {
        _musicId = musicId;

        return this;
    }
    
    public LikeBuilder WithUserId(long userId)
    {
        _userId = userId;

        return this;
    }
    
    public LikeBuilder WithLikedDate(DateTime likedDate)
    {
        _likedDate = likedDate;

        return this;
    }
    
    public LikeBuilder WithMusic()
    {
        _music = MusicBuilder.NewObject().Build();

        return this;
    }
    
    public LikeBuilder WithUser()
    {
        _user = UserBuilder.NewObject().Build();

        return this;
    }
}