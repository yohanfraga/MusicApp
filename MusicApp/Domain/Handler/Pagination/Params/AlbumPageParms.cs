using MusicApp.Domain.Handler.Pagination;

public class AlbumPageParams : PageParams
{
    public string? Name { get; set; }
    public long? ArtistId { get; set; }
    public DateTime? InitialDate { get; set; }
    public DateTime? FinalDate { get; set; }
}