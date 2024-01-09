using API.DTOs;
using API.Model;
using API.Repositories;
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

            CreateMap<ServiceTimeSlotsDTO, ServiceTimeSlots>()
                .ConvertUsing((serviceTimeSlotsDTO, _, context) =>
                {
                    var serviceTimeSlots = new ServiceTimeSlots(
                            (Guid)serviceTimeSlotsDTO.Id!,
                            (Guid)serviceTimeSlotsDTO.CustomerId!,
                            (DateTime)serviceTimeSlotsDTO.StartTime!,
                            (DateTime)serviceTimeSlotsDTO.EndTime!,
                            (bool)serviceTimeSlotsDTO.IsBooked!
                        );
                    return serviceTimeSlots;
                });

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
