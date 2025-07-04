using Microsoft.AspNetCore.Identity;

namespace MusicApp.Domain.Entities;

public class UserToken : IdentityUserToken<Guid>
{
    public User? User { get; set; }
} 