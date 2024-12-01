using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.Components;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Complains_Request.xaml
    /// </summary>
    public partial class Complains_Request : Window
    {
        public Complains_Request()
        {
            InitializeComponent();
        }
        private void SendComplaintButton_Click(object sender, RoutedEventArgs e)
        {
            string username = ServiceUser.LoginDetails.FirstOrDefault().ToString();
            string password = ServiceUser.LoginDetails.FirstOrDefault().ToString();
            if(username=="" || password=="")
            {
                MessageBox.Show("Please log in before you submit any complain!");
                return;
            }
            // Get selected service from ComboBox
            var selectedService = (ServiceComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();


            // Get the text entered in the TextBox
            var complainMessage = ComplainTextBox.Text;

            if (string.IsNullOrEmpty(selectedService) || string.IsNullOrEmpty(complainMessage))
            {
                MessageBox.Show("Please select a service and enter your complaint before submitting.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            int id_user = ServiceUser.getUserID();
            int id_mtc = MTC.Get_MTC_Type(selectedService);
            if(id_user == -1)
            { 
                MessageBox.Show($"You must log in to send a complaint!"); 
                return;
            }
            Insert_Complain(id_user,complainMessage,id_mtc,selectedService);

            // Optionally clear the fields after submission
            ServiceComboBox.SelectedIndex = -1;
            ComplainTextBox.Clear();
        }
        public void Insert_Complain(int id_user,string text,int id_MTC_type,string selectedService)
        {
            if (!DB_Connect.IsDBConnected())
                return;
            string query = "INSERT INTO Complaint (id_user, text_plangere, id_tip_MTC) " +
                  "VALUES (@id_user, @text, @id_MTC_type)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DB_Connect.connect))
                {
                    // Add parameters to the command
                    cmd.Parameters.AddWithValue("@id_user", id_user);
                    cmd.Parameters.AddWithValue("@text", text);
                    cmd.Parameters.AddWithValue("@id_MTC_type", id_MTC_type);

                    // Execute the query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Your complaint about {selectedService} has been sent!", "Complaint Submitted", MessageBoxButton.OK);
                    }
                    else
                    {
                        MessageBox.Show("Failed to submit the complaint.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the database operation
                MessageBox.Show($"{ex.Message} in Insert_Complain");
            }
        }
    }
}
