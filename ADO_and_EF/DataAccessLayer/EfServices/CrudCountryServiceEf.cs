using DataAccessLayer.Common;
using DataAccessLayer.EF;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EfServices
{
    public class CrudCountryServiceEf : ICrudDbService<Country>
    {
        private ApplicationContext _context;
        public CrudCountryServiceEf(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Country> GetAll()
        {
            //As no tracking - используем т.к. нам не нужно отслеживать состояние данных стран, нам нужно только их получить
            return _context.Countries
                .AsNoTracking()
                .ToList();
        }

        public Country GetById(int id)
        {
            return _context.Countries
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public void Create(Country entity)
        {
            if (entity != null)
            {
                _context.Countries.Add(entity);
                _context.SaveChanges();
                _context.Entry(entity).State = EntityState.Detached;
            }
            else
                throw new ArgumentNullException(nameof(entity));
        }

        public void Update(Country newEntity)
        {
            if (newEntity != null)
            {
                _context.Countries.Update(newEntity);
                _context.SaveChanges();
                _context.Entry(newEntity).State = EntityState.Detached;
            }
            else
                throw new ArgumentNullException(nameof(newEntity));
        }

        public void Delete(Country entity)
        {
            if (entity != null)
            {
                _context.Countries.Remove(entity);
                _context.SaveChanges();
                _context.Entry(entity).State = EntityState.Detached;
            }
            else
                throw new ArgumentNullException(nameof(entity));
        }
    }
}
