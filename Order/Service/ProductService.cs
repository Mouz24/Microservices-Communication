using Order.Contracts;
using Order.Entities.Models;
using Order.Entities.Models.DTOs;
using Order.Service.IService;

namespace Order.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        //public void AddProductsToOrder(Entities.Models.Order order, IEnumerable<ProductForOrderDTO> products)
        //{
        //    _productRepository.AddProductsToOrder(order, products);
        //}

        public decimal CountProductsTotal(IEnumerable<Product> products)
        {
            decimal total = 0;

            foreach (var product in products)
            {
                var productToCheck = GetProduct(product.Name, false);

                total += productToCheck.Price;
            }

            return total;
        }

        public Product GetProduct(string name, bool trackChanges)
        {
            return _productRepository.GetProduct(name, trackChanges);
        }
    }
}
