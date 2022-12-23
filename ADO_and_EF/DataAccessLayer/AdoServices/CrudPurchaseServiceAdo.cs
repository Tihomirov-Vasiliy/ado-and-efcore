using DataAccessLayer.Common;
using DomainLayer.Entities;
using Npgsql;
using System.Collections.Generic;

namespace DataAccessLayer.AdoServices
{
    //Класс находится в разработке!
    public class CrudPurchaseServiceAdo : ICrudDbService<Purchase>
    {
        private NpgsqlConnection _connection;

        public CrudPurchaseServiceAdo(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Purchase> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Purchase GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Purchase entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Purchase newEntity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Purchase entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
