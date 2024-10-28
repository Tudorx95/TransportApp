using System.Windows;
using System.Windows.Controls;
using WpfApp.Components;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MainWindow();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new LoginView();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new SearchTransportView();
        }
    }
}