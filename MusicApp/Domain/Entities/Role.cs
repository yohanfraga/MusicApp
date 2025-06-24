using Microsoft.AspNetCore.Identity;

namespace MusicApp.Domain.Entities;

public class Role : IdentityRole<Guid>
{
    public bool Active { get; set; }

    public List<UserRole>? UserRoles { get; set; }
} 