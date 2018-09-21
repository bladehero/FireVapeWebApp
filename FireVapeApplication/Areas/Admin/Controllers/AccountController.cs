using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FireVapeApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        [Route("[area]/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}