using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class NavigationBar : UserControl
    {
        public NavigationBar()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic to navigate to Home Window
            //MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            //mainWindow.MainContent.Content = new MainWindow(); 
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic to navigate to Login Window
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainContent.Content = new Login(); 
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic to navigate to Search Window
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainContent.Content = new Search(); 
        }
    }
}
