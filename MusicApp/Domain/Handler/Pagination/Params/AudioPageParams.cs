using MusicApp.Domain.Handler.Pagination;

namespace MusicApp.Domain.Handler.Pagination.Params;

public class AudioPageParams : PageParams
{
    public string? Name { get; set; }
} 