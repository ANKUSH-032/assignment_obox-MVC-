using core.mvc.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.mvc.Login
{
    public class AccountServices : ILoginServices

    {
        private readonly IAccountRepository _loginRepository;
        public AccountServices(IAccountRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public IEnumerable<LoginDto> GetAllDetails(string username)
        {
            return _loginRepository.GetUserDetailasAsync(username).Result;
        }

    }
}
