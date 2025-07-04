using MusicApp.Domain.Handler.Pagination;

public class UserPageParams : PageParams
{
    public string? Name { get; set; }
    public string? Email { get; set; }
}