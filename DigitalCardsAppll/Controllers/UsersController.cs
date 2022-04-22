using DigitalCardsAppll.Data;
using DigitalCardsAppll.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCardsAppll.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterFormModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var registereduser = new User
            {
                Email = user.Email,
                UserName = user.Email,
                FullName = user.FullName
            };

            var result = await this.userManager.CreateAsync(registereduser, user.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                foreach (var err in errors)
                {
                    ModelState.AddModelError(string.Empty, err);
                }

                return View(user);
            }

            return RedirectToAction("All", "Stickers");
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginFormModel user)
        {
            var loggeduser = await this.userManager.FindByEmailAsync(user.Email);

            if (user == null)
            {
                return InvalidCredentials(user);
            }

            var passwordc = await this.userManager.CheckPasswordAsync(loggeduser, user.Password);

            if (!passwordc)
            {
                return InvalidCredentials(user);
            }

            await this.signInManager.SignInAsync(loggeduser, true);

            return RedirectToAction("All", "Stickers");
        }

        private IActionResult InvalidCredentials(UserLoginFormModel user)
        {
            const string invalidmessage = "Credentials invalid!";

            ModelState.AddModelError(string.Empty, invalidmessage);

            return View(user);
        }

    }
}
