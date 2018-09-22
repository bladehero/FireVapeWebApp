using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using FireVapeApplication.Controllers;
using FireVapeApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FireVapeApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : BaseController
    {
        public AccountController(IAccountService accountService) : base(accountService) { }

        [Route("[area]/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("[area]/[controller]/[action]")]
        public IActionResult Login(UserVM user)
        {
            if (ModelState.IsValid)
            {
                if (AccountService.Authorize(user.Username, user.Password) != null)
                {
                    var token = AccountService.Client.Token;
                    SetToken(token);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("Model", "Упс, кажется вы ввели неверные данные...");
            return View("Index", user);
        }
    }
}