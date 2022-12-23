using DataAccessLayer.Common;
using DataAccessLayer.EF;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EfServices
{
    public class CrudSellerServiceEf : ICrudDbService<Seller>
    {
        private ApplicationContext _context;

        public CrudSellerServiceEf(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Seller> GetAll()
        {
            return _context.Sellers
                .Include(s => s.Country)
                .AsNoTracking()
                .ToList();
        }

        public Seller GetById(int id)
        {
            return _context.Sellers
                .Include(s => s.Country)
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public void Create(Seller entity)
        {
            if (entity != null)
            {
                _context.Sellers.Add(entity);
                _context.SaveChanges();
                _context.Entry(entity).State = EntityState.Detached;
            }
            else
                throw new ArgumentNullException(nameof(entity));
        }

        public void Update(Seller newEntity)
        {
            if (newEntity != null)
            {
                _context.Sellers.Update(newEntity);
                _context.SaveChanges();
                _context.Entry(newEntity).State = EntityState.Detached;
            }
            else
                throw new ArgumentNullException(nameof(newEntity));
        }

        public void Delete(Seller entity)
        {
            if (entity != null)
            {
                _context.Sellers.Remove(entity);
                _context.SaveChanges();
                _context.Entry(entity).State = EntityState.Detached;
            }
            else
                throw new ArgumentNullException(nameof(entity));
        }
    }
}
