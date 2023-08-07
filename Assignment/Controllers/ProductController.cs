﻿using Application.Interfaces;
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

        [HttpGet(Name = "Get Product List"), AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductListViewModel>>> GetProductList()
        {
            List<ProductListViewModel> products = await _productService.ProductList();
            if (products == null) return Ok("You haven't Products!!!");
            return Ok(products);
        }

        [HttpGet("{id}")]
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

    }
}