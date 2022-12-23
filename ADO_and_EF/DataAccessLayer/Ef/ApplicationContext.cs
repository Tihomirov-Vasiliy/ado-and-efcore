using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Configuration;

namespace DataAccessLayer.EF
{
    /// <summary>
    /// Класс представляющий сессию с бд. Подробнее о DbContext можно увидеть здесь: 
    /// <see href="https://learn.microsoft.com/en-us/dotnet/api/system.data.entity.dbcontext"/>
    /// </summary>
    public class ApplicationContext : DbContext
    {
        //Свойства, которые могут использоваться для запросов или сохранения сущностей
        //LINQ запросы для данных свойств преобразуются в запросы базы данных
        //Подробнее: https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1
        public DbSet<Country> Countries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Purchaser> Purchasers { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        public ApplicationContext()
        {

        }

        /// <summary>
        /// Метод используемый для конфигурации базы данных.
        /// Подробнее: <see href="https://learn.microsoft.com/ru-ru/dotnet/api/microsoft.entityframeworkcore.dbcontext.onconfiguring"/>
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(ConfigurationManager.ConnectionStrings["Db"].ConnectionString)
                //Логирование в консоль, чтобы видеть код, генерируемый EF
                .LogTo(Console.WriteLine, LogLevel.Information);
            //Для настройки и создания миграций необходимо указать подключение сразу здесь
            //.UseNpgsql("Server=localhost;Database=TestDb;Port=5432;User Id=postgres;Password=postgres");
        }

        /// <summary>
        /// В данном методе описываются дополнительные конфигурации для моделей.
        /// Такие как ограничения, названия столбцов или таблиц и многое другое.
        /// Подробнее: <see href="https://learn.microsoft.com/en-us/ef/core/modeling/"/>
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Названия таблицы указываем в нижнем регистре для каждой сущности
            //Для того чтобы не указывать схему при запросах в PostgreSQL
            modelBuilder.Entity<Country>()
                .ToTable("countries");
            modelBuilder.Entity<Product>()
                 .ToTable("products");
            modelBuilder.Entity<Purchase>()
                .ToTable("purchases");
            modelBuilder.Entity<Purchaser>()
                .ToTable("purchasers");
            modelBuilder.Entity<Seller>()
                .ToTable("sellers");

            //Проходим по всем существующим сущностям
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                //У каждой сущности проходимся по её свойствам
                foreach (var property in entityType.GetProperties())
                {
                    //Все названия для столбцов делаем в нижнем регистре
                    //Для того чтобы не указывать схему при запросах в PostgreSQL
                    modelBuilder
                        .Entity(entityType.Name)
                        .Property(property.Name)
                        .HasColumnName(property.Name.ToLower());

                    //Для каждого Id создаём правило, которое позволяет не вписывать определенный Id при создании, а бд само даст ему значение
                    if (property.Name == "Id")
                        modelBuilder
                            .Entity(entityType.Name)
                            .Property(property.Name)
                            .UseIdentityAlwaysColumn();
                }
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
