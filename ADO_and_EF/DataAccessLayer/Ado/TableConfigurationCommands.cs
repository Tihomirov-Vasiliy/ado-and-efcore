using System.Data.Common;

namespace DataAccessLayer.Ado
{
    /// <summary>
    /// Класс представляющий создание структуры бд средствами ADO.NET
    /// </summary>
    public class TableConfigurationCommands
    {
        private DbConnection _connection;

        public TableConfigurationCommands(DbConnection connection)
        {
            _connection = connection;
        }

        public void ConfigureDatabase()
        {
            //В разработке!
            string countryTableConfiguration = "CREATE TABLE countries()";
            string productTableConfiguration = "CREATE TABLE products()";
            string purchaseTableConfiguration = "CREATE TABLE purchases()";
            string purchaserTableConfiguration = "CREATE TABLE purchasers()";
            string sellerTableConfiguration = "CREATE TABLE sellers()";
        }
    }
}
