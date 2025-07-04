using MusicApp.Domain.Handler.Pagination;

namespace MusicApp.Domain.Handler.Pagination.Params;

public class MusicPageParams : PageParams
{
    public string? Name { get; set; }
    public long? AlbumId { get; set; }
} 