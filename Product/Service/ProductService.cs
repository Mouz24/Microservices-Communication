using Product.Contracts;
using Product.Service.IService;

namespace Product.Service
{
    public class ProductService : IProductService
    {
        protected readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IEnumerable<Entities.Models.Product>> GetAllProducts(bool trackChanges)
        {
            return _productRepository.GetAllProducts(trackChanges);
        }

        public Entities.Models.Product GetProductById(Guid productId, bool trackChanges)
        {
            return _productRepository.GetProductById(productId, trackChanges);
        }
    }
}