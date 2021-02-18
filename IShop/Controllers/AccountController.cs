using System.Threading.Tasks;
using IShop.Models;
using IShop.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Customer> _userManager;
        private readonly SignInManager<Customer> _signInManager;

        public AccountController(UserManager<Customer> userManager, SignInManager<Customer> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer
                {
                    UserName = model.Login,
                    Email = model.Email,
                    FIO = model.FIO,
                    PhoneNumber = model.Phone,
                    Address = model.Address
                };

                var newCustomer = await _userManager.CreateAsync(customer, model.Password);
                if (newCustomer.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(customer, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in newCustomer.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<string> Login([FromBody] LoginViewModel model)
        {
            if (model.Login == "" || model.Password == "") return "Поля логин/пароль должны быть заполнены!";
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Login, model.Password, false, false);
                if (!result.Succeeded)
                {
                    return "Логин/пароль введены неверно!";
                }
            }
            return "Success";
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
