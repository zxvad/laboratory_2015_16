using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace FoodDeliveryManagementClient
{
    class DBOutput
    {
        public static DataTable GetTable(string sql)
        {
            IDBConnection conn = (IDBConnection) new DBConnection();
            using (var connection = new NpgsqlConnection(conn.GetDBConnectionParameters()))
            {
                connection.Open();
                DataSet dataSet = new DataSet();
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, connection);
                dataSet.Reset();
                dataAdapter.Fill(dataSet);
                return dataSet.Tables[0];
            }
        }


        public static DataTable GetTableByTableName(string tableName)
        {
            string sql = String.Format("SELECT * FROM {0}", tableName);
            return GetTable(sql);
        }

    }
}
