using Ethereal.Data;
using Ethereal.Models;
using Ethereal.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ethereal.Areas.admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;

        public AccountController(AppDbContext context, UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(VmRegister model)
        {

            if (ModelState.IsValid)
            {
                CustomUser customUser = new CustomUser()
                {
                    Name=model.Name,
                    Surname=model.Surname,  
                    Email=model.Email,
                    PhoneNumber=model.Phone,
                    UserName=model.Email
                };


                var result = await _userManager.CreateAsync(customUser, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(customUser, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(model);    
                }
            }

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Login(VmRegister model)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(model);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login" , "Account");
        }
    }
}
