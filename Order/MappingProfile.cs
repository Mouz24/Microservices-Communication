using AutoMapper;
using Order.Entities.Models;
using Order.Entities.Models.DTOs;

namespace Order
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<ProductForOrderDTO,Product>();
            CreateMap<Order.Entities.Models.Order, OrderDTO>();
        }
    }
}
