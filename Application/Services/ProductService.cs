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
            throw new NotImplementedException();
        }

        public Task<bool> Delete(AddProductViewModel product)
        {
            throw new NotImplementedException();
        }
    }
}
