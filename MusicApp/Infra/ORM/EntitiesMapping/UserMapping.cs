using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;
using MusicApp.Infra.ORM.EntitiesMapping.Base;

namespace MusicApp.Infra.ORM.EntitiesMapping;

public class UserMapping : BaseMapping, IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User), Schema);
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnType("uniqueidentifier")
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .HasColumnOrder(1)
            .IsRequired();
        
        builder.Property(u => u.Name)
            .HasColumnType("nvarchar(256)")
            .HasColumnName("name")
            .HasColumnOrder(2)
            .IsRequired();
        
        builder.Property(u => u.JoinDate)
            .HasColumnType("datetime2")
            .HasColumnName("join_date")
            .HasColumnOrder(3)
            .IsRequired();
        
        builder.Property(u => u.ArtistId)
            .HasColumnType("bigint")
            .HasColumnName("artist_id")
            .HasColumnOrder(4);

        builder.Property(u => u.UserName)
            .HasColumnType("nvarchar(256)")
            .HasColumnName("login")
            .HasColumnOrder(5);

        builder.Property(u => u.NormalizedUserName)
            .HasColumnType("nvarchar(256)")
            .HasColumnName("normalized_user_name")
            .HasColumnOrder(6);

        builder.Property(u => u.Email)
            .HasColumnType("nvarchar(256)")
            .HasColumnName("email")
            .HasColumnOrder(7);

        builder.Property(u => u.NormalizedEmail)
            .HasColumnType("nvarchar(256)")
            .HasColumnName("normalized_email")
            .HasColumnOrder(8);

        builder.Property(u => u.EmailConfirmed)
            .HasColumnType("bit")
            .HasColumnName("email_confirmed")
            .HasColumnOrder(9);

        builder.Property(u => u.PasswordHash)
            .HasColumnType("nvarchar(max)")
            .HasColumnName("password_hash")
            .HasColumnOrder(10);

        builder.Property(u => u.SecurityStamp)
            .HasColumnType("nvarchar(max)")
            .HasColumnName("security_stamp")
            .HasColumnOrder(11);

        builder.Property(u => u.ConcurrencyStamp)
            .HasColumnType("nvarchar(max)")
            .HasColumnName("concurrency_stamp")
            .HasColumnOrder(12);

        builder.Property(u => u.PhoneNumber)
            .HasColumnType("nvarchar(20)")
            .HasColumnName("phone_number")
            .HasColumnOrder(13);

        builder.Property(u => u.PhoneNumberConfirmed)
            .HasColumnType("bit")
            .HasColumnName("phone_number_confirmed")
            .HasColumnOrder(14);

        builder.Property(u => u.TwoFactorEnabled)
            .HasColumnType("bit")
            .HasColumnName("two_factor_enabled")
            .HasColumnOrder(15);

        builder.Property(u => u.LockoutEnd)
            .HasColumnType("datetimeoffset")
            .HasColumnName("lockout_end")
            .HasColumnOrder(16);

        builder.Property(u => u.LockoutEnabled)
            .HasColumnType("bit")
            .HasColumnName("lockout_enabled")
            .HasColumnOrder(17);

        builder.Property(u => u.AccessFailedCount)
            .HasColumnType("int")
            .HasColumnName("access_failed_count")
            .HasColumnOrder(18);
        
        builder.HasMany(u => u.Playlists)
            .WithOne()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(u => u.Likes)
            .WithOne()
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(u => u.ArtistFollows)
            .WithOne()
            .HasForeignKey(af => af.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(u => u.PlaylistFollows)
            .WithOne()
            .HasForeignKey(pf => pf.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Identity-friendly: map UserRoles many-to-many join
        builder.HasMany(u => u.UserRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();
    }
}