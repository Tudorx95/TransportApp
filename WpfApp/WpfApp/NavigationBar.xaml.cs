using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp.Components;

namespace WpfApp
{
    public partial class NavigationBar : UserControl
    {
        public NavigationBar()
        {
            InitializeComponent();
        }

        // Helper method to navigate to a specific UserControl
        static public void NavigateTo(Type pageType)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            
            // Dynamically create an instance of the specified UserControl type
            if (Activator.CreateInstance(pageType) is UserControl pageInstance)
            {
                mainWindow.MainContent.Content = pageInstance;
            }
            else
            {
                throw new InvalidOperationException("Navigation target must be a UserControl.");
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(typeof(Home));
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if(Login.connected)
            {
                Login.connected=false;
                MessageBox.Show("Log out successfully!");
                UpdateLoginButton();
            }
            NavigateTo(typeof(Login));          
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

            if (Login.connected)
                NavigateTo(typeof(Search));
            else NavigateTo(typeof(Login));
            
        }
        public void UpdateLoginButton()
        {
            if (Login.connected)
            {
                // Change button text to "Log Out"
                LoginButton.Content = "Log Out";
            }
            else
            {
                // Change button text back to "Login"
                LoginButton.Content = "Log in";
            }
        }
    }
}
