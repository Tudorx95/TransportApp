using System.Data.SqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp.Components;

namespace WpfApp
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            DB_Connect.connection(".", "TransportDB");
            //MessageBox.Show(DB_Connect.connect.ServerVersion.ToString());
            InitializeComponent();

            this.WindowState = WindowState.Maximized; // Maximize the window
            MainContent.Content = new Home();
        }
        
        public void NavigateToPage(Type pageType)
        {
            
            NavigationBar.NavigateTo(pageType);
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState == WindowState.Normal)  // Restored down
            {
                // Adjust content here for a "floating" effect, if needed
                MainContent.Margin = new Thickness(20);  // Example adjustment
            }
            else if (WindowState == WindowState.Maximized)
            {
                MainContent.Margin = new Thickness(0);
            }
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            User.LoginDetails.Clear();
            // Close the database connection
            if (DB_Connect.connect!= null && DB_Connect.connect.State == System.Data.ConnectionState.Open)
            {
                DB_Connect.connect.Close();
                DB_Connect.connect.Dispose();
            }
            // Optional: Log or handle other cleanup tasks here
        }
    }
}