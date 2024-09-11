using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamPickAppTwo.Data.ViewSql;

namespace TeamPickAppTwo.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
    {
        public DbSet<List> Lists { get; set; }
        public DbSet<UserList> UserLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // many-to-many relationship between Board and Ingredient
            modelBuilder.Entity<UserList>().HasKey(ul => new
            {
                ul.ApplicationUserId,
                ul.ListId
            });

            modelBuilder.Entity<UserList>().HasOne(ul => ul.User).WithMany(x => x.UserLists).HasForeignKey(ul => ul.ListId);
            modelBuilder.Entity<UserList>().HasOne(ul => ul.List).WithMany(x => x.UserLists).HasForeignKey(ul => ul.ApplicationUserId);
        }
    }
}
