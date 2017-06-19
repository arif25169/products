using ProductsDomain.Features.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ProductsDomain.Orm;
using System.Data.Entity.Infrastructure;
using ProductsDomain.Exceptions;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsDomain.Features.Shared.Services
{
    public abstract class EntityService<E> : IEntityService<E> where E : class
    {
        private readonly AdventureWorksContext _context;
        
        public EntityService(AdventureWorksContext context)
        {
            _context = context;
        }

        public E Create(E entity)
        {
            try
            {
                E output = _context.Set<E>().Add(entity);
                _context.SaveChanges();

                return output;
            } catch(DbUpdateException e)
            {
                CheckDbConstraintValidations(e, entity);

                throw e;
            } catch(Exception e)
            {
                throw e;
            }
        }

        private void CheckDbConstraintValidations(DbUpdateException e, E entity)
        {
            entity.GetType().GetProperties().ToList().ForEach(entry =>
            {
                IndexAttribute indexAttribute = (IndexAttribute) IndexAttribute.GetCustomAttribute(entry, typeof(IndexAttribute));

                if (indexAttribute != null && indexAttribute.IsUnique && e.InnerException.InnerException.Message.Contains(indexAttribute.Name))
                {
                    throw new DuplicateEntryException(entry.Name);
                }
            });
        }

        public int Delete(int id)
        {
            _context.Set<E>().Remove(this.GetById(id));
            return _context.SaveChanges();
        }

        public E GetById(int id)
        {
            return _context.Set<E>().Find(id);
        }

        public IQueryable<E> List()
        {
            return _context.Set<E>().AsQueryable<E>();
        }

        public E Update(E entity)
        {
            _context.SaveChanges();
            return entity;
        }
    }
}