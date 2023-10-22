using Microsoft.EntityFrameworkCore;
using OneMessage.Application.Models;
using System.Reflection.Emit;

namespace OneMessage.Application.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public virtual DbSet<User> Users { set; get; }
    public virtual DbSet<Role> Roles { set; get; }
    public virtual DbSet<UserRole> UserRoles { get; set; }
    public virtual DbSet<FriendShip> FriendShips { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // it should be placed here, otherwise it will rewrite the following settings!
        base.OnModelCreating(builder);

        // Custom application mappings
        builder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(450).IsRequired();
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.Password).IsRequired();
        });

        builder.Entity<FriendShip>(entity =>
        {
            entity.HasOne(fs => fs.FromUser)
                .WithMany(u => u.FriendShips)
                .HasForeignKey(fs => fs.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(fs => fs.ToUser)
                .WithMany()
                .HasForeignKey(fs => fs.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasIndex(x => x.Id);
        });

      
        builder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(450).IsRequired();
            entity.HasIndex(e => e.Name).IsUnique();
        });

        builder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId });
            entity.HasIndex(e => e.UserId);
            entity.HasIndex(e => e.RoleId);
            entity.Property(e => e.UserId);
            entity.Property(e => e.RoleId);
            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles).HasForeignKey(d => d.RoleId);
            entity.HasOne(d => d.User).WithMany(p => p.UserRoles).HasForeignKey(d => d.UserId);
        });

        builder.Entity<Role>().HasData(
            new Role { Id = 1, Name = CustomRoles.User },
            new Role { Id = 2, Name = CustomRoles.Admin }
        );
    }
}