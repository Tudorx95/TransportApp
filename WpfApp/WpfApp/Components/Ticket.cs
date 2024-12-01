using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Components
{
    internal class Ticket
    {
        public int  ticket_count;
        public double ticket_price;
        public Ticket_Option ticket_opt;
        public DateTime ticket_date;
        public double total_Price;
        public Ticket()
        {

        }
        public Ticket(int count,double price, Ticket_Option option, DateTime date) 
        { 
            ticket_count = count;
            ticket_price = price;
            ticket_opt = option;
        }
        public void determine_Time()
        {
            if (ticket_opt == Ticket_Option.Year_Subscription)
            {
                ticket_date = DateTime.Now.AddYears(1);
            }
            if(ticket_opt==Ticket_Option.Half_Year_Subsc)
            {
                ticket_date = DateTime.Now.AddMonths(6);
            }
            // here the user must have an indicator of outstanding amounts
            // or treat as the user paid for the specific months (n months where n is the nb of months from now to specified date)_
            if (ticket_opt == Ticket_Option.Monthly_Subscription)
            {
                // round to the next mount;
                DateTime startDate = ticket_date;
                DateTime currentDate = DateTime.Now;
                int monthsDifference = ((currentDate.Year - startDate.Year) * 12) + currentDate.Month - startDate.Month;
                if (currentDate.Day < startDate.Day)
                {
                    monthsDifference--; // Subtract one month if the current day hasn't reached the start day yet
                }

                total_Price *=monthsDifference;
            }    
        }

        static int Determine_Ticket_ID(Ticket_Option ticket_name)
        {
            if (!DB_Connect.IsDBConnected())
                return -1;
            string query = "SELECT id_unic, nume FROM Tip_Bilet";
            using (SqlCommand cmd = new SqlCommand(query,DB_Connect.connect))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Retrieve the values of the columns
                        int idUnic = reader.GetInt32(0); // Get id_unic (first column)
                        string nume = reader.GetString(1); // Get nume (second column)

                        // Compare with your string
                        if (ticket_name.Equals(Ticket_Option.Single_Ticket) && 
                            nume.Equals("Bilet o calatorie", StringComparison.OrdinalIgnoreCase))
                        {
                            return idUnic;
                        }
                        if (ticket_name.Equals(Ticket_Option.Round_Trip_Ticket) &&
                           nume.Equals("Bilet dus-intors", StringComparison.OrdinalIgnoreCase))
                        {
                            return idUnic;
                        }
                        if (ticket_name.Equals(Ticket_Option.Monthly_Subscription) &&
                           nume.Equals("Abonament lunar", StringComparison.OrdinalIgnoreCase))
                        {
                            return idUnic;
                        }
                        if (ticket_name.Equals(Ticket_Option.Half_Year_Subsc) &&
                           nume.Equals("Abonament 6 luni", StringComparison.OrdinalIgnoreCase))
                        {
                            return idUnic;
                        }
                        if (ticket_name.Equals(Ticket_Option.Year_Subscription) &&
                           nume.Equals("Abonament 1 an", StringComparison.OrdinalIgnoreCase))
                        {
                            return idUnic;
                        }
                    }
                }
            }
            return -1;
        }
        public void AddTicket()
        {
            total_Price = ticket_price * ticket_count;
            determine_Time();
            int id_user = ServiceUser.getUserID();
            if(id_user==-1)
            {
                MessageBox.Show($"You are not logged in!");
                return;
            }
            int id_ticket = Determine_Ticket_ID(ticket_opt);
            if (id_ticket == -1)
            {
                MessageBox.Show("Cannot add the ticket. Ticket does not exists in the list");
                return;
            }

            string query = "INSERT INTO Bilet (tip_bilet, valabilitate, id_calator, nr_bilete) " +
                     "VALUES (@tip_bilet, @valabilitate, @id_calator, @nr_bilete)";
            if (!DB_Connect.IsDBConnected())
                return;
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DB_Connect.connect))
                {
                    // Set parameters to avoid SQL injection
                    cmd.Parameters.AddWithValue("@tip_bilet", id_ticket);
                    string formattedDate = ticket_date.ToString("yyyy-MM-dd");
                    cmd.Parameters.AddWithValue("@valabilitate", formattedDate);
                    cmd.Parameters.AddWithValue("@id_calator", id_user);
                    cmd.Parameters.AddWithValue("@nr_bilete", ticket_count); // Assuming ticket_count is the number of tickets to insert

                    // Execute the command
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Ticket successfully added.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while adding the ticket: {ex.Message}");
            }
        }
    }
}
