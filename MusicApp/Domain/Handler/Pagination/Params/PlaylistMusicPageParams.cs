using MusicApp.Domain.Handler.Pagination;

namespace MusicApp.Domain.Handler.Pagination.Params;

public class PlaylistMusicPageParams : PageParams
{
    public long? PlaylistId { get; set; }
    public long? MusicId { get; set; }
} 