using Order.Contracts;
using Order.Entities.Models;
using Order.Service.IService;

namespace Order.Service
{
    public class OrderProductsService : IOrderProductsService
    {
        private readonly IOrderProductsRepository _orderProductsRepository;

        public OrderProductsService(IOrderProductsRepository orderProductsRepository)
        {
            _orderProductsRepository = orderProductsRepository;
        }

        public void AddProductsToOrder(Entities.Models.Order order, IEnumerable<Product> products)
        {
            _orderProductsRepository.AddProductsToOrder(order, products);
        }

        //public void AddProductToOrder(Entities.Models.Order order, Product product)
        //{
        //    _orderProductsRepository.AddProductToOrder(order, product);
        //}
    }
}
