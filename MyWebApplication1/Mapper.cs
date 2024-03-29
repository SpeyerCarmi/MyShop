﻿using AutoMapper;
using DTO;
using Entities;

namespace MyWebApplication1
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<UserWithPasswordDTO, User>().ReverseMap();

            CreateMap<User, UserWithoutPasswordDTO>();

            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.CategoryName, 
                opt => opt.MapFrom(src => src.Category.Name))
                .ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();

            CreateMap<Order, OrderDTO>().ReverseMap();

            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();

        }

    }
}
