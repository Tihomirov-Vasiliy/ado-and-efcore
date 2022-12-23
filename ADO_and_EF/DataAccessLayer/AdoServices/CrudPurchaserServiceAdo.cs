using DataAccessLayer.Common;
using DomainLayer.Entities;
using Npgsql;
using System.Collections.Generic;

namespace DataAccessLayer.AdoServices
{
    //Класс находится в разработке!
    public class CrudPurchaserServiceAdo : ICrudDbService<Purchaser>
    {
        private NpgsqlConnection _connection;

        public CrudPurchaserServiceAdo(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Purchaser> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Purchaser GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Purchaser entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Purchaser newEntity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Purchaser entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
