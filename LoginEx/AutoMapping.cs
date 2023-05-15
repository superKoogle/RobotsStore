using AutoMapper;
using Entities;
using DTO;

namespace LoginEx
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest=>dest.CategoryName, opt=>opt.MapFrom(src=>src.Category.CategoryName))
                .ReverseMap()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserLoginDTO, User>();
        }
    }
}
