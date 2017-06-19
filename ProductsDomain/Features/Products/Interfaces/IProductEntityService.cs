using ProductsDomain.Features.Products.Entities;
using ProductsDomain.Features.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsDomain.Features.Products.Interfaces
{
    public interface IProductEntityService : IEntityService<Product>
    {
    }
}
