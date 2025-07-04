using MusicApp.Domain.Handler.Pagination;

namespace MusicApp.Domain.Handler.Pagination.Params;

public class LikePageParams : PageParams
{
    public Guid? UserId { get; set; }
    public long? MusicId { get; set; }
} 