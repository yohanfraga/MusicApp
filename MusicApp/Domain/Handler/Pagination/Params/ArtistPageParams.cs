using MusicApp.Domain.Handler.Pagination;

namespace MusicApp.Domain.Handler.Pagination.Params;

public class ArtistPageParams : PageParams
{
    public string? Name { get; set; }
} 