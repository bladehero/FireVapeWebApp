using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FireVapeApplication.Models;
using BLL.Interfaces;
using BLL.DTO;

namespace FireVapeApplication.Controllers
{
    public class HomeController : Controller
    {
        IProductService<LiquidDTO> liquidService;

        public HomeController(IProductService<LiquidDTO> liquidService)
        {
            this.liquidService = liquidService;
        }

        public IActionResult Index()
        {
            var liquids = liquidService.FindAll();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
