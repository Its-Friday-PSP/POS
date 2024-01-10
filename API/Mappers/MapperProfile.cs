using API.DTOs;
using API.DTOs.Request;
using API.DTOs.Response;
using API.Model;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace API.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Discount, DiscountDTO>();
            CreateMap<DiscountDTO, Discount>();

            CreateMap<CustomerDiscount, CustomerDiscountDTO>();
            CreateMap<CustomerDiscountDTO, CustomerDiscount>();

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

            CreateMap<Order, OrderCreationResponseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrderType, opt => opt.MapFrom(src => src.OrderType))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.AppliedDiscounts, opt => opt.MapFrom(src => src.OrderDiscounts.Select(x => x.Discount)))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => 0));

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
                            (Guid)serviceTimeSlotsDTO.CustomerId!,
                            (Guid)serviceTimeSlotsDTO.EmployeeId!,
                            (DateTime)serviceTimeSlotsDTO.StartTime!,
                            (DateTime)serviceTimeSlotsDTO.EndTime!,
                            (bool)serviceTimeSlotsDTO.IsBooked!
                        );
                    return serviceTimeSlots;
                });

            CreateMap<ServiceTimeSlots, ServiceTimeSlotsDTO>()
                .ConvertUsing(serviceTimeSlots => new ServiceTimeSlotsDTO
                {
                    CustomerId = serviceTimeSlots.CustomerId, 
                    EmployeeId = serviceTimeSlots.EmployeeId, 
                    StartTime = serviceTimeSlots.StartTime,
                    EndTime = serviceTimeSlots.EndTime, 
                    IsBooked = serviceTimeSlots.IsBooked 
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

            CreateMap<Service, ServiceDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)) 
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                //.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.DurationInMinutes, opt => opt.MapFrom(src => src.DurationInMinutes))
                .ForMember(dest => dest.ServiceTimeSlots, opt => opt.MapFrom(src => src.ServiceTimeSlots)) 
                ;


            //CreateMap<OrderCreationRequestDTO, Order>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            //    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Now))
            //    .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
            //    .ForMember(dest => dest.Tip, opt => opt.MapFrom(src => src.Tip))

            //CreateMap<OrderDTO, Order>()
            //    .ConvertUsing((orderDto, _, context) =>
            //    {
            //        if (orderDto.OrderType == OrderTypeDTO.SERVICE)
            //        {
            //            var serviceOrder = new ServiceOrder((Guid)orderDto.Id!);
            //            return serviceOrder;
            //        }
            //        else
            //        {
            //            orderDto.ProductOrder!.OrderItems!.Select(orderItemDto => new OrderItem(
            //                (Guid)orderItemDto.ProductId!,
            //                (Guid)orderDto.Id!,
            //                (int)orderItemDto.Amount!,
            //                (int)orderItemDto.Index!));
            //            var orderItems = context.Mapper.Map<IEnumerable<OrderItem>>(orderDto.ProductOrder!.OrderItems);
            //            var productOrder = new ProductOrder((Guid)orderDto.Id!) { OrderItems = orderItems };

            //            return productOrder;
            //        }
            //    });

            //CreateMap<Order, OrderDTO>();
            //CreateMap<OrderItem, OrderItemDTO>();
        }
    }
}
