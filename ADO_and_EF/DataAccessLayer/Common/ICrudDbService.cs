using System.Collections.Generic;

namespace DataAccessLayer.Common
{
    /// <summary>
    /// Данный интерфейс представляет CRUD методы определенной сущности для баз данных
    /// </summary>
    /// <typeparam name="T">
    /// T - класс, для которого будет реализованы CRUD операторы
    /// </typeparam>
    public interface ICrudDbService<T> where T : class, new()
    {
        //Read (чтение) - получение всех сущностей (GetAll) или по id (GetById) из базы данных
        IEnumerable<T> GetAll();
        T GetById(int id);

        //Create (создание) - создание сущности в базе данных
        void Create(T entity);

        //Update (обновление) - обновление сущности в базе данных
        void Update(T newEntity);

        //Delete (удаление) - удаление сущности в базе данных
        void Delete(T entity);
    }


}
