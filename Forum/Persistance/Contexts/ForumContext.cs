using Forum.Models.Account;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        }
    }
}
