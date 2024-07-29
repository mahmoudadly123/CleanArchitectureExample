using AutoMapper;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Order;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.OrderItem;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.ShippingAddress;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Tax;
using CleanArchitecture.Domain.Aggregates;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Application.ObjectMapping.AutoMapper.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region BookDto <=> Book

            CreateMap<Book, ViewBookDto>().ReverseMap();
            CreateMap<Book, CreateBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
            CreateMap<Book, DeleteBookDto>().ReverseMap();

            #endregion

            #region TaxDto <=> Tax

            CreateMap<Tax, ViewTaxDto>().ReverseMap();
            CreateMap<Tax, CreateTaxDto>().ReverseMap();
            CreateMap<Tax, UpdateTaxDto>().ReverseMap();
            CreateMap<Tax, DeleteTaxDto>().ReverseMap();

            #endregion

            #region ShippingAddressDto <=> ShippingAddress

            CreateMap<ShippingAddress, ViewShippingAddressDto>().ReverseMap();
            CreateMap<ShippingAddress, CreateShippingAddressDto>().ReverseMap();
            CreateMap<ShippingAddress, UpdateShippingAddressDto>().ReverseMap();

            #endregion

            #region OrderItemDto <=> OrderItem

            CreateMap<OrderItem, ViewOrderItemDto>().ReverseMap();
            CreateMap<OrderItem, CreateOrderItemDto>().ReverseMap();
            CreateMap<OrderItem, UpdateOrderItemDto>().ReverseMap();
            CreateMap<OrderItem, DeleteOrderItemDto>().ReverseMap();

            #endregion

            #region OrderDto <=> Order

            CreateMap<Order, ViewOrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
            CreateMap<Order, DeleteOrderDto>().ReverseMap();

            #endregion
        }
    }
}
