using Order.Entities.Models;
using Order.Entities.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Contracts
{
    public interface IOrderRepository
    {
        public Order.Entities.Models.Order CreateOrder();
        public void AddOrder(Entities.Models.Order order);
        public Task<IEnumerable<Entities.Models.Order>> GetAll(bool trackChanges);
        public List<OrderProducts> GetOrder(Guid orderId);
    }
}
