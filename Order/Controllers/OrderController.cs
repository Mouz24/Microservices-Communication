using AutoMapper;
using Order.Contracts;
using Order.Entities.Models;
using Order.Entities.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Service.IService;
using Order.Service;

namespace Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServiceManager _serviceManager;
        public OrderController(IMapper mapper, IServiceManager serviceManager)
        {
            _mapper = mapper;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _serviceManager.Order.GetAll(false);

            return Ok(orders);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody]IEnumerable<ProductForOrderDTO> productsDTO)
        {
            if (productsDTO == null)
            {
                return BadRequest("productsDTO is null");
            }

            var productEntities = _mapper.Map<IEnumerable<Product>>(productsDTO);
            
            var order = _serviceManager.Order.CreateOrder();
            order.Total = _serviceManager.Product.CountProductsTotal(productEntities);
            
            _serviceManager.Order.AddOrder(order);

            _serviceManager.OrderProducts.AddProductsToOrder(order, productEntities);
            
            _serviceManager.SaveAsync();

            var orderToReturn = _serviceManager.Order.GetOrder(order.Id);

            return CreatedAtRoute(new { Id = order.Id}, orderToReturn);
        }
    }
}
