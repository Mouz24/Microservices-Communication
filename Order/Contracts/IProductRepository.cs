
using Order.Entities.Models;
using Order.Entities.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Contracts
{
    public interface IProductRepository
    {
        public void AddProduct(Product product);
        public Product GetProduct(string name, bool trackChanges);
    }
}
