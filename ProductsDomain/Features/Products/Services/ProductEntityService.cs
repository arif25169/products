using ProductsDomain.Features.Products.Interfaces;
using ProductsDomain.Features.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsDomain.Features.Products.Entities;
using ProductsDomain.Features.Shared.Services;
using ProductsDomain.Features.Shared;
using ProductsDomain.Orm;
using System.Data.Entity.Infrastructure;

namespace ProductsDomain.Features.Products.Services
{
    public class ProductEntityService : EntityService<Product>, IProductEntityService
    {
        public ProductEntityService(AdventureWorksContext context) : base(context)
        {
        }
    }
}