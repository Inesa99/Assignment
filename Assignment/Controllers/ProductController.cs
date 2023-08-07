using Application.Interfaces;
using Common.ViewModels;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productService;
        public ProductController(IProduct productService)
        {
            _productService = productService;
        }

        [HttpGet(Name = "Get Product List"),AllowAnonymous]
        public ActionResult<IEnumerable<ProductListViewModel>> GetProductList()
        {
            List<ProductListViewModel> products = _productService.ProductList();
            return Ok(products);
        }

    }
}