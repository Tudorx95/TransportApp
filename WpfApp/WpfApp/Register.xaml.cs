using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using WpfApp.Components;

namespace WpfApp
{
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Add logic to save the user data here
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string username = UsernameBox.Text;
            string email = EmailTextBox.Text;
            string password = Password.Text;
            string confirmPassword = Password2.Text;
            
            if(password!=confirmPassword)
            {
                MessageBox.Show("Incorrect password!");
                return;
            }
            if (!IsUsernameUnique(username))
                return;
            // here add the user in Persoane and verify its integrity
            if (!Person.Add_Persoana(firstName, lastName, email))
                return;
            // here just add the user in User by the generated ID from Persoana
            int id_pers=Person.GetPersonID(firstName, lastName,email);
            if (id_pers != -1 && User.AddUser(username, password, id_pers))
            {
                MessageBox.Show("Registration successfully!");
                SwitchToLogin();
            }            
        }

        public bool IsUsernameUnique(string username)
        {
            if (!DB_Connect.IsDBConnected())
                return false;
            string query = "select count(*) from [User] where username=@username";
            try
            {
                var cmd = new SqlCommand(query, DB_Connect.connect);
                cmd.Parameters.AddWithValue("@username", username);
                int count = cmd.ExecuteNonQuery();
                if(count > 0) return false;
            }
            catch(Exception e) 
            { 
                MessageBox.Show(e.Message);
            }
            return true;
        }

        private void BackToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            SwitchToLogin();
        }

        private void SwitchToLogin()
        {
            NavigationBar.NavigateTo(typeof(Login));
        }
    }
}