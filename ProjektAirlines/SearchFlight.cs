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
    /// <summary>
    /// Sluzy do przegladania zapisanych danych w baziedanych Lotow i mozliwosci zapisu lotow do klientow "Bookowanie"
    /// </summary>
    public partial class SearchFlight : Form
    {
        
        SqlConnection con;
        SqlDataAdapter da;
        DataTable ds;
        string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;
                    AttachDbFilename=C:\Users\hubert\source\repos\ProjektAirlines\ProjektAirlines\AirlineDB.mdf;
                    Integrated Security=True";
        public SearchFlight()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from FlightDetails", con);

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
                da.Fill(ds);
                BindingSource bs = new BindingSource();

                bs.DataSource = ds;
                dGVFlight.DataSource = bs;
                da.Update(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchFlight_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(ds);
            DV.RowFilter = string.Format("flightname LIKE '%{0}%' ", txtSearchFlight.Text);
            dGVFlight.DataSource = DV;
        }

        

        

        private void customerIDtxt_TextChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select Name, FatherName, Birthdate, Email, Address  from CustomerDetails", con);
            con.Open();
            if (customerIDtxt.Text != "")
            {


                cmd.Parameters.AddWithValue("@Id", int.Parse(customerIDtxt.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    textBox2.Text = da.GetValue(0).ToString();
                    textBox3.Text = da.GetValue(1).ToString();
                    this.dateTimePicker1.Text = da.GetValue(2).ToString();
                    textBox5.Text = da.GetValue(3).ToString();
                    textBox7.Text = da.GetValue(4).ToString();
                }
                con.Close();
            }
            
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Booking (CustomerId, Departure, FlightId, Seatno) VALUES " +
                                 "(@CustomerId, @Departure, @FlightId, @Seatno)", con);

            cmd.Parameters.AddWithValue("@CustomerId", customerIDtxt.Text);
            cmd.Parameters.AddWithValue("@Departure", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@FlightId", textBox9.Text);
            cmd.Parameters.AddWithValue("@Seatno", textBox10.Text);
            
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data has been added");
            con.Close();
        }
    }
}
