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

            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>();

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();

            CreateMap<PaymentDTO, Payment>();
            CreateMap<Payment, PaymentDTO>();

            CreateMap<Tip, TipDTO>();
            CreateMap<TipDTO, Tip>();
            //CreateMap<Payment, PaymentDTO>();

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
                            (Guid)serviceTimeSlotsDTO.EmployeeId!,
                            (DateTime)serviceTimeSlotsDTO.StartTime!,
                            (DateTime)serviceTimeSlotsDTO.EndTime!,
                            (bool)serviceTimeSlotsDTO.IsBooked!
                        );
                    return serviceTimeSlots;
                });

            CreateMap<ServiceDTO, Service>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id ?? Guid.Empty))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name ?? string.Empty))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description ?? string.Empty))
                //.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.DurationInMinutes, opt => opt.MapFrom(src => src.DurationInMinutes ?? 0))
                .ForMember(dest => dest.ServiceTimeSlots, opt => opt.MapFrom((src, dest, destMember, context) =>
                    src.ServiceTimeSlots != null
                        ? src.ServiceTimeSlots.Select(dto => context.Mapper.Map<ServiceTimeSlots>(dto)).ToList()
                        : new List<ServiceTimeSlots>()))
                .ForMember(dest => dest.ServiceOrderId, opt => opt.Ignore());

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
