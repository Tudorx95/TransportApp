﻿using System;
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
            var context = new DataClasses1DataContext();  // Replace with your actual DataContext name

            try
            {
                // Use LINQ to get the ticket matching the criteria
                var ticket = context.Tip_Bilets
                                    .Where(t =>
                                           (ticket_name.Equals(Ticket_Option.Single_Ticket) && t.nume.ToLower() == "bilet o calatorie".ToLower()) ||
                                           (ticket_name.Equals(Ticket_Option.Round_Trip_Ticket) && t.nume.ToLower() == "bilet dus-intors".ToLower()) ||
                                           (ticket_name.Equals(Ticket_Option.Monthly_Subscription) && t.nume.ToLower() == "abonament lunar".ToLower()) ||
                                           (ticket_name.Equals(Ticket_Option.Half_Year_Subsc) && t.nume.ToLower() == "abonament 6 luni".ToLower()) ||
                                           (ticket_name.Equals(Ticket_Option.Year_Subscription) && t.nume.ToLower() == "abonament 1 an".ToLower())
                                    )
                                    .FirstOrDefault();  // Get the first matching ticket or null if no match found

                if (ticket != null)
                {
                    return ticket.id_unic;  // Return the id_unic if a matching ticket is found
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
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


            var context = new DataClasses1DataContext();  // Replace with your actual DataContext name
    
         
            try
            {
                // Create a new Bilet entity
                var newTicket = new Bilet
                {
                    tip_bilet = id_ticket,  // Use the determined ticket ID
                    valabilitate = ticket_date.Date,  // Format the date as needed
                    id_calator = id_user,  // User ID
                    nr_bilete = ticket_count  // Number of tickets
                };

                // Add the new ticket to the context
                context.Bilets.InsertOnSubmit(newTicket);

                // Submit changes to the database
                context.SubmitChanges();

                // Show success message
                MessageBox.Show("Ticket successfully added.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during insertion
                MessageBox.Show($"Error while adding the ticket: {ex.Message}");
            }
        }
    }
}
