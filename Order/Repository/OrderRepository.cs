using Order.Contracts;
using Order.Entities;
using Order.Entities.Models;
using Order.Entities.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order.Repository;

namespace Order.Repository
{
    public class OrderRepository : BaseRepository<Entities.Models.Order>, IOrderRepository
    {
        public OrderRepository(OrderContext orderContext) : base(orderContext)
        {
        }

        public Entities.Models.Order CreateOrder()
        {
            Entities.Models.Order order = new Entities.Models.Order()
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.Now.AddHours(3)
            };

            return order;
        }

        public void AddOrder(Entities.Models.Order order)
        {
            Create(order);
        }

        public async Task<IEnumerable<Entities.Models.Order>> GetAll(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(order => order.Total).ToListAsync();
        }

        public List<OrderDTO> GetOrder(Guid orderId)
        {
            return _orderContext.OrderProducts.Include(product => product.Product).Include(order => order.Order).Where(order => order.OrderId
                .Equals(orderId))
                .Select(order => new OrderDTO
                {
                    Id = order.OrderId,
                    DateCreated = order.Order.DateCreated,
                    Total = order.Order.Total,
                    Product = order.Product
                }).ToList();
        }
    }
}
