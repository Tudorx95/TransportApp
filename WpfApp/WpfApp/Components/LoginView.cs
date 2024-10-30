using System.Windows;

namespace WpfApp.Components
{
    internal class LoginView : Window
    {
        public LoginView()
        {
            //InitializeComponent();
        }

        // Event handler for the Home button
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic to navigate to the home page
            MessageBox.Show("Navigating to Home Page...");

            // Example: You could create a new instance of your MainWindow here
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close(); // Close the login window
        }

        // Event handler for the Login button
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic to handle login
            MessageBox.Show("Login button clicked!");
            // You can add your login logic here
        }
    }
}