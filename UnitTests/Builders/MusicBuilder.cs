using MusicApp.Domain.Entities;

namespace Tests.Builders;

public class MusicBuilder
{
    private long _id = 1;
    private string _name = "Name";
    private int _duration = 1;
    private bool _isPublic = true;
    private DateTime _releaseDate = new (2025, 01, 01);
    private long _albumId = 1;
    private Album? _album;
    private readonly List<Like> _likes = [];
    private readonly List<PlaylistMusic> _playlists = [];
    
    public static MusicBuilder NewObject() => new();

    public Music Build() =>
        new()
        {
            Id = _id,
            Name = _name,
            Duration = _duration,
            IsPublic = _isPublic,
            ReleaseDate = _releaseDate,
            Likes = _likes,
            Playlists = _playlists,
            AlbumId = _albumId,
            Album = _album
        };

    public MusicBuilder WithId(long id)
    {
        _id = id;

        return this;
    }
    
    public MusicBuilder WithName(string name)
    {
        _name = name;

        return this;
    }
    
    public MusicBuilder WithDuration(int duration)
    {
        _duration = duration;

        return this;
    }
    
    public MusicBuilder WithIsPublic(bool isPublic)
    {
        _isPublic = isPublic;

        return this;
    }
    
    public MusicBuilder WithReleaseDate(DateTime releaseDate)
    {
        _releaseDate = releaseDate;

        return this;
    }
    
    public MusicBuilder WithAlbumId(long albumId)
    {
        _albumId = albumId;

        return this;
    }
    
    public MusicBuilder WithAlbum()
    {
        _album = AlbumBuilder.NewObject().Build();

        return this;
    }
    
    public MusicBuilder WithLike()
    {
        _likes.Add(LikeBuilder.NewObject().Build());

        return this;
    }
    
    public MusicBuilder WithPlaylist()
    {
        _playlists.Add(PlaylistMusicBuilder.NewObject().Build());

        return this;
    }
}