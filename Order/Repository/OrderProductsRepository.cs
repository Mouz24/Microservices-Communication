using Order.Contracts;
using Order.Entities;
using Order.Entities.Models;

namespace Order.Repository
{
    public class OrderProductsRepository : BaseRepository<OrderProducts>, IOrderProductsRepository
    {
        private IProductRepository _productRepository;
        public OrderProductsRepository(OrderContext orderContext, IProductRepository productRepository) : base(orderContext)
        {
            _productRepository = productRepository;
        }

        public void AddProductsToOrder(Entities.Models.Order order, IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                var productEntity = _productRepository.GetProduct(product.Name, false);

                AddProductToOrder(order, productEntity);
            }
        }

        public void AddProductsToOrderDTO(Entities.Models.Order order, IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                var productEntity = _productRepository.GetProduct(product.Name, false);

                AddProductToOrder(order, productEntity);
            }
        }

        public void AddProductToOrder(Entities.Models.Order order, Product product)
        {
            OrderProducts orderProducts = new OrderProducts
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                ProductId = product.Id,
            };

            Create(orderProducts);
        }
    }
}
