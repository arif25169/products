using ProductsDomain.Features.Products.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductsDomain.Orm
{
    public class AdventureWorksContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}