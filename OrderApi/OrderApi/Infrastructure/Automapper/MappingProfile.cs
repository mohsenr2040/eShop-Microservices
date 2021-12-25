using AutoMapper;
using OrderApi.Domain;
using OrderApi.Domain.Entities;
using OrderApi.Models;

namespace OrderApi.Infrastructure.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderModel, Order>()
                .ForMember(x => x.OrderState, opt => opt.MapFrom(src => 1));
            CreateMap<OrderDetailsModel, OrderDetail>();
        }
    }
}