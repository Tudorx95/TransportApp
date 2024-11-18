using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Components
{
    class User
    {
        static protected Dictionary<string, string> login_details = new Dictionary<string, string>{ {"", ""} };

        static public Dictionary<string, string> LoginDetails
        {
            get { return login_details; }
            set { login_details = value; }
        }
        static public int getUserID()
        {
            if (!DB_Connect.IsDBConnected())
                return -1;
            string username = login_details.Keys.FirstOrDefault();
            string password = login_details.Values.FirstOrDefault();
            //MessageBox.Show($"{username} {password}");
            string query = "select top 1 id_unic from [User] where username=@username and password=@password";
            using (SqlCommand cmd = new SqlCommand(query, DB_Connect.connect))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                try
                {
                    // ExecuteScalar to retrieve the single result
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return -1;
        }
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
                Console.WriteLine($"{ex.Message} in AddUser");
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
                { 
                    // here store the user credentials 
                    User.LoginDetails.Add(username, password);
                    return true;
                }
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
