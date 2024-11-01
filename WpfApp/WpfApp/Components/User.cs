using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Components
{
    class User
    {
        static public bool AddUser(string username, string password, int id_pers)
        {
            if (!DB_Connect.IsDBConnected())
                return false;

             string query = "INSERT INTO Users (username, password, id_persoana) VALUES (@username, @password, @id_pers)";

            SqlCommand command = new SqlCommand(query, DB_Connect.connect);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@id", id_pers);

            try
            {
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Handle exception (logging, rethrowing, etc.)
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        static public bool Exist_User(string username,string password)
        {
            if (!DB_Connect.IsDBConnected())
                return false;

            string query = "select username,password from [User] where username=@username";
            try
            {
                SqlCommand command = new SqlCommand(query, DB_Connect.connect);
                command.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = command.ExecuteReader();
                bool[] res = {false, false};

                while (reader.Read())
                {
                    string user = reader["username"].ToString();                    
                    string pass = reader["password"].ToString();

                    if(user==username)
                        res[0]=true;
                    if(pass==password)
                        res[1]=true;
                }
                reader.Close(); // Ensure the reader is closed

                if (res[0] && res[1])
                    return true;
                else if (res[0])
                    MessageBox.Show("Incorrect Password!");
                else
                    MessageBox.Show("Incorrect Username!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }
    }
}
