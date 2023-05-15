using AutoMapper;
using Entities;
using DTO;
namespace LoginEx
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Category , CategoryDTO > ().ReverseMap();
            CreateMap<Order, OrderDTO > ().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO > ().ReverseMap();
            CreateMap<Product, ProductDTO>()
                 .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName)).ReverseMap();
                CreateMap<User, UserDTO > ().ReverseMap();
            CreateMap<User, UserLoginDTO > ().ReverseMap();
        }
    }
}
