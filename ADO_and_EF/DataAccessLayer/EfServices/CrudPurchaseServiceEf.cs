using DataAccessLayer.Common;
using DataAccessLayer.EF;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EfServices
{
    public class CrudPurchaseServiceEf : ICrudDbService<Purchase>
    {
        private ApplicationContext _context;

        public CrudPurchaseServiceEf(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Purchase> GetAll()
        {
            return _context.Purchases
                .Include(p => p.Purchaser)
                .Include(p => p.Product)
                .Include(p => p.Seller)
                .AsNoTracking()
                .ToList();
        }

        public Purchase GetById(int id)
        {
            return _context.Purchases
                .Include(p => p.Purchaser)
                .Include(p => p.Product)
                .Include(p => p.Seller)
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public void Create(Purchase entity)
        {
            if (entity != null)
            {
                _context.Purchases.Add(entity);
                _context.SaveChanges();
                _context.Entry(entity).State = EntityState.Detached;
            }
            else
                throw new ArgumentNullException(nameof(entity));
        }

        public void Update(Purchase newEntity)
        {
            if (newEntity != null)
            {
                _context.Purchases.Update(newEntity);
                _context.SaveChanges();
                _context.Entry(newEntity).State = EntityState.Detached;
            }
            else
                throw new ArgumentNullException(nameof(newEntity));
        }

        public void Delete(Purchase entity)
        {
            if (entity != null)
            {
                _context.Purchases.Remove(entity);
                _context.SaveChanges();
                _context.Entry(entity).State = EntityState.Detached;
            }
            else
                throw new ArgumentNullException(nameof(entity));

        }
    }
}
