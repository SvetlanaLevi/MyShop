using AutoMapper;
using MyShop.API.ModelsInput;
using MyShop.API.ModelsOutput;
using MyShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryWithCount, CategoryWithCountOutputModel>();
            CreateMap<OrdersInfo, OrdersInfoOutputModel>();
            CreateMap<Product, ProductOutputModel>();

            CreateMap<OrdersInfoInputModel, OrdersInfo>()
               .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate == null ? null : (DateTime?)Convert.ToDateTime(src.StartDate)))
               .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate == null ? null : (DateTime?)Convert.ToDateTime(src.EndDate)));
        }

    }
}
