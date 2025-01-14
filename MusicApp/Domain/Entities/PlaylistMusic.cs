namespace MusicApp.Domain.Entities;

public class PlaylistMusic
{
    public long MusicId { get; init; }
    public long PlaylistId { get; init; }
    public required DateTime AddedDate { get; init; }
    public Music? Music { get; set; }
    public Playlist? Playlist { get; set; }
}