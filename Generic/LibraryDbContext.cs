using Microsoft.EntityFrameworkCore;
using core.mvc.Book;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using core.mvc.Login;

namespace Infrastucture
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<BookDto> BooksDto { get; set; }
        public DbSet<LoginDto> LoginDto { get; set; }

        public DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDto>().HasNoKey(); 
            modelBuilder.Entity<LoginDto>().HasNoKey();
            modelBuilder.Entity<Book>().HasNoKey(); // Configure BookDto as keyless entity

            // Configure BookDto as keyless entity
            // Additional configurations if needed

            base.OnModelCreating(modelBuilder);
        }
    }
}
