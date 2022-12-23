using DataAccessLayer.Common;
using DataAccessLayer.EF;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EfServices
{
    public class CrudProductServiceEf : ICrudDbService<Product>
    {
        private ApplicationContext _context;

        public CrudProductServiceEf(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products
                .AsNoTracking()
                .ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public void Create(Product entity)
        {
            if (entity != null)
            {
                _context.Products.Add(entity);
                _context.SaveChanges();
                _context.Entry(entity).State = EntityState.Detached;
            }
            else
                throw new ArgumentNullException(nameof(entity));
        }

        public void Update(Product newEntity)
        {
            if (newEntity != null)
            {
                _context.Products.Update(newEntity);
                _context.SaveChanges();
                _context.Entry(newEntity).State = EntityState.Detached;
            }
            else
                throw new ArgumentNullException(nameof(newEntity));
        }

        public void Delete(Product entity)
        {
            if (entity != null)
            {
                _context.Products.Remove(entity);
                _context.SaveChanges();
                _context.Entry(entity).State = EntityState.Detached;
            }
            else
                throw new ArgumentNullException(nameof(entity));

        }
    }
}
