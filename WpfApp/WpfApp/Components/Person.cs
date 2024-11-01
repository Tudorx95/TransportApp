using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Components
{
    internal class Person
    {
        static public bool ExistPerson(string firstName, string lastName, string email)
        {
            if (!DB_Connect.IsDBConnected())
                return false;
            string query = "select count(*) from Persoana where nume=@firstName and prenume=@lastName and email=@email";
            try
            {
                SqlCommand command = new SqlCommand(query, DB_Connect.connect);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastname", lastName);
                command.Parameters.AddWithValue("@email", email);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        static public bool Add_Persoana(string firstName, string lastName, string email, int tip_pers = 1)
        {
            if (!DB_Connect.IsDBConnected())
                return false;

            if(ExistPerson(firstName,lastName,email))
            {
                MessageBox.Show("Persoana exista deja!");
                return false;
            }

            string query = "INSERT INTO Persoana (tip_persoana,nume,prenume,email) VALUES (@tip_pers,@firstname,@lastname,@email)";
            try
            {
                SqlCommand command = new SqlCommand(query, DB_Connect.connect);
                command.Parameters.AddWithValue("@tip_pers", tip_pers);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastname", lastName);
                command.Parameters.AddWithValue("@email", email);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Registration completed successfully!\nNow back to Login");
                    // After registering, show the Login component again
                    return true;
                }
                else MessageBox.Show("Data not inserted or user exists");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        static public int GetPersonID(string firstName,string lastName,string email)
        {
            if (!DB_Connect.IsDBConnected())
                return -1;
            string query = "select id_unic from Persoana where nume=@firstName and prenume=@lastName and email=@email";
            try
            {
                SqlCommand command = new SqlCommand(query, DB_Connect.connect);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@email", email);
                int rowsAffected = (int)command.ExecuteScalar();
                if (rowsAffected > 0)
                {
                    return Convert.ToInt32(rowsAffected);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1;
        }
    }


}
