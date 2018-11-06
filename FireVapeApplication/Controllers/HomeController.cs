using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using BLL.DTO;

namespace FireVapeApplication.Controllers
{
    public class HomeController : BaseController
    {
        ICrudService<LiquidDTO> liquidService;

        public HomeController(ICrudService<LiquidDTO> liquidService, IAccountService accountService) : base(accountService)
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
