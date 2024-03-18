using LibraryAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<library> libraries {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<library>().HasData(
                new library()
                {
                    Id = 1,
                    Name = "40 Rules of Love",
                    Author = "Elif Shafak",
                    Amount = 10
                },
                new library()
                {
                    Id = 2,
                    Name = "Your word is your wand",
                    Author = "Florence Scovel Shinn",
                    Amount = 15
                }
                );
        }

    }
}
