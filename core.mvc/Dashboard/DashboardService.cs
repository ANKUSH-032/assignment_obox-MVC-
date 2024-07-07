using core.mvc.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.mvc.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashRepository;

        public DashboardService(IDashboardRepository dashRepository)
        {
            _dashRepository = dashRepository;
        }

        public IEnumerable<BookDto> GetAllDashBoard()
        {
            return _dashRepository.GetAllDashBoardFromStoredProcedureAsync().Result;
        }
    }
}
