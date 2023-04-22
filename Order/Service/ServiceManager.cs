using Order.Contracts;
using Order.Service.IService;

namespace Order.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly IRepositoryManager _repositoryManager;
        private IProductService _productService;
        private IOrderService _orderService;
        private IOrderProductsService _orderProductsService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IProductService Product
        {
            get
            {
                if (_productService == null)
                {
                    _productService = new ProductService(_repositoryManager.Product);
                }

                return _productService;
            }
        }

        public IOrderService Order
        {
            get
            {
                if (_orderService == null)
                {
                    _orderService = new OrderService(_repositoryManager.Order);
                }

                return _orderService;
            }
        }

        public IOrderProductsService OrderProducts
        {
            get
            {
                if (_orderProductsService == null)
                {
                    _orderProductsService = new OrderProductsService(_repositoryManager.OrderProducts);
                }

                return _orderProductsService;
            }
        }

        public async Task SaveAsync()
        {
            await _repositoryManager.SaveAsync();
        }
    }
}
