using System.Windows;
using System.Windows.Controls;

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

            // After registering, show the Login component again
            MessageBox.Show("Registration completed successfully!\nNow back to Login");
        }

        private void BackToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            SwitchToLogin();
        }

        private void SwitchToLogin()
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainContent.Content = new Login(); // Switch back to Login component
        }
    }
}