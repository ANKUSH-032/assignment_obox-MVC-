
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.mvc.Book
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)  
        {
            _bookRepository = bookRepository;   
        }

        public IEnumerable<BookDto> GetAllBooks()
        {
            return _bookRepository.GetAllBooksFromStoredProcedureAsync().Result;
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }
        public async Task<int> AddBookAsync(BookInsert bookInsert)
        {
            // Assuming BookInsert is used for adding a book
            var bookDto = MapBookInsertToDto(bookInsert);
            return await _bookRepository.AddBookAsync(bookDto);
        }

        public async Task<int> UpdateBookAsync(BookUpdate bookUpdate)
        {
            // Assuming BookUpdate is used for updating a book
            var bookDto = MapBookUpdateToDto(bookUpdate);
            return await _bookRepository.UpdateBookAsync(bookDto);
        }

        public async Task<int> DeleteBookAsync(int id)
        {
            return await _bookRepository.DeleteBookAsync(id);
        }

        // Helper method to map BookInsert to BookDto
        private BookInsert MapBookInsertToDto(BookInsert bookInsert)
        {
            return new BookInsert
            {
                Title = bookInsert.Title,
                Author = bookInsert.Author,
                Genre = bookInsert.Genre,
                PublishedYear = bookInsert.PublishedYear,
                Quantity = bookInsert.Quantity
            };
        }

        // Helper method to map BookUpdate to BookDto
        private BookUpdate MapBookUpdateToDto(BookUpdate bookUpdate)
        {
            return new BookUpdate
            {
                BookID = bookUpdate.BookID,
                Title = bookUpdate.Title,
                Author = bookUpdate.Author,
                Genre = bookUpdate.Genre,
                PublishedYear = bookUpdate.PublishedYear,
                Quantity = bookUpdate.Quantity
            };
        }
    }
}
