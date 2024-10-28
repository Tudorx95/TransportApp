using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class Search : UserControl
    {
        public Search()
        {
            InitializeComponent();
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Hide the placeholder text when the textbox is focused
            PlaceholderTextBlock.Visibility = Visibility.Collapsed;
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Show the placeholder text again if the textbox is empty
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                PlaceholderTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement your search logic here
            MessageBox.Show($"Searching for: {SearchTextBox.Text}");
        }
    }
}
