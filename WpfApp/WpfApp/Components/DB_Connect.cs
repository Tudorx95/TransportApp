using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace WpfApp.Components
{
    internal class DB_Connect
    {
        static public SqlConnection connect { get; private set; }
        public DB_Connect(string ip,string db_name)
        {
            connect = connect_to_DB(ip, db_name);
        }

        static public void connection(string ip,string db_name)
        {
            connect = connect_to_DB(ip, db_name);
        }   
        static private SqlConnection connect_to_DB(string ip, string db_name)
        {
            var connection = new SqlConnection();
            connection.ConnectionString =
            $"Server=LAPTOP-6U3DKNPP\\SQLEXPRESS;Database=TransportDB;Trusted_Connection=true";
            connection.Open();
            return connection;
        }
        static public DataTable GetTableByName(string tableName)
        {
            if (connect == null)
                throw new InvalidOperationException("Database connection is not initialized.");

         
            // Create a new SqlCommand and SqlDataAdapter to retrieve the table data
            var query = $"SELECT * FROM [{tableName}]";
            var cmd = new SqlCommand(query, connect);
            var adapter = new SqlDataAdapter(cmd);
            var dataTable = new DataTable(tableName);

            // Fill the DataTable with the result
            adapter.Fill(dataTable);

         
            return dataTable;
        }

        static public bool IsDBConnected()
        {
            if(connect == null) return false;
            return true;
        }


        static public void DB_Deconnect()
        {
            connect.Close();
        }
    }
}
