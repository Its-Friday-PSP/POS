using API.DTOs;
using API.DTOs.Request;
using API.DTOs.Response;
using API.Model;
using API.Services.Interfaces;
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

            /*CreateMap<OrderItemDTO, OrderItem>()
                .ForMember(orderItem => orderItem.Order, opt => opt.Ignore())
                .ForMember(orderItem => orderItem.Product, opt => opt.Ignore());*/


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
