using MusicApp.Domain.Handler.Pagination;

namespace MusicApp.Domain.Handler.Pagination.Params;

public class ArtistFollowPageParams : PageParams
{
    public Guid? UserId { get; set; }
    public long? ArtistId { get; set; }
} 