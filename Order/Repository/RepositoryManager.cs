using Order.Contracts;
using Order.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private OrderContext _orderContext;
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private IOrderProductsRepository _orderProductsRepository;

        public RepositoryManager(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public IOrderRepository Order
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(_orderContext);
                return _orderRepository;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_orderContext);
                return _productRepository;
            }
        }

        public IOrderProductsRepository OrderProducts
        {
            get
            {
                if (_orderProductsRepository == null)
                    _orderProductsRepository = new OrderProductsRepository(_orderContext, _productRepository);
                return _orderProductsRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _orderContext.SaveChangesAsync();
        }
    }
}
