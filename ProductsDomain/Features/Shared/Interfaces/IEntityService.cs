using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsDomain.Features.Shared.Interfaces
{
    public interface IEntityService<E> : IService
    {
        IQueryable<E> List();
        E GetById(int id);
        E Create(E entity);
        int Delete(int id);
        E Update(E entity);
    }
}
