using AppViralityTest.DAL.Core.Models;
using AppViralityTest.DataModels;
using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViralityTest.BLL.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<UserDTO, User>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName)); ;
                cfg.CreateMap<User, UserDTO>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name)); ;
            });
        }
    }
}
