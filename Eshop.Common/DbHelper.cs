using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Common
{
    public static class DbHelper
    {
        public static SqlConnection GetSqlConnection()
        {
            SqlConnection sqlConnection = null;

            string connectionString = "Data Source=DESKTOP-IFRSV3F;Initial Catalog=BE_22042024;User ID=sa;Password=123456;";
           
            sqlConnection = new SqlConnection(connectionString);
            
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            return sqlConnection;
        }
    }
}
