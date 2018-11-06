using BLL.Interfaces;
using FireVapeApplication.Controllers;
using FireVapeApplication.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FireVapeApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : BaseController
    {
        public AccountController(IAccountService accountService) : base(accountService) { }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserVM user)
        {
            if (ModelState.IsValid)
            {
                if (AccountService.Authorize(user.Username, user.Password) != null)
                {
                    var token = AccountService.Client.Token;
                    Response.Cookies.Append(AuthenticateKey, token, new CookieOptions { Expires = DateTime.Now.AddYears(1) });
                    return View("Redirecting");
                }
            }
            ModelState.AddModelError("Model", "Упс, кажется вы ввели неверные данные...");
            return View("Index", user);
        }
    }
}