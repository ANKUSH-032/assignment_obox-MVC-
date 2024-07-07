using Microsoft.EntityFrameworkCore;
using core.mvc.Book;
using Microsoft.Data.SqlClient;

namespace Infrastucture
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksFromStoredProcedureAsync()
        {
            return await _context.BooksDto.FromSqlRaw("EXEC [dbo].[uspGetAllBooks]").ToListAsync();
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var param = new SqlParameter("@Id", id);

            var books = await _context.BooksDto
                .FromSqlRaw("EXEC [dbo].[uspGetBookById] @Id", param)
                .ToListAsync(); // Use ToListAsync() to execute the query and retrieve the results

            return books.FirstOrDefault()!; // Use FirstOrDefault() to retrieve the first element in the collection
        }




        //public async Task<BookDto> GetBookByIdAsync(int id)
        //{
        //    var param = new SqlParameter("@Id", id);
        //    return await _context.BooksDto.FromSqlRaw("EXEC uspGetBookById @Id", param).FirstOrDefaultAsync();
        //}

        public async Task<int> AddBookAsync(BookInsert bookInsert)
        {
            var titleParam = new SqlParameter("@Title", bookInsert.Title);
            var authorParam = new SqlParameter("@Author", bookInsert.Author);
            var genreParam = new SqlParameter("@Genre", bookInsert.Genre);
            var publishedDateParam = new SqlParameter("@PublishedDate", bookInsert.PublishedYear);
            var quantityParam = new SqlParameter("@Quantity", bookInsert.Quantity);

            return await _context.Database.ExecuteSqlRawAsync("EXEC uspBookCreate @Title, @Author, @Genre, @PublishedDate, @Quantity",
                                                              titleParam, authorParam, genreParam, publishedDateParam, quantityParam);
        }

        public async Task<int> UpdateBookAsync(BookUpdate bookUpdate)
        {
            var idParam = new SqlParameter("@Id", bookUpdate.BookID);
            var titleParam = new SqlParameter("@Title", bookUpdate.Title);
            var authorParam = new SqlParameter("@Author", bookUpdate.Author);
            var genreParam = new SqlParameter("@Genre", bookUpdate.Genre);
            var publishedDateParam = new SqlParameter("@PublishedDate", bookUpdate.PublishedYear);
            var quantityParam = new SqlParameter("@Quantity", bookUpdate.Quantity);

            return await _context.Database.ExecuteSqlRawAsync("EXEC uspBookUpdate @Id, @Title, @Author, @Genre, @PublishedDate, @Quantity",
                                                              idParam, titleParam, authorParam, genreParam, publishedDateParam, quantityParam);
        }
        public async Task<int> DeleteBookAsync(int id)
        {
            var param = new SqlParameter("@Id", id);
            return await _context.Database.ExecuteSqlRawAsync("EXEC uspBookDelete @Id", param);
        }
    }
}
