using Application.Interfaces;
using Common.ViewModels;
using Data.Models;
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
        public async Task<bool> Add(AddProductViewModel product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(EditProductViewModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductListViewModel> ProductList()
        {
            List<ProductListViewModel> products = _context.Products
                .Select(p => new ProductListViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Available = p.Available,
                    Price = p.Price,
                }).ToList();
            return products;
        }

        public Task<bool> Delete(AddProductViewModel product)
        {
            throw new NotImplementedException();
        }
    }
}
