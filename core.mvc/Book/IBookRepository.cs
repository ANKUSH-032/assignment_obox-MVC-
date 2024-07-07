using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.mvc.Book
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDto>> GetAllBooksFromStoredProcedureAsync();
        Task<BookDto> GetBookByIdAsync(int id);
        Task<int> AddBookAsync(BookInsert bookInsert);
        Task<int> UpdateBookAsync(BookUpdate bookUpdate);
        Task<int> DeleteBookAsync(int id);
    }
    public interface IBookService
    {
        IEnumerable<BookDto> GetAllBooks();
        Task<BookDto> GetBookByIdAsync(int id);
        Task<int> AddBookAsync(BookInsert bookInsert);
        Task<int> UpdateBookAsync(BookUpdate bookUpdate);
        Task<int> DeleteBookAsync(int id);
    }

}
