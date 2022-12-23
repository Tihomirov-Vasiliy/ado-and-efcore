using DataAccessLayer.Common;
using DataAccessLayer.EF;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EfServices
{
    public class CrudPurchaserServiceEf : ICrudDbService<Purchaser>
    {
        private ApplicationContext _context;

        public CrudPurchaserServiceEf(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Purchaser> GetAll()
        {
            return _context.Purchasers
                .Include(p => p.Country)
                .AsNoTracking()
                .ToList();
        }

        public Purchaser GetById(int id)
        {
            return _context.Purchasers
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public void Create(Purchaser entity)
        {
            if (entity != null)
            {
                _context.Purchasers.Add(entity);
                _context.SaveChanges();
                _context.Entry(entity).State = EntityState.Detached;
            }
            else
                throw new ArgumentNullException(nameof(entity));
        }

        public void Update(Purchaser newEntity)
        {
            if (newEntity != null)
            {
                _context.Purchasers.Update(newEntity);
                _context.SaveChanges();
                _context.Entry(newEntity).State = EntityState.Detached;
            }
            else
                throw new ArgumentNullException(nameof(newEntity));
        }

        public void Delete(Purchaser entity)
        {
            if (entity != null)
            {
                _context.Purchasers.Remove(entity);
                _context.SaveChanges();
                _context.Entry(entity).State = EntityState.Detached;
            }
            else
                throw new ArgumentNullException(nameof(entity));
        }
    }
}
