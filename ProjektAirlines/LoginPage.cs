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
    public partial class LoginPage : Form
    {
        public LoginPage()
        {

            InitializeComponent();
        }
        //Connection String
        string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;
                    AttachDbFilename=C:\Users\hubert\source\repos\ProjektAirlines\ProjektAirlines\AirlineDB.mdf;
                    Integrated Security=True";
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == " " || txtPassword.Text == " ")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            
                try
                {
                    //sql connection
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand("Select * from Login where UserName=@username and Password=@password", con);
                    cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    con.Open();
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    con.Close();
                    int count = ds.Tables[0].Rows.Count;
                    //If count is equal to 1, than show Main form
                    if (count == 1)
                    {
                        MessageBox.Show("Login Successful!");
                        this.Hide();
                        MainPage mainPage = new MainPage();
                        mainPage.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login Failed!");
                    }
                }
                
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
