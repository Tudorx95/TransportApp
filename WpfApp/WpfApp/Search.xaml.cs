using System;
using System.Collections.Generic;
using System.Globalization;
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
        private Dictionary<string, (string LeftImage, List<StationArrival> Arrivals)> routeData = new Dictionary<string, (string, List<StationArrival>)>
        {
            { "Tramvai nr. 10", ("Images/default_map_new.png", new List<StationArrival> { new StationArrival("Station A", new List<string> { "10:00", "10:15", "10:30" }),
                                                                          new StationArrival("Station B", new List<string> { "10:05", "10:20", "10:35" }),
                                                                          new StationArrival("Station C", new List<string> { "10:10", "10:25", "10:40" }) }) },
            { "Tramvai nr. 11", ("Images/Route11_Left.jpg", new List<StationArrival> { new StationArrival("Station D", new List<string> { "11:00", "11:15", "11:30" }),
                                                                          new StationArrival("Station E", new List<string> { "11:05", "11:20", "11:35" }),
                                                                          new StationArrival("Station F", new List<string> { "11:10", "11:25", "11:40" }) }) },
            { "Autobuz nr. 100", ("Images/autobuz_100.png", new List<StationArrival> { new StationArrival("Station G", new List<string> { "12:00", "12:15", "12:30" }),
                                                                          new StationArrival("Station H", new List<string> { "12:05", "12:20", "12:35" }),
                                                                          new StationArrival("Station I", new List<string> { "12:10", "12:25", "12:40" }) }) }
            // Add more routes here as needed
        };

        public Search()
        {
            InitializeComponent();
            LeftImage.MouseLeftButtonUp += LeftImage_MouseLeftButtonUp;
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
                string selectedSuggestion = SuggestionsListBox.SelectedItem.ToString();
                SearchTextBox.Text = selectedSuggestion;
                SuggestionsListBox.Visibility = Visibility.Collapsed;
                FloatingLabel.Visibility = Visibility.Collapsed;

                if (routeData.ContainsKey(selectedSuggestion))
                {
                    var routeInfo = routeData[selectedSuggestion];

                    // Set the images and station list based on the selected option
                    LeftImage.Source = new BitmapImage(new Uri(routeInfo.LeftImage, UriKind.Relative));
                    LeftImage.Visibility = Visibility.Visible;

                    // Set data for the DataGrid
                    StationsDataGrid.ItemsSource = routeInfo.Arrivals;

                    // Set visibility for RouteDisplay
                    RouteDisplay.Visibility = Visibility.Visible; // Show the RouteDisplay

                    // Optionally set the content of the RouteDisplay, like station names
                    StationsList.Text = string.Join(", ", routeInfo.Arrivals.Select(a => a.StationName));
                }
                else
                {
                    // Clear data if no route found
                    LeftImage.Source = null;
                    LeftImage.Visibility = Visibility.Collapsed;
                    StationsDataGrid.Visibility = Visibility.Collapsed;
                    RouteDisplay.Visibility = Visibility.Collapsed; // Hide the RouteDisplay
                }
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Searching for: {SearchTextBox.Text}");
        }

        private void LeftImage_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Open the popup when LeftImage is clicked
            ImagePopup.IsOpen = true;
        }

        private void ImagePopup_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Close the popup when it's clicked
            ImagePopup.IsOpen = false;
        }


        // Class to represent station arrival times
        public class StationArrival
        {
            public string StationName { get; set; }
            public List<string> ArrivalTimes { get; set; }

            // New property to display arrival times as a string
            public string ArrivalTimesDisplay => string.Join(", ", ArrivalTimes);

            public StationArrival(string stationName, List<string> arrivalTimes)
            {
                StationName = stationName;
                ArrivalTimes = arrivalTimes;
            }
        }
    }
}
