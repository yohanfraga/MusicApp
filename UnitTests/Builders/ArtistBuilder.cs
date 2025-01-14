using MusicApp.Domain.Entities;
using MusicApp.Domain.Enums;

namespace Tests.Builders;

public class ArtistBuilder
{
    private long _id = 1;
    private string _name = "Name";
    private DateTime _joinDate = new (2025, 01, 01);
    private readonly List<Album> _albums = [];
    private readonly List<ArtistFollow> _follows = [];
    
    public static ArtistBuilder NewObject() => new();

    public Artist Build() =>
        new()
        {
            Id = _id,
            Name = _name,
            JoinDate = _joinDate,
            Albums = _albums,
            Follows = _follows
        };

    public ArtistBuilder WithId(long id)
    {
        _id = id;

        return this;
    }
    
    public ArtistBuilder WithName(string name)
    {
        _name = name;

        return this;
    }
    
    public ArtistBuilder WithJoinDate(DateTime joinDate)
    {
        _joinDate = joinDate;

        return this;
    }
    
    public ArtistBuilder WithAlbum()
    {
        _albums.Add(AlbumBuilder.NewObject().Build());

        return this;
    }
    
    public ArtistBuilder WithFollow(ArtistFollow follow)
    {
        _follows.Add(follow);

        return this;
    }
}