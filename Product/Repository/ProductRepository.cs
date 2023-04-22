using Microsoft.EntityFrameworkCore;
using Product.Contracts;
using Product.Entities;
using Product.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repositories
{
    public class ProductRepository : BaseRepository<Entities.Models.Product>, IProductRepository
    {
        public ProductRepository(ProductContext productContext) : base(productContext) { }

        public async Task<IEnumerable<Entities.Models.Product>> GetAllProducts(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(product => product.Name).ToListAsync();
        }

        public Entities.Models.Product GetProductById(Guid productId, bool trackChanges)
        {
            return FindByCondition(product => product.Id.Equals(productId), trackChanges).FirstOrDefault();
        }
    }
}
