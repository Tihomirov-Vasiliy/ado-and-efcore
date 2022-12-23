using DataAccessLayer.AdoServices;
using DataAccessLayer.Common;
using DataAccessLayer.EF;
using DataAccessLayer.EfServices;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //UsingAdo();
                UsingEf();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }
        }

        /// <summary>
        /// Пример работы с базой данных средствами ADO.NET
        /// </summary>
        static void UsingAdo()
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                //Создаём необходимый сервис, например сервис для стран
                ICrudDbService<Country> countryService = new CrudCountryServiceAdo(connection);

                //Создаём страны
                Country newCountry = new Country("Australia", 3);
                Country newCountry1 = new Country("Zimbabve", 200);
                countryService.Create(newCountry);
                countryService.Create(newCountry1);

                //Получаем все страны
                IEnumerable<Country> countries = countryService.GetAll();

                //Выводим данные в консоли
                foreach (var country in countries)
                {
                    Console.WriteLine($"Country {country.Name} has code {country.Code}");
                }

                //Получаем страну по её Id, например под Id = 2 и выводим данные в консоль
                int id = 2;
                Country countryById = countryService.GetById(id);
                Console.WriteLine($"Country (by id={id}) {countryById.Name} has code {countryById.Code}");

                //Обновляем страну с Id = 1, задавая ей новые значения имени и кода
                Country updatedCountry = new Country(1, "NewCountryName", 1);
                countryService.Update(updatedCountry);

                //Теперь удалим данную страну
                countryService.Delete(updatedCountry);
            }

        }

        /// <summary>
        /// Пример работы с базой данных средствами EF core
        /// </summary>
        static void UsingEf()
        {
            using (var context = new ApplicationContext())
            {
                //Применяем миграции
                context.Database.Migrate();
            }

            using (var context = new ApplicationContext())
            {
                //Создаём необходимый сервис, например сервис для покупателей
                ICrudDbService<Purchaser> purchaserService = new CrudPurchaserServiceEf(context);

                //Создаём покупателей
                Purchaser newPurchaser = new Purchaser()
                {
                    FirstName = "Test",
                    LastName = "Test",
                    CardNumber = "123",
                    Country = new Country("New Purchaser Country", 3),
                    Email = "testEmail@email.com"
                };
                Purchaser newPurchaser1 = new Purchaser()
                {
                    FirstName = "Test1",
                    LastName = "Test1",
                    CardNumber = "1231",
                    Country = new Country("New Purchaser Country1", 4),
                    Email = "testEmail@email.com1"
                };
                purchaserService.Create(newPurchaser);
                purchaserService.Create(newPurchaser1);

                //Получаем всех покупателей
                IEnumerable<Purchaser> purchasers = purchaserService.GetAll();

                //Выводим данные в консоли
                foreach (var purchaser in purchasers)
                {
                    Console.WriteLine($"Purchaser");
                    Console.WriteLine($"Id:{purchaser.Id}");
                    Console.WriteLine($"Name: {purchaser.LastName} {purchaser.FirstName}");
                    Console.WriteLine($"Card number:{purchaser.CardNumber}");
                    Console.WriteLine($"Country name:{purchaser.Country.Name}");
                }

                //Получаем покупателя по его Id, например под Id = 2 и выводим данные в консоль
                int id = 2;
                Purchaser purchaserById = purchaserService.GetById(id);
                Console.WriteLine($"Purchaser({purchaserById.Id}) name: {purchaserById.LastName} {purchaserById.FirstName}");

                //Обновляем покупателя с Id = 1, задавая ему новые значения
                Purchaser updatedPurchaser = new Purchaser() { Id = 1, FirstName = "newFirstName", LastName = "newLastName" };
                purchaserService.Update(updatedPurchaser);

                //Теперь удалим данного пользователя
                purchaserService.Delete(updatedPurchaser);
            }
        }
    }
}