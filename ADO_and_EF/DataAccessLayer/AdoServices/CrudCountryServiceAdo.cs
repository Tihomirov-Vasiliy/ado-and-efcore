using DataAccessLayer.Common;
using DomainLayer.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.AdoServices
{
    /// <summary>
    /// Сервис который работает с CRUD оператором для сущности Country
    /// </summary>
    public class CrudCountryServiceAdo : ICrudDbService<Country>
    {
        private NpgsqlConnection _connection;

        /// <param name="connection">
        /// NpgsqlConnection - класс наследуемый от DbConnection, который предоставляет соединение с PostgreSQL.
        /// Подробнее <see href="https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/dbconnection-dbcommand-and-dbexception"/>
        /// </param>
        public CrudCountryServiceAdo(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Country> GetAll()
        {
            Country country = new Country();
            List<Country> countries = new List<Country>();

            //Переменная содержащая SQL код
            string queryStr = "SELECT * FROM countries";

            //Класс представляющий команду для выполнения 
            NpgsqlCommand command = new NpgsqlCommand(queryStr, _connection);

            //Создаём DataAdapter с помощью которого заполним DataSet
            NpgsqlDataAdapter dtAdapter = new NpgsqlDataAdapter(command);
            DataSet dtSet = new DataSet();

            //Заполняем DataSet результатом выполнения запроса
            dtAdapter.Fill(dtSet, "country");

            //Преобразуем данные из запроса в класс Country и заполняем список
            if (dtSet.Tables.Count != 0)
            {
                foreach (DataRow item in dtSet.Tables["country"].Rows)
                {
                    country = new Country(
                        (int)item["id"],
                        item["name"].ToString(),
                        (int)item["code"]);
                    countries.Add(country);
                }
                return countries;
            }
            return null;
        }

        public Country GetById(int id)
        {
            Country country = null;

            //Переменная содержащая SQL код, с параметром
            string queryStr = "SELECT * FROM countries WHERE id = @id";

            NpgsqlCommand command = new NpgsqlCommand(queryStr, _connection);

            //Создаём параметры с именем @id и значением из аргумента: id
            NpgsqlParameter idParameter = new NpgsqlParameter("@id", id);

            //Добавляем значение аргумента в запрос, через параметр (из соображений безопасности)
            command.Parameters.Add(idParameter);

            //Открываем соединение 
            _connection.Open();

            //Вызываем ExecuteReader и считываем данные построчно из DataReader
            NpgsqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                country = new Country(
                    (int)dataReader["id"],
                    dataReader["name"].ToString(),
                    (int)dataReader["code"]);
            }

            //Закрываем соединение
            _connection.Close();

            return country;
        }

        public void Create(Country entity)
        {
            //Переменная содержащая SQL код, с параметрами
            string queryStr = "INSERT INTO countries (name, code) VALUES (@name,@code)";

            NpgsqlCommand command = new NpgsqlCommand(queryStr, _connection);

            //Создаём параметры для имени и кода
            NpgsqlParameter nameParameter = new NpgsqlParameter("@name", entity.Name);
            NpgsqlParameter codeParameter = new NpgsqlParameter("@code", entity.Code);

            //Добавляем значения для имени и кода в запрос через параметры
            command.Parameters.Add(nameParameter);
            command.Parameters.Add(codeParameter);

            //Открываем соединение 
            _connection.Open();

            //Вызываем ExecuteNonQuery - выполняет SQL код, и если возвращает -1 то ошибка произошла
            if (command.ExecuteNonQuery() == -1)
                throw new ArgumentException("Something went wrong during creating Country entity");

            //Закрываем соединение
            _connection.Close();
        }

        public void Update(Country newEntity)
        {
            //Переменная содержащая SQL код, с параметрами
            string queryStr = "UPDATE countries SET name=@name, code=@code WHERE id = @id";

            NpgsqlCommand command = new NpgsqlCommand(queryStr, _connection);

            //Создаём параметры для id, имени и кода
            NpgsqlParameter idParameter = new NpgsqlParameter("@id", newEntity.Id);
            NpgsqlParameter nameParameter = new NpgsqlParameter("@name", newEntity.Name);
            NpgsqlParameter codeParameter = new NpgsqlParameter("@code", newEntity.Code);

            //Добавляем значения для id, имени и кода через параметры
            command.Parameters.Add(idParameter);
            command.Parameters.Add(nameParameter);
            command.Parameters.Add(codeParameter);

            //Открываем соединение 
            _connection.Open();

            //Вызываем ExecuteNonQuery
            if (command.ExecuteNonQuery() == -1)
                throw new ArgumentException($"Something went wrong during updating Country entity with id {newEntity.Id}");

            //Закрываем соединение
            _connection.Close();
        }

        public void Delete(Country entity)
        {
            //Переменная содержащая SQL код, с параметром
            string queryStr = "DELETE FROM countries WHERE id = @id";

            NpgsqlCommand command = new NpgsqlCommand(queryStr, _connection);

            //Создаём параметр для id
            NpgsqlParameter idParameter = new NpgsqlParameter("@id", entity.Id);

            //Добавляем значениe для id через параметры
            command.Parameters.Add(idParameter);

            //Открываем соединение 
            _connection.Open();

            //Вызываем ExecuteNonQuery
            if (command.ExecuteNonQuery() == -1)
                throw new ArgumentException($"Something went wrong during deleting Country entity with id {entity.Id}");

            //Закрываем соединение
            _connection.Close();
        }
    }
}
