using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<Entities.Models.Product>> GetAllProducts(bool trackChanges);
        Entities.Models.Product GetProductById(Guid productId, bool trackChanges);
    }
}
