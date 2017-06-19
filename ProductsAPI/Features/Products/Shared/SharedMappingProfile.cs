using AutoMapper;
using ProductsAPI.Features.Products.Models;
using ProductsDomain.Features.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsAPI.Features.Products.Shared
{
    public class SharedMappingProfile : Profile
    {
        public SharedMappingProfile()
        {
            CreateMap<Product, ProductModel>();
            CreateMap<CreateProductModel, Product>();
        }
    }
}