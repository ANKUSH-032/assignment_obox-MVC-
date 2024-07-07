using core.mvc.Book;
using core.mvc.Login;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture
{
    public class AccountRepository : IAccountRepository
    {
        private readonly LibraryDbContext _context;

        public AccountRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LoginDto>> GetUserDetailasAsync(string username)
        {
            var param = new SqlParameter("@UserName", username);

            var logins = await _context.LoginDto
                .FromSqlRaw("EXEC [dbo].[uspGetUserDetails] @UserName", param)
                .ToListAsync(); // Use ToListAsync() to execute the query and retrieve the results

            return logins; // Return IEnumerable<LoginDto>
        }

    }
}
