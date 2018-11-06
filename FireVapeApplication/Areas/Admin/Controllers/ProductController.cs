using BLL.DTO;
using BLL.Interfaces;
using FireVapeApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FireVapeApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : BaseController
    {
        ICrudService<ProductDTO> _productService;
        public ProductController(IAccountService accountService, ICrudService<ProductDTO> productService) : base(accountService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Response.StatusCode == 401)
            {
                return Unauthorized();
            }

            return View(_productService.FindAll());
        }
    }
}