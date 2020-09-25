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
            cmd.Parameters.AddWithValue("@FlightClass", txtFlightClass.Text);
            cmd.Parameters.AddWithValue("@FlightCharges", txtFlightCharges.Text);
            cmd.Parameters.AddWithValue("@Seats", nUDSeats.Value);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Data has been added");
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand("UPDATE FlightDetails SET FlightName=@a1, Source=@a2, Destination=@a3, ArrivalTime=@a4, " +
                "Departure=@a5, FlightClass=@a6, FlightCharges=@a7, Seats=@a8 WHERE Id=@a9", con);
            var generator = new RandomGenerator();
            var randomNumber = generator.RandomNumber(50, 1000);
            cmd.Parameters.AddWithValue("a1", txtFightName.Text);
            cmd.Parameters.AddWithValue("a2", txtSource.Text);
            cmd.Parameters.AddWithValue("a3", txtDestination.Text);
            cmd.Parameters.AddWithValue("a4", dTPArrival.Value);
            cmd.Parameters.AddWithValue("a5", dTPDeparture.Value);
            cmd.Parameters.AddWithValue("a6", txtFlightClass.Text);
            cmd.Parameters.AddWithValue("a7", randomNumber);
            cmd.Parameters.AddWithValue("a8", nUDSeats.Value);
            cmd.Parameters.AddWithValue("a9", Convert.ToInt32(txtId.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data has been updated");
        }

        
        

    }
    public class RandomGenerator
    {
        private readonly Random _random = new Random();
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }

   
}
