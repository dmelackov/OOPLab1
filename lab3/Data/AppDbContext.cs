using lab3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace lab3.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .HasMany(e => e.CreatedWorkspaces)
                .WithOne(e => e.Creator)
                .HasForeignKey(e => e.CreatorId)
            .IsRequired();

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Perms)
                .WithMany(e => e.Roles)
                .UsingEntity<RolePerm>();
            
            modelBuilder.Entity<WorkspaceProfile>()
                .HasOne(e => e.Workspace)
                .WithMany(e => e.WorkspaceProfiles)
                .HasForeignKey(e => e.WorkspaceId)
            .IsRequired();

            modelBuilder.Entity<WorkspaceProfile>()
                .HasOne(e => e.Role)
                .WithMany()
                .HasForeignKey(e => e.RoleId)
            .IsRequired();

            modelBuilder.Entity<WorkspaceProfile>()
                .HasOne(e => e.Profile)
                .WithMany(e => e.WorkspaceProfiles)
                .HasForeignKey(e => e.ProfileId)
            .IsRequired();

        }
        public DbSet<lab3.Models.Profile> Profile { get; set; } = default!;
        public DbSet<lab3.Models.Perm> Perm { get; set; } = default!;
        public DbSet<lab3.Models.Role> Role { get; set; } = default!;
        public DbSet<lab3.Models.Workspace> Workspace { get; set; } = default!;
        public DbSet<lab3.Models.WorkspaceProfile> WorkspaceProfile { get; set; } = default!;
        public DbSet<lab3.Models.RolePerm> RolePerm { get; set; } = default!;
    }
}
