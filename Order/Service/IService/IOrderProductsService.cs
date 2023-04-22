using Order.Entities.Models;

namespace Order.Service.IService
{
    public interface IOrderProductsService
    {
        //public void AddProductToOrder(Entities.Models.Order order, Product product);
        public void AddProductsToOrder(Entities.Models.Order order, IEnumerable<Product> products);
    }
}
