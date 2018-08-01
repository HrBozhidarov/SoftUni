using AutoMapper;
using ShopProduct.Dtos;
using ShopProduct.Dtos.Export;
using ShopProduct.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopProduct
{
    public class ShopPorductProfile : Profile
    {
        public ShopPorductProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<ProductDto, Product>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
