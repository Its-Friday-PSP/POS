using API.DTOs;
using API.Model;
using AutoMapper;

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
            //CreateMap<Payment, PaymentDTO>();

            /*CreateMap<ServiceOrderDTO, ServiceOrder>();
            CreateMap<ProductOrderDTO, ProductOrder>();*/

            /*CreateMap<OrderItemDTO, OrderItem>()
                .ForMember(orderItem => orderItem.Order, opt => opt.Ignore())
                .ForMember(orderItem => orderItem.Product, opt => opt.Ignore());*/

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
