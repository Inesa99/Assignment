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

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductListViewModel>>> GetProductList()
        {
            List<ProductListViewModel> products = await _productService.ProductList();
            if (products == null) return Ok("You haven't Products!!!");
            return Ok(products);
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                ProductInfoViewModel product = await _productService.GetProductById(id);
                return Ok(product);
            }
            catch(ArgumentException)
            {
                return BadRequest();
            }
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> AddProduct(AddProductViewModel product)
        {
            if(await _productService.AddProduct(product)) return Ok();
            return BadRequest();
        }
        [HttpPut,Authorize]
        public async Task<IActionResult> UpdateProduct(UpdateProductViewModel product)
        {
            if (await _productService.UpdateProducrt(product)) return Ok();
            return BadRequest();
        }
        [HttpDelete, Authorize]
        public async Task<IActionResult> DeleteProduct(int id) {
            if (await _productService.DeleteProduct(id)) return Ok();
            return BadRequest();
        }
    }
}