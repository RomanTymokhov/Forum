using Forum.Models.Account;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Forum.Persistance.Contexts
{
    public class ForumContext : IdentityDbContext<AppUser>
    {
        public DbSet<Update> ForumUpdates { get; set; }

        public ForumContext(DbContextOptions<ForumContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().ToTable("AspNetUsers");
            builder.Entity<Update>().ToTable("ForumUpdates").HasKey(f => f.Id);

            builder.Entity<Update>().HasOne(u => u.AppUser)
                .WithMany(u => u.Updates).HasForeignKey(u => u.Id)
                .OnDelete(DeleteBehavior.Cascade);

            string themeId = Guid.NewGuid().ToString();
            builder.Entity<Update>().HasData(
                new Update[]
                {
                    new Update{ Id = Guid.NewGuid().ToString(), ThemeId = themeId, Theme = "first theme", Message = "first message", IsTheme = true, UserId = "de72ade2-d396-4aa6-aaad-68b08a813cfa"},
                    new Update{ Id = Guid.NewGuid().ToString(), ThemeId = themeId, Theme = "first theme", Message = "second message", UserId = "de72ade2-d396-4aa6-aaad-68b08a813cfa"},
                    new Update{ Id = Guid.NewGuid().ToString(), ThemeId = themeId, Theme = "first theme", Message = "three message", UserId = "de72ade2-d396-4aa6-aaad-68b08a813cfa"},
                    new Update{ Id = Guid.NewGuid().ToString(), ThemeId = themeId, Theme = "first theme", Message = "four message", UserId = "de72ade2-d396-4aa6-aaad-68b08a813cfa"}
                });
        }
    }
}
