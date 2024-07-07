using core.mvc.Book;
using core.mvc.Dashboard;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly LibraryDbContext _context;

        public DashboardRepository(LibraryDbContext context)
        {
            _context = context;
        }

        //public async Task<List<BookDto>> GetDashboardDataAsync()
        //{
        //    return (await _context.GetDashboardDataAsync()).ToList();
        //}
        public async Task<IEnumerable<BookDto>> GetAllDashBoardFromStoredProcedureAsync()
        {
            return await _context.BooksDto.FromSqlRaw("EXEC [dbo].[uspGetDataBoard]").ToListAsync();
        }
    }
}
