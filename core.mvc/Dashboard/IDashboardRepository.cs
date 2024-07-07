using core.mvc.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.mvc.Dashboard
{
    public interface IDashboardRepository
    {
        Task<IEnumerable<BookDto>> GetAllDashBoardFromStoredProcedureAsync();
    }
    public interface IDashboardService
    {
        IEnumerable<BookDto> GetAllDashBoard();
    }
}
