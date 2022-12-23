using DataAccessLayer.Common;
using DomainLayer.Entities;
using Npgsql;
using System.Collections.Generic;

namespace DataAccessLayer.AdoServices
{
    //Класс находится в разработке!
    public class CrudSellerServiceAdo : ICrudDbService<Seller>
    {
        private NpgsqlConnection _connection;

        public CrudSellerServiceAdo(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Seller> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Seller GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Seller entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Seller newEntity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Seller entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
