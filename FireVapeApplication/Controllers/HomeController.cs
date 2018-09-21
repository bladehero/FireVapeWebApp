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
    }
}
