using Microsoft.EntityFrameworkCore;
using core.mvc.Book;

namespace Generic.mvc
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        // public DbSet<Author> Authors { get; set; }
        // Add DbSet properties for other entities like Genres, Users, etc.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your model here
            // Example:
            // modelBuilder.Entity<Book>().ToTable("Books");
            // modelBuilder.Entity<Book>().Property(b => b.Title).HasMaxLength(100);

            base.OnModelCreating(modelBuilder);
        }
    }
}
