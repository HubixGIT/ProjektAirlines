using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektAirlines
{
    //W tym okienie dodajemy informacje o lotach i automatycznie wylicza nam cene biletow
    public partial class FlightDetails : Form
    {
        SqlCommand cmd;
        SqlConnection con;

        string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;
                    AttachDbFilename=C:\Users\hubert\source\repos\ProjektAirlines\ProjektAirlines\AirlineDB.mdf;
                    Integrated Security=True";
        public FlightDetails()
        {
            InitializeComponent();
        }

        //Przycisk "Add", pozwala na dodaniu nowych lotow do bazydanych dajac im kolejny nr ID
        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand("INSERT INTO FlightDetails (FlightName, Source, Destination, ArrivalTime, Departure, FlightClass, FlightCharges, Seats) VALUES " +
                                 "(@FlightName, @Source, @Destination, @ArrivalTime, @Departure, @FlightClass, @FlightCharges, @Seats)", con);
            
            cmd.Parameters.AddWithValue("@FlightName", txtFightName.Text);
            cmd.Parameters.AddWithValue("@Source", txtSource.Text);
            cmd.Parameters.AddWithValue("@Destination", txtDestination.Text);
            cmd.Parameters.AddWithValue("@ArrivalTime", dTPArrival.Value);
            cmd.Parameters.AddWithValue("@Departure", dTPDeparture.Value);
            cmd.Parameters.AddWithValue("@FlightClass", dUDClass.SelectedItem);
            cmd.Parameters.AddWithValue("@Seats", nUDSeats.Value);

            var functions = new Functions();
            var flightDistance = functions.Distance(txtSource.Text, txtDestination.Text);

            var fullPrice = functions.FlightPrice(flightDistance, nUDSeats.Value, dUDClass.SelectedIndex);

            cmd.Parameters.AddWithValue("@FlightCharges",fullPrice);

            MessageBox.Show("The flight costs: " + fullPrice + "$");


            cmd.ExecuteNonQuery();
            MessageBox.Show("Data has been added");
            con.Close();

        }
            //Przycisk "Update", po wpisaniu nr ID lotu mozemy dokonac zmian w tabeli bazydanych
        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand("UPDATE FlightDetails SET FlightName=@a1, Source=@a2, Destination=@a3, ArrivalTime=@a4, " +
                "Departure=@a5, FlightClass=@a6, FlightCharges=@a7, Seats=@a8 WHERE Id=@a9", con);
            
            if(txtFightName != null)
                cmd.Parameters.AddWithValue("a1", txtFightName.Text);
            if (txtSource != null)
                cmd.Parameters.AddWithValue("a2", txtSource.Text);
            if (txtDestination != null)
                cmd.Parameters.AddWithValue("a3", txtDestination.Text);

            cmd.Parameters.AddWithValue("a4", dTPArrival.Value);
            cmd.Parameters.AddWithValue("a5", dTPDeparture.Value);
            if (dUDClass != null)
                cmd.Parameters.AddWithValue("a6", dUDClass.SelectedItem);
            if (nUDSeats != null)
                cmd.Parameters.AddWithValue("a8", nUDSeats.Value);

            var functions = new Functions();
            var flightDistance = functions.Distance(txtSource.Text, txtDestination.Text);

            var fullPrice = functions.FlightPrice(flightDistance, nUDSeats.Value, dUDClass.SelectedIndex);

            
            cmd.Parameters.AddWithValue("a7", fullPrice);
            cmd.Parameters.AddWithValue("a9", Convert.ToInt32(txtId.Text));

            cmd.ExecuteNonQuery();
            MessageBox.Show("Data has been updated");
        }

        private void txtFightName_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
   

   
}
