using Application.Interfaces;
using Common.ViewModels;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService:IProduct
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddProduct(AddProductViewModel product)
        {
            if (_context.Products.Select(p => p.Name).Contains(product.Name)) return false;
            Product newProduct = new Product
            {
                Name = product.Name,
                Available = product.Available,
                Price = product.Price > 0 ? product.Price : 0,//price cant be negative
                Description = product.Description,
                DateCreated = DateTime.Now
            };
            await _context.Products.AddAsync(newProduct);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateProducrt(UpdateProductViewModel product)
        {
            Product changedProduct = _context.Products
                .Where(p => p.Id == product.Id).First();
            if (changedProduct == null) return false;
            if (changedProduct.Name != product.Name) {//If user wont to change name of product
                if (_context.Products.Select(p => p.Name).Contains(product.Name)) return false;//product name is unique
            }
            changedProduct.Name = product.Name;
            changedProduct.Available = product.Available;
            changedProduct.Price = product.Price > 0 ? product.Price : 0;//price cant be negative
            changedProduct.Description = product.Description;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProductListViewModel>> ProductList()
        {
            List<ProductListViewModel> products = await _context.Products
                .Select(p => new ProductListViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Available = p.Available,
                    Price = p.Price,
                }).ToListAsync();
            return products;
        }

        public Task<bool> Delete(AddProductViewModel product)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductInfoViewModel> GetProductById(int id)
        {
            var result = await _context.Products
            .Select(p => new ProductInfoViewModel
            {
                    Id = p.Id,
                    Name = p.Name,
                    Available = p.Available,
                    Price = p.Price,
                    Description = p.Description,
                    DateCreated = p.DateCreated
            }).FirstOrDefaultAsync(p => p.Id == id);

            if (result == null) throw new ArgumentException();

            return result;
        }
    }
}
