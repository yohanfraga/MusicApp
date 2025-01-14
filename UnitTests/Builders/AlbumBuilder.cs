using MusicApp.Domain.Entities;
using MusicApp.Domain.Enums;

namespace Tests.Builders;

public class AlbumBuilder
{
    private long _id = 1;
    private string _name = "Name";
    private int _duration = 1;
    private bool _isPublic = true;
    private EAlbumType _type = EAlbumType.Single;
    private DateTime _releaseDate = new (2025, 01, 01);
    private long _artistId = 1;
    private Artist? _artist;
    private readonly List<Music> _musics = [];
    
    public static AlbumBuilder NewObject() => new();

    public Album Build() =>
        new()
        {
            Id = _id,
            Name = _name,
            Duration = _duration,
            IsPublic = _isPublic,
            Type = _type,
            ReleaseDate = _releaseDate,
            Musics = _musics,
            ArtistId = _artistId,
            Artist = _artist
        };

    public AlbumBuilder WithId(long id)
    {
        _id = id;

        return this;
    }
    
    public AlbumBuilder WithName(string name)
    {
        _name = name;

        return this;
    }
    
    public AlbumBuilder WithDuration(int duration)
    {
        _duration = duration;

        return this;
    }
    
    public AlbumBuilder WithIsPublic(bool isPublic)
    {
        _isPublic = isPublic;

        return this;
    }
    
    public AlbumBuilder WithType(EAlbumType type)
    {
        _type = type;

        return this;
    }
    
    public AlbumBuilder WithReleaseDate(DateTime releaseDate)
    {
        _releaseDate = releaseDate;

        return this;
    }
    
    public AlbumBuilder WithArtistId(long artistId)
    {
        _artistId = artistId;

        return this;
    }
    
    public AlbumBuilder WithArtist()
    {
        _artist = ArtistBuilder.NewObject().Build();

        return this;
    }
    
    public AlbumBuilder WithMusic()
    {
        _musics.Add(MusicBuilder.NewObject().Build());

        return this;
    }
}