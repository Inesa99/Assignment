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
        public Task<bool> Add(AddProductViewModel product);
        public Task<bool> Delete(AddProductViewModel product);
        public Task<bool> Update(EditProductViewModel product);
        public List<ProductListViewModel> ProductList();

    }
}
