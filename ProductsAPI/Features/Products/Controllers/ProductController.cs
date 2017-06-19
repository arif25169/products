using ProductsDomain.Features.Products.Entities;
using ProductsAPI.Features.Products.Models;
using ProductsAPI.Features.Shared.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper;
using ProductsDomain.Features.Products.Services;
using ProductsDomain.Features.Products.Interfaces;

namespace ProductsAPI.Features.Products.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : CrudController<ProductModel, Product, CreateProductModel>
    {
        public ProductController(IProductEntityService productEntityService, IMapper mapper) : base(productEntityService, mapper) { }
    }
}