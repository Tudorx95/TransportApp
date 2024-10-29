using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApp
{
    public partial class Search : UserControl
    {
        // Sample data for suggestions
        private List<string> sampleSuggestions = new List<string>
        {
            "Autobuz nr. 100", "Autobuzul nr. 101", "Autobuzul nr. 102",
            "Tramvai nr. 10", "Tramvai nr. 11", "Tramvai nr. 12",
            "Metrou"
        };

        // Route images and stations for each transport type
        private Dictionary<string, (string LeftImage, string RightImage, List<string> Stations)> routeData = new Dictionary<string, (string, string, List<string>)>
        {
            { "Tramvai nr. 10", ("Images/Route10_Left.jpg", "Images/Route10_Right.jpg", new List<string> { "Station A", "Station B", "Station C" }) },
            { "Tramvai nr. 11", ("Images/Route11_Left.jpg", "Images/Route11_Right.jpg", new List<string> { "Station D", "Station E", "Station F" }) },
            { "Autobuz nr. 100", ("Images/Route100_Left.jpg", "Images/Route100_Right.jpg", new List<string> { "Station G", "Station H", "Station I" }) }
            // Add more routes here as needed
        };

        public Search()
        {
            InitializeComponent();
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            FloatingLabel.Visibility = Visibility.Collapsed;
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                FloatingLabel.Visibility = Visibility.Visible;
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = SearchTextBox.Text;

            // Filter suggestions to only include those that start with the user's input
            var filteredSuggestions = sampleSuggestions
                .Where(suggestion => suggestion.StartsWith(input, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

            // Update the ListBox with filtered suggestions
            SuggestionsListBox.ItemsSource = filteredSuggestions;
            SuggestionsListBox.Visibility = filteredSuggestions.Any() ? Visibility.Visible : Visibility.Collapsed;
        }

        private void SuggestionsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SuggestionsListBox.SelectedItem != null)
            {
                SearchTextBox.Text = SuggestionsListBox.SelectedItem.ToString();
                SuggestionsListBox.Visibility = Visibility.Collapsed;
                FloatingLabel.Visibility = Visibility.Collapsed;

                // Update images and station list based on selection
                string selectedSuggestion = SuggestionsListBox.SelectedItem.ToString();

                // Example logic for setting images and stations based on selection
                if (routeData.ContainsKey(selectedSuggestion))
                {
                    var routeInfo = routeData[selectedSuggestion];

                    LeftImage.Source = new BitmapImage(new Uri(routeInfo.LeftImage, UriKind.Relative));
                    RightImage.Source = new BitmapImage(new Uri(routeInfo.RightImage, UriKind.Relative));
                    StationsList.Text = string.Join(", ", routeInfo.Stations); // Join station names with a comma

                    // Make the route display visible
                    RouteDisplay.Visibility = Visibility.Visible;
                }
                else
                {
                    // Handle other suggestions
                    LeftImage.Source = null; // Or set default images
                    RightImage.Source = null;
                    StationsList.Text = string.Empty; // Or default text
                    RouteDisplay.Visibility = Visibility.Collapsed; // Hide if no valid selection
                }
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Searching for: {SearchTextBox.Text}");
        }
    }
}
