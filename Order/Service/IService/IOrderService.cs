using Order.Entities.Models;

namespace Order.Service.IService
{
    public interface IOrderService
    {
        public Order.Entities.Models.Order CreateOrder();
        public void AddOrder(Entities.Models.Order order);
        public Task<IEnumerable<Entities.Models.Order>> GetAll(bool trackChanges);
        public List<OrderProducts> GetOrder(Guid orderId);
    }
}
