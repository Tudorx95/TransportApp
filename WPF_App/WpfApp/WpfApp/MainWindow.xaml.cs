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
            this.WindowState = WindowState.Maximized; // Maximize the window
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            //mainWindow.MainContent.Content = new MainWindow();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainContent.Content = new LoginView();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainContent.Content = new SearchTransportView();
        }
    }
}