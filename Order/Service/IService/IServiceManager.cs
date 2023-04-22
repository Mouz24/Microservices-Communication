using Order.Contracts;

namespace Order.Service.IService
{
    public interface IServiceManager
    {
        IProductService Product { get; }
        IOrderService Order { get; }
        IOrderProductsService OrderProducts { get; }
        Task SaveAsync();
    }
}
