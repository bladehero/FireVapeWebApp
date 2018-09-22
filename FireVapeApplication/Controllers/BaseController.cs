using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FireVapeApplication.Controllers
{
    public abstract class BaseController : Controller
    {
        public const string AuthenticateKey = "__auth_key";
        protected IAccountService AccountService { get;  }
        
        public BaseController(IAccountService accountService) : base()
        {
            AccountService = accountService;
        }

        protected void SetToken(string token)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.MaxValue;

            Response.Cookies.Append(AuthenticateKey, token, option);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Request.Cookies.TryGetValue(AuthenticateKey, out string value);
            ViewBag.Client = AccountService.Authenticate(value);
            base.OnActionExecuting(context);
        }
    }
}
