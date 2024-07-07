using core.mvc.Book;
using core.mvc.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace assignment_obox.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

       
        public ActionResult Index()
        {
            var bookDtos = _dashboardService.GetAllDashBoard();
            var books = MapBookDtoToBook(bookDtos);
            return View(books);
        }
        private IEnumerable<Book> MapBookDtoToBook(IEnumerable<BookDto> bookDtos)
        {
            return bookDtos.Select(dto => new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                PublishedYear = dto.PublishedYear,
                Quantity = dto.Quantity,
                // Map other properties as needed
            }).ToList();
        }
    }
}
