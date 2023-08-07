using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class ProductInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }//can't be dublicate
        public bool Available { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
