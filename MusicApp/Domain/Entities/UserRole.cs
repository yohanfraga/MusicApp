using Microsoft.AspNetCore.Identity;

namespace MusicApp.Domain.Entities;

public class UserRole : IdentityUserRole<Guid>
{
    public User? User { get; init; }
    public Role? Role { get; init; }
} 