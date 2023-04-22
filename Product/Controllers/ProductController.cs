using Microsoft.AspNetCore.Mvc;
using Product.RabbitMQ;
using Product.Service.IService;

namespace Product.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IRabbitMQProducer _rabbitMQProducer;

        public ProductController(IProductService productService, IRabbitMQProducer rabbitMQProducer)
        {
            _productService = productService;
            _rabbitMQProducer = rabbitMQProducer;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllProducts(false);
            if (products is null)
            {
                return NotFound("There is no any product");
            }

            return Ok(products);
        }

        [HttpGet]
        [Route("{productId}")]
        public IActionResult GetProduct(Guid productId)
        {
            var product = _productService.GetProductById(productId, false);
            if (product is null)
            {
                return NotFound("The product doesn't exist");
            }

            _rabbitMQProducer.SendMessage(product);

            return Ok(product);
        }
    }
}
