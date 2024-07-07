using core.mvc.Book;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace assignment_obox.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public ActionResult Index()
        {
            var bookDtos = _bookService.GetAllBooks();
            var books = MapBookDtoToBook(bookDtos);
            return View(books);
        }
        private IEnumerable<Book> MapBookDtoToBook(IEnumerable<BookDto> bookDtos)
        {
            return bookDtos.Select(dto => new Book
            {
                Id = dto.BookID, // Assuming Book has an Id property
                Title = dto.Title,
                Author = dto.Author,
                PublishedYear = dto.PublishedYear,
                // Map other properties as needed
            }).ToList();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var book = new BookInsert(); // Initialize an empty BookInsert object
            return PartialView("_Create", book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookInsert book)
        {
            //if (ModelState.IsValid)
            //{
                await _bookService.AddBookAsync(book);
                //return Json(new { success = true });
            //}
            return PartialView("_Create", book);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return PartialView("_Edit", book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookUpdate book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.UpdateBookAsync(book);
                return Json(new { success = true });
            }
            return PartialView("_Edit", book);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return PartialView("_Delete", book);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return Json(new { success = true });
        }
    }
}
