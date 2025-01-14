using MusicApp.Domain.Entities;

namespace Tests.Builders;

public class PlaylistBuilder
{
    private long _id = 1;
    private string _name = "Name";
    private string? _description;
    private int _duration = 1;
    private bool _isPublic = true;
    private DateTime _createDate = new (2025, 01, 01);
    private long _userId = 1;
    private User? _user;
    private readonly List<PlaylistFollow> _follows = [];
    private readonly List<PlaylistMusic> _musics = [];
    
    public static PlaylistBuilder NewObject() => new();

    public Playlist Build() =>
        new()
        {
            Id = _id,
            Name = _name,
            Description = _description,
            Duration = _duration,
            IsPublic = _isPublic,
            CreateDate = _createDate,
            Follows = _follows,
            Musics = _musics,
            UserId = _userId,
            User = _user
        };

    public PlaylistBuilder WithId(long id)
    {
        _id = id;

        return this;
    }
    
    public PlaylistBuilder WithName(string name)
    {
        _name = name;

        return this;
    }
    
    public PlaylistBuilder WithDescription(string description)
    {
        _description = description;

        return this;
    }
    
    public PlaylistBuilder WithDuration(int duration)
    {
        _duration = duration;

        return this;
    }
    
    public PlaylistBuilder WithIsPublic(bool isPublic)
    {
        _isPublic = isPublic;

        return this;
    }
    
    public PlaylistBuilder WithCreateDate(DateTime createDate)
    {
        _createDate = createDate;

        return this;
    }
    
    public PlaylistBuilder WithUserId(long userId)
    {
        _userId = userId;

        return this;
    }
    
    public PlaylistBuilder WithUser()
    {
        _user = UserBuilder.NewObject().Build();

        return this;
    }
    
    public PlaylistBuilder WithFollow()
    {
        _follows.Add(PlaylistFollowBuilder.NewObject().Build());

        return this;
    }
    
    public PlaylistBuilder WithMusic()
    {
        _musics.Add(PlaylistMusicBuilder.NewObject().Build());

        return this;
    }
}