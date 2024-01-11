using API.DTOs;
using API.DTOs.Request;
using API.DTOs.Response;
using API.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.ComponentModel.DataAnnotations;
using API.Shared;

namespace API.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PriceDTO, Price>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount * (decimal)Constants.DECIMAL_MULTIPLIER))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency));

            CreateMap<Price, PriceDTO>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount / (decimal) Constants.DECIMAL_MULTIPLIER))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency));

            CreateMap<CustomerDiscount, CustomerDiscountDTO>();
            CreateMap<CustomerDiscountDTO, CustomerDiscount>();

            CreateMap<ProductOrder, ProductOrderDTO>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));

            CreateMap<OrderItemDTO, OrderItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Index, opt => opt.MapFrom(src => src.Index))
                .ForMember(dest => dest.ProductOrder, opt => opt.Ignore());

            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Index, opt => opt.MapFrom(src => src.Index));

            CreateMap<AuthDTO, Auth>();
            CreateMap<Auth, AuthDTO>();

            CreateMap<CustomerDTO, Customer>()
                .ForMember(dest => dest.StripeId, opt => opt.MapFrom(_ => (string?)null));
            CreateMap<Customer, CustomerDTO>();

            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>();

            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.StripeId, opt => opt.MapFrom(_ => (string?)null));
            CreateMap<Product, ProductDTO>();

            CreateMap<PaymentDTO, Payment>();
            CreateMap<Payment, PaymentDTO>();

            CreateMap<Tip, TipDTO>();
            CreateMap<TipDTO, Tip>();

            CreateMap<ServiceDTO, Service>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id ?? Guid.Empty))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name ?? string.Empty))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description ?? string.Empty))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.DurationInMinutes, opt => opt.MapFrom(src => src.DurationInMinutes ?? 0))
                .ForMember(dest => dest.ServiceTimeSlots, opt => opt.MapFrom((src => src.ServiceTimeSlots)))
                .ForMember(dest => dest.StripeId, opt => opt.MapFrom(_ => (string?)null));

            CreateMap<Service, ServiceDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.DurationInMinutes, opt => opt.MapFrom(src => src.DurationInMinutes))
                .ForMember(dest => dest.ServiceTimeSlots, opt => opt.MapFrom(src => src.ServiceTimeSlots));

            CreateMap<ServiceOrder, ServiceOrderDTO>();

            CreateMap<OrderItemCreationRequestDTO, OrderItem>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Index, opt => opt.MapFrom(src => src.Index))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.OrderId, opt => opt.Ignore())
                .ForMember(dest => dest.ProductOrder, opt => opt.Ignore());

            CreateMap<OrderItem, OrderItemCreationResponseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Index, opt => opt.MapFrom(src => src.Index));

            CreateMap<ServiceTimeSlotsRequestDTO, ServiceTimeSlots>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.ServiceId, opt => opt.Ignore())
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.IsBooked, opt => opt.MapFrom(src => true));

            CreateMap<EmployeeServiceTimeSlotsRequestDTO, ServiceTimeSlots>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.ServiceId, opt => opt.Ignore())
                .ForMember(dest => dest.EmployeeId, opt => opt.Ignore())
                .ForMember(dest => dest.CustomerId, opt => opt.Ignore())
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.IsBooked, opt => opt.MapFrom(src => true));

            CreateMap<ServiceServiceTimeSlotsCreationRequestDTO, ServiceTimeSlots>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.ServiceId, opt => opt.Ignore())
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.CustomerId, opt => opt.Ignore())
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.IsBooked, opt => opt.MapFrom(src => true));

            CreateMap<ServiceCreationRequestDTO, Service>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.DurationInMinutes, opt => opt.MapFrom(src => src.DurationInMinutes))
                .ForMember(dest => dest.ServiceTimeSlots, opt => opt.MapFrom(src => src.ServiceTimeSlots))
                .ForMember(dest => dest.StripeId, opt => opt.MapFrom(src => src.StripeId));

            CreateMap<EmployeeCreationRequestDTO, Employee>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Auth, opt => opt.MapFrom(src => src.Auth))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.ServiceTimeSlots, opt => opt.MapFrom(src => src.ServiceTimeSlots));

            CreateMap<ServiceOrder, OrderDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrderType, opt => opt.MapFrom(src => src.OrderType))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Tip, opt => opt.MapFrom(src => src.Tip))
                .ForMember(dest => dest.ProductOrder, opt => opt.Ignore())
                .ForMember(dest => dest.ServiceOrder, opt => opt.MapFrom(src => src));

            CreateMap<ProductOrder, OrderDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrderType, opt => opt.MapFrom(src => src.OrderType))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Tip, opt => opt.MapFrom(src => src.Tip))
                .ForMember(dest => dest.ProductOrder, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.ServiceOrder, opt => opt.Ignore());

            CreateMap<Order, OrderCreationResponseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrderType, opt => opt.MapFrom(src => src.OrderType))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.AppliedDiscounts, opt => opt.MapFrom(src => src.OrderDiscounts.Select(x => x.Discount)))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            CreateMap<DiscountCreationRequestDTO, Discount>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DiscountType, opt => opt.MapFrom(src => src.DiscountType))
                .ForMember(dest => dest.ApplicableOrderType, opt => opt.MapFrom(src => src.ApplicableOrderType))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Percentage, opt => opt.MapFrom(src => src.Percentage))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.ValidFrom, opt => opt.MapFrom(src => src.ValidFrom))
                .ForMember(dest => dest.ValidTo, opt => opt.MapFrom(src => src.ValidTo))
                .ForMember(dest => dest.IsStackable, opt => opt.MapFrom(src => src.IsStackable))
                .ForMember(dest => dest.CustomerDiscounts, opt => opt.MapFrom(src => new List<CustomerDiscount>()));
            CreateMap<Discount, DiscountCreationResponseDTO>();

            CreateMap<ProductCreationRequestDTO, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.AmountInStock, opt => opt.MapFrom(src => src.AmountInStock))
                .ForMember(dest => dest.StripeId, opt => opt.MapFrom(src => src.StripeId))
                .ForMember(dest => dest.OriginCountry, opt => opt.MapFrom(src => src.OriginCountry));

            CreateMap<Product, ProductCreationResponseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.AmountInStock, opt => opt.MapFrom(src => src.AmountInStock))
                .ForMember(dest => dest.StripeId, opt => opt.MapFrom(src => src.StripeId))
                .ForMember(dest => dest.OriginCountry, opt => opt.MapFrom(src => src.OriginCountry));

            CreateMap<ServiceTimeSlotsDTO, ServiceTimeSlots>()
                .ConvertUsing((serviceTimeSlotsDTO, _, context) =>
                {
                    var serviceTimeSlots = new ServiceTimeSlots(
                            (Guid)serviceTimeSlotsDTO.CustomerId!,
                            (Guid)serviceTimeSlotsDTO.EmployeeId!,
                            (DateTime)serviceTimeSlotsDTO.StartTime!,
                            (DateTime)serviceTimeSlotsDTO.EndTime!,
                            (bool)serviceTimeSlotsDTO.IsBooked!,
                            (Guid)serviceTimeSlotsDTO.ServiceId!
                        );
                    return serviceTimeSlots;
                });

            CreateMap<ServiceTimeSlots, ServiceTimeSlotsDTO>()
                .ConvertUsing(serviceTimeSlots => new ServiceTimeSlotsDTO
                {
                    CustomerId = serviceTimeSlots.CustomerId,
                    StartTime = serviceTimeSlots.StartTime,
                    EndTime = serviceTimeSlots.EndTime, 
                    IsBooked = serviceTimeSlots.IsBooked,
                    ServiceId = serviceTimeSlots.ServiceId
                });

            

        }
    }
}
