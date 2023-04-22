using Order.Entities.Models;
using Order.Entities.Models.DTOs;

namespace Order.Service.IService
{
    public interface IProductService
    {
        public void AddProduct(Product product);
        public Product GetProduct(string name, bool trackChanges);
        public decimal CountProductsTotal(IEnumerable<Product> products);
        //public void AddProductsToOrder(Entities.Models.Order order, IEnumerable<ProductForOrderDTO> products);
    }
}
