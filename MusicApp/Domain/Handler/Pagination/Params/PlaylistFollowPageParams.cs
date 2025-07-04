using MusicApp.Domain.Handler.Pagination;

namespace MusicApp.Domain.Handler.Pagination.Params;

public class PlaylistFollowPageParams : PageParams
{
    public Guid? UserId { get; set; }
    public long? PlaylistId { get; set; }
} 