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
        private List<string> sampleSuggestions = new List<string>();
        private Dictionary<string, string> videoMappings = new Dictionary<string, string>();
        private Dictionary<string, (string LeftImage, List<StationArrival> Arrivals)> routeData = new Dictionary<string, (string, List<StationArrival>)>();
        private void LoadVideoMappings()
        {
            using (var context = new DataClasses1DataContext())
            {
                // Load transport types from the TipMT table
                // Obține combinația "Tip Transport" și "Număr MT"
                var transportTypes = from tip in context.TipMTs
                                     join mt in context.MTs on tip.id_unic equals mt.id_tip
                                     select new
                                     {
                                         nume = tip.nume + " nr. " + mt.numar_mt
                                     };

                foreach (var transportType in transportTypes)
                {
                    // Define video paths based on transport type names
                    string videoPath = transportType.nume.Contains("Tramvai")
                        ? $"C:\\Users\\razva\\Desktop\\ABDApp\\TransportApp\\WpfApp\\WpfApp\\Images\\tram_video.mp4"
                        : transportType.nume.Contains("Autobuz")
                        ? $"C:\\Users\\razva\\Desktop\\ABDApp\\TransportApp\\WpfApp\\WpfApp\\Images\\bus_video.mp4"
                        : transportType.nume.Contains("Metro")
                        ? $"C:\\Users\\razva\\Desktop\\ABDApp\\TransportApp\\WpfApp\\WpfApp\\Images\\metro_video.mp4"
                        : null; // Fallback for undefined transport types

                    if (videoPath != null)
                    {
                        // Add mapping to dictionary
                        videoMappings.Add(transportType.nume, videoPath);
                    }
                }
            }
        }

        public void LoadSuggestionsFromDatabase()
        {
            var context = new DataClasses1DataContext();
            var suggestions = from tip in context.TipMTs
                              join mt in context.MTs on tip.id_unic equals mt.id_tip
                              select tip.nume + " nr. " + mt.numar_mt;  // Combina transportul cu numărul MT

            sampleSuggestions.Clear();
            sampleSuggestions.AddRange(suggestions);
        }

        private void LoadRouteDataFromDatabase()
        {
            using (var context = new DataClasses1DataContext())
            {
                // Dicționar cu imagini pentru fiecare număr MT
                var imageMappings = new Dictionary<int, string>
                {
                    { 101, "Images/autobuz_101.png" },
                    { 102, "Images/autobuz_102.png" },
                    { 103, "Images/autobuz_103.png" },
                    { 10, "Images/tramvai_10.png" },
                    { 11, "Images/tramvai_11.png" },
                    { 12, "Images/tramvai_12.png" },
                    { 1, "Images/metrou.png" }
                };  

                // Obține combinația "Tip Transport" și "Număr MT"
                var transportTypes = from tip in context.TipMTs
                                     join mt in context.MTs on tip.id_unic equals mt.id_tip
                                     select new
                                     {
                                         TransportName = tip.nume + " nr. " + mt.numar_mt, // Exemplu: "Autobuz nr. 101"
                                         TransportType = tip.nume,
                                         NumarMT = mt.numar_mt,
                                         IdTraseu = mt.nr_traseu // Folosit pentru sosiri
                                     };

                // Curăță datele anterioare
                routeData.Clear();

                foreach (var transportType in transportTypes)
                {
                    // Extrage datele despre sosiri pentru fiecare traseu
                    var arrivals = (from statie in context.Staties
                                    join tipStatie in context.Tip_Staties on statie.id_tip_statie equals tipStatie.id_unic
                                    where statie.id_traseu == transportType.IdTraseu
                                    select new StationArrival(
                                        tipStatie.nume,           // Numele stației
                                        statie.ore.Split(' ').ToList() // Orele sosirilor ca listă
                                    )).ToList();

                    // Construiește calea pentru imagine
                    string imagePath;
                    if (imageMappings.ContainsKey(transportType.NumarMT))
                    {
                        imagePath = imageMappings[transportType.NumarMT];
                    }
                    else
                    {
                        // Dacă nu există o imagine specifică pentru numărul MT, folosește o imagine implicită
                        imagePath = "Images/default_transport.png";
                    }

                    // Adaugă la datele rutei
                    routeData.Add(transportType.TransportName, (imagePath, arrivals));
                }
            }
        }

        public Search()
        {
            LoadSuggestionsFromDatabase();
            LoadRouteDataFromDatabase(); // Load route data from the database
            InitializeComponent();
            LoadVideoMappings();
            Media.Play();
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

            // Filtrăm sugestiile pentru a include doar acelea care încep cu input-ul utilizatorului
            var filteredSuggestions = sampleSuggestions
                .Where(suggestion => suggestion.StartsWith(input, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

            // Actualizăm ListBox-ul cu sugestiile filtrate
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

                    // Dynamically set the video source
                    SetVideoSource(selectedSuggestion);
                }
                else
                {
                    // Clear data if no route found
                    LeftImage.Source = null;
                    LeftImage.Visibility = Visibility.Collapsed;
                    StationsDataGrid.Visibility = Visibility.Collapsed;
                    RouteDisplay.Visibility = Visibility.Collapsed; // Hide the RouteDisplay

                    Media.Source = null; // Stop video if no transport type is selected
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

        private void SetVideoSource(string transportType)
        {
            // Check if the transportType exists in the videoMappings dictionary
            if (videoMappings.TryGetValue(transportType, out string videoPath))
            {
                Media.Source = new Uri(videoPath); // Set the MediaElement source to the video
                Media.Play(); // Automatically start playing the video
            }
            else
            {
                // Handle case where no video is found for the transport type
                Media.Source = null;
                MessageBox.Show($"No video available for transport type: {transportType}");
            }
        }

        private void Media_MediaEnded(object sender, RoutedEventArgs e)
        {
            // Optionally handle media ended event
            Media.Position = TimeSpan.Zero; // Reset to the beginning if needed
            Media.Play(); // Restart playback if desired
        }
        private void FindPathButton_Click(object sender, RoutedEventArgs e)
        {
            SearchRoute newWindow = new SearchRoute();
            newWindow.Show();
            //MessageBox.Show("Finding path to destination...");
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
