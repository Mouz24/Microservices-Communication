using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Contracts
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        IOrderRepository Order { get; }
        IOrderProductsRepository OrderProducts { get; }
        Task SaveAsync();
    }
}
