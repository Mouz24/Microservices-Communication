using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Entities.Models.Product>> GetAllProducts(bool trackChanges);
        Entities.Models.Product GetProductById(Guid productId,bool trackChanges);
    }
}
