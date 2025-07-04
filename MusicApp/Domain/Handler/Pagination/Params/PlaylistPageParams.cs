using MusicApp.Domain.Handler.Pagination;

namespace MusicApp.Domain.Handler.Pagination.Params;

public class PlaylistPageParams : PageParams
{
    public string? Name { get; set; }
    public Guid? UserId { get; set; }
} 