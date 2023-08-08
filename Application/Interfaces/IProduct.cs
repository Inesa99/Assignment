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
        public Task<bool> AddProduct(AddProductViewModel product);//done
        public Task<bool> DeleteProduct(int id);//
        public Task<bool> UpdateProducrt(UpdateProductViewModel product);//done
        public Task<ProductInfoViewModel> GetProductById(int id);//done
        public Task<List<ProductListViewModel>> ProductList();//done

    }
}
