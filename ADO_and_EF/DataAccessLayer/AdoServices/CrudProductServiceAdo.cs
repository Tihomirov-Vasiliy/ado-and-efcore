using DataAccessLayer.Common;
using DomainLayer.Entities;
using Npgsql;
using System.Collections.Generic;

namespace DataAccessLayer.AdoServices
{
    //Класс находится в разработке!
    public class CrudProductServiceAdo : ICrudDbService<Product>
    {
        private NpgsqlConnection _connection;

        public CrudProductServiceAdo(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Product entity)
        {
            throw new System.NotImplementedException();
        }
        public void Update(Product newEntity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
