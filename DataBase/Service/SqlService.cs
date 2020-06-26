using System;
using System.Data.SqlClient;

namespace DataBase.Service
{
    public class SqlService
    {
        private static string connectionString;
        public void CreateConnectionString(string nameServer, string nameDataBase, string nameUser, string passwordUser)
        {
            var sqlConnection = new SqlConnectionStringBuilder()
            {
                DataSource = nameServer,
                InitialCatalog = nameDataBase,
                UserID = nameUser,
                Password = passwordUser,
                ApplicationName = "EnityFramework",
                IntegratedSecurity = false
            };
            connectionString = sqlConnection.ConnectionString;
        }
        public string GetConnectionString()
        {
            return SqlService.connectionString;
        }
    }
}
