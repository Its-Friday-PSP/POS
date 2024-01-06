using API.DTOs;
using API.Model;
using AutoMapper;
using System.Runtime.CompilerServices;

namespace API.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AuthDTO, Auth>();
            CreateMap<Auth, AuthDTO>();

            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();

            /*CreateMap<ServiceOrderDTO, ServiceOrder>();
            CreateMap<ProductOrderDTO, ProductOrder>();*/

            //CreateMap<OrderItemDTO, OrderItem>()
            //.ForMember(orderItem => orderItem.Order, opt => opt.Ignore())
            //.ForMember(orderItem => orderItem.Product, opt => opt.Ignore());

            //CreateMap<ServiceOrderDTO, ServiceOrder>();
            //CreateMap<ServiceOrder, ServiceOrderDTO>();

            //CreateMap<Service, ServiceDTO>()
            //    .ForMember(dto => dto.ServiceTimeSlots, opt => opt.MapFrom(src => src.ServiceTimeSlots));

            //CreateMap<ServiceTimeSlots, ServiceTimeSlotsDTO>();

            //CreateMap<ServiceDTO, Service>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id ?? Guid.NewGuid()))
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name ?? string.Empty))
            //    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description ?? string.Empty))
            //    .ForMember(dest => dest.DurationInMinutes, opt => opt.MapFrom(src => src.DurationInMinutes ?? 0))
            //    .ForMember(dest => dest.ServiceTimeSlots, opt => opt.MapFrom(src => src.ServiceTimeSlots != null
            //        ? src.ServiceTimeSlots.Select(dto => new ServiceTimeSlots(
            //            dto.Id, 
            //            dto.CustomerId,
            //            dto.StartTime,
            //            dto.EndTime,
            //            dto.IsBooked))
            //            .ToList()
            //        : new List<ServiceTimeSlots>()));

            //CreateMap<ServiceTimeSlotsDTO, ServiceTimeSlots>()
            //    .ConstructUsing(dto => new ServiceTimeSlots(dto.Id, dto.CustomerId, dto.StartTime, dto.EndTime, dto.IsBooked))
            //    .ForMember(dest => dest.ServiceId, opt => opt.Ignore()); 

            CreateMap<OrderDTO, Order>()
                .ConvertUsing((orderDto, _, context) =>
                {
                    if (orderDto.OrderType == OrderTypeDTO.SERVICE)
                    {
                        var serviceOrder = new ServiceOrder((Guid)orderDto.Id!);
                        return serviceOrder;
                    }
                    else
                    {
                        orderDto.ProductOrder!.OrderItems!.Select(orderItemDto => new OrderItem(
                            (Guid)orderItemDto.ProductId!,
                            (Guid)orderDto.Id!,
                            (int)orderItemDto.Amount!,
                            (int)orderItemDto.Index!));
                        var orderItems = context.Mapper.Map<IEnumerable<OrderItem>>(orderDto.ProductOrder!.OrderItems);
                        var productOrder = new ProductOrder((Guid)orderDto.Id!) { OrderItems = orderItems };

                        return productOrder;
                    }
                });

            //CreateMap<Order, OrderDTO>();

         
            //CreateMap<OrderItem, OrderItemDTO>();
        }
    }
}
