using BLL.Interfaces;
using FireVapeApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FireVapeApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : BaseController
    {
        public HomeController(IAccountService accountService) : base(accountService) { }

        public IActionResult Index()
        {
            if (HttpContext.Response.StatusCode == 401)
            {
                return Unauthorized();
            }

            return View("Index");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!AccountService.HasPermission(RoleType.Admin))
            {
                context.HttpContext.Response.StatusCode = 401;
                return;
            }
            base.OnActionExecuting(context);
        }
    }
}