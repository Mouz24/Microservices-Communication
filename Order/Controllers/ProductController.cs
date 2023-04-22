using AutoMapper;
using Order.Contracts;
using Order.Entities.Models;
using Order.Entities.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Service.IService;

namespace Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected readonly IServiceManager _serviceManager;
        protected readonly IMapper _mapper;

        public ProductController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody]ProductDTO productDTO)
        {
            if (productDTO is null)
            {
                return BadRequest("productDTO is null");
            }

            var product = _serviceManager.Product.GetProduct(productDTO.Name, false);
            if (product is not null)
            {
                return BadRequest("Product already exists");
            }

            var productToCreate = _mapper.Map<Product>(productDTO);

            _serviceManager.Product.AddProduct(productToCreate);

            _serviceManager.SaveAsync();

            return CreatedAtRoute(new { id = productToCreate.Id }, productToCreate);
        }
    }
}
