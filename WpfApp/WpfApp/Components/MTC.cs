using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Components
{
    internal class MTC
    {
        public MTC() { }
        static public int Get_MTC_Type(string type)
        {
            if (!DB_Connect.IsDBConnected())
                return -1;
            string query = "SELECT id_unic, nume FROM TipMT";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DB_Connect.connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Iterate through the results
                        while (reader.Read())
                        {
                            // Compare the 'nume' column with the parameter 'type'
                            string dbType = reader["nume"].ToString();

                            // If the names match, return the id_unic
                            if (type.Contains("Bus") && dbType.Equals("Autobuz"))
                            {
                                return Convert.ToInt32(reader["id_unic"]);
                            }
                            if (type.Contains("Tram") && dbType.Equals("Tramvai"))
                            {
                                return Convert.ToInt32(reader["id_unic"]);
                            }
                            if (type.Contains("Trolleybus") && dbType.Equals("Troleibuz"))
                            {
                                return Convert.ToInt32(reader["id_unic"]);
                            }
                            if (type.Contains("Subway") && dbType.Equals("Metrou"))
                            {
                                return Convert.ToInt32(reader["id_unic"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} in Get_MTC_Type");
            }
            return -1;
        }
    }
}
