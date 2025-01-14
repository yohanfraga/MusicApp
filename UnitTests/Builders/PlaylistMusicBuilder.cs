using MusicApp.Domain.Entities;
using MusicApp.Domain.Enums;

namespace Tests.Builders;

public class PlaylistMusicBuilder
{
    private long _musicId = 1;
    private long _playlistId = 1;
    private DateTime _addedDate = new (2025, 01, 01);
    private Playlist? _playlist;
    private Music? _music;
    
    public static PlaylistMusicBuilder NewObject() => new();

    public PlaylistMusic Build() =>
        new()
        {
            MusicId = _musicId,
            PlaylistId = _playlistId,
            AddedDate = _addedDate,
            Music = _music,
            Playlist = _playlist
        };

    public PlaylistMusicBuilder WithMusicId(long musicId)
    {
        _musicId = musicId;

        return this;
    }
    
    public PlaylistMusicBuilder WithPlaylistId(long playlistId)
    {
        _playlistId = playlistId;

        return this;
    }
    
    public PlaylistMusicBuilder WithAddedDate(DateTime addedDate)
    {
        _addedDate = addedDate;

        return this;
    }
    
    public PlaylistMusicBuilder WithMusic()
    {
        _music = MusicBuilder.NewObject().Build();

        return this;
    }
    
    public PlaylistMusicBuilder WithPlaylist()
    {
        _playlist = PlaylistBuilder.NewObject().Build();

        return this;
    }
}