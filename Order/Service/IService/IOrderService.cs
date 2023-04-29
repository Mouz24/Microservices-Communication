using Order.Entities.Models;
using Order.Entities.Models.DTOs;

namespace Order.Service.IService
{
    public interface IOrderService
    {
        public Order.Entities.Models.Order CreateOrder();
        public void AddOrder(Entities.Models.Order order);
        public Task<IEnumerable<Entities.Models.Order>> GetAll(bool trackChanges);
        public List<OrderDTO> GetOrder(Guid orderId);
    }
}
