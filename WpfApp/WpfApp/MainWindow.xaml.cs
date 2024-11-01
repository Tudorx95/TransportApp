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
        public void UpdateNavBar()
        {
            NavBar.UpdateLoginButton();
        }
        public void NavigateToPage(Type pageType)
        {
            NavBar.UpdateLoginButton();
            NavigationBar.NavigateTo(pageType);
        }
    }
}