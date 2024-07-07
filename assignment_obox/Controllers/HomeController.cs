using assignment_obox.Models;
using core.mvc.Login;
using Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace assignment_obox.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        private readonly ILoginServices _loginRepository;

        public HomeController(ILogger<HomeController> logger, JwtTokenGenerator jwtTokenGenerator, ILoginServices loginRepository)
        {
            _logger = logger;
            _jwtTokenGenerator = jwtTokenGenerator;
            _loginRepository = loginRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                var userDtos = _loginRepository.GetAllDetails(username);
                var userDetails = userDtos.FirstOrDefault();

                if (userDetails != null && username == userDetails.Username && password == userDetails.Password)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.Role, userDetails.Role!)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction("Index", "Dashboard");
                }

                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during login.");
                ModelState.AddModelError(string.Empty, "An error occurred. Please try again later.");
            }

            return View("Index"); // Return to the Index view where the login form is located
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
