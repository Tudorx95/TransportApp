using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.Components;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var cmd = (SqlCommand)DB_Connect.connect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT nume,prenume FROM Persoana";
            var adapter=new SqlDataAdapter(cmd);
            var dataset = new DataSet("set");
            adapter.Fill(dataset, "Persoana");
            var personsTable = dataset.Tables["Persoana"];
            PersonsDataGrid.ItemsSource = personsTable.DefaultView;
        }
    }
}
