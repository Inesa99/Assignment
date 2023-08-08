using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProduct
    {
        public Task<bool> AddProduct(AddProductViewModel product);
        public Task<bool> DeleteProduct(int id);
        public Task<bool> UpdateProducrt(UpdateProductViewModel product);
        public Task<ProductInfoViewModel> GetProductById(int id);
        public Task<List<ProductListViewModel>> ProductList();

    }
}
