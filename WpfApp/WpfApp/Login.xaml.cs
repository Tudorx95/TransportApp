using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using WpfApp.Components;

namespace WpfApp
{
    public partial class Login : UserControl
    {
        static public bool connected { get; set; } = false;
        public Login()
        {
            InitializeComponent();
            // Initialize placeholders visibility
            UsernamePlaceholder.Visibility = string.IsNullOrWhiteSpace(UsernameTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
            PasswordPlaceholder.Visibility = string.IsNullOrWhiteSpace(PasswordBox.Password) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void UsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UsernamePlaceholder.Visibility = Visibility.Collapsed;
        }

        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            UsernamePlaceholder.Visibility = string.IsNullOrWhiteSpace(UsernameTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordPlaceholder.Visibility = string.IsNullOrWhiteSpace(PasswordBox.Password) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            //string encryptedPassword = Crypt.Encrypt(password);
            // verify the integrity of the password

            if (ServiceUser.Exist_User(username,password))
            {
                // set connected state to true
                Login.connected = true;
                // navigate to search window
                MainWindow mainWindow = new MainWindow();
                Dictionary<string, string> newLoginDetails = new Dictionary<string, string> { { username, password } };
                ServiceUser.LoginDetails = newLoginDetails;
                NavigationBar.NavigateTo(typeof(Search));
            }
            NavigationBar.NavigateTo(typeof(Search)); //added by me 
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic to open the registration form or UserControl
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainContent.Content = new Register();
        }
    }
}
