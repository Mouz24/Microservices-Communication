using Order.Contracts;
using Order.Entities.Models;
using Order.Entities.Models.DTOs;
using Order.Service.IService;

namespace Order.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void AddOrder(Entities.Models.Order order)
        {
            _orderRepository.AddOrder(order);
        }

        public Entities.Models.Order CreateOrder()
        {
            return _orderRepository.CreateOrder();
        }

        public async Task<IEnumerable<Entities.Models.Order>> GetAll(bool trackChanges)
        {
            return await _orderRepository.GetAll(trackChanges);
        }

        public List<OrderDTO> GetOrder(Guid orderId)
        {
            return _orderRepository.GetOrder(orderId);
        }
    }
}
