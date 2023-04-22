using Order.Contracts;
using Order.Entities;
using Order.Entities.Models;
using Order.Entities.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(OrderContext orderContext) : base(orderContext)
        {
        }

        public void AddProduct(Product product)
        {
            Create(product);
        }

        public Product GetProduct(string name, bool trackChanges)
        {
            return FindByCondition(product => product.Name.Equals(name), trackChanges).FirstOrDefault();
        }
    }
}
