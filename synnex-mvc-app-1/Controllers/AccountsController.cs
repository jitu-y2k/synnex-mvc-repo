using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using synnex_mvc_app_1.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace synnex_mvc_app_1.Controllers
{
    public class AccountsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (login.Email == "jitu@gmail.com" &&  login.Password == "jitu@1234")
            {
                var claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.Email, login.Email));
                claims.Add(new Claim(ClaimTypes.Name, login.Email));

                claims.Add(new Claim("Age", "18"));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principle = new ClaimsPrincipal(claimsIdentity);


                //AuthenticationProperties authenticationProperties = new AuthenticationProperties()
                //{

                //};

                HttpContext.SignInAsync(principle);

                return Redirect("/student/index");

            }
            else
            {
                return Redirect("/home/error");
            }

        }

        //[HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
            
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}

