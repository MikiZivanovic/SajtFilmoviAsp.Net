using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Data.ViewModels;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicatonUser> _userManager;
        private readonly SignInManager<ApplicatonUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicatonUser> userManager, SignInManager<ApplicatonUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Login()
        {
            return View(new LogInVM());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LogInVM loginVM)
        {
            //if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.ImejlAdresa);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Sifra);
                if (passwordCheck)
                { 
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Sifra, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Filmovi");
                    }
                }
                TempData["Error"] = "Pogresni podaci. Molimo Vas, pokusajte ponovo!";
                return View(loginVM);
            }

            TempData["Error"] = "Pogresni podaci. Molimo Vas, pokusajte ponovo!";
            return View(loginVM);


        }
        public IActionResult Registracija()
        {
            return View(new RegistracijaVM());
        }


        [HttpPost]
        public async Task<IActionResult> Registracija(RegistracijaVM regVM)
        {
            //if (!ModelState.IsValid) return View(regVM);

            var user = await _userManager.FindByEmailAsync(regVM.ImejlAdresa);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(regVM);
            }

            var newUser = new ApplicatonUser()
            {
                Godine = regVM.Godine,
                PunoIme = regVM.PunoIme,
                Email = regVM.ImejlAdresa,
                UserName = regVM.ImejlAdresa,
                
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, regVM.Sifra);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return View("RegistracijaUspela");
        }
        [HttpPost]
        public async Task<IActionResult> Logout() {

            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Filmovi");
        }

        public IActionResult Grafik()
        {

            return View();
        }
    }
}
