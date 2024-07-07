using core.mvc.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.mvc.Login
{
    public interface IAccountRepository
    {
        Task<IEnumerable<LoginDto>> GetUserDetailasAsync(string username);
    }
    public interface ILoginServices
    {
        IEnumerable<LoginDto> GetAllDetails(string username);
    }
}
