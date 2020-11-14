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
    //Sluzy do przegladania zapisanych danych w baziedanych Klientow
    public partial class SearchCustomer : Form
    {
        //SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        DataTable ds;
        string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;
                    AttachDbFilename=C:\Users\hubert\source\repos\ProjektAirlines\ProjektAirlines\AirlineDB.mdf;
                    Integrated Security=True";
        public SearchCustomer()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select * from CustomerDetails", con);

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
                da.Fill(ds);
                BindingSource bs = new BindingSource();

                bs.DataSource = ds;
                dGVCustomer.DataSource = bs;
                da.Update(ds);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(ds);
            DV.RowFilter = string.Format("name LIKE '%{0}%' ", textBox1.Text);
            dGVCustomer.DataSource = DV;
        }
    }
}
