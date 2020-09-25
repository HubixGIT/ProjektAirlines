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
    public partial class Customer : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        
        string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;
                    AttachDbFilename=C:\Users\hubert\source\repos\ProjektAirlines\ProjektAirlines\AirlineDB.mdf;
                    Integrated Security=True";

        public Customer()
        {
            InitializeComponent();
        }
        
        private void btnAddDetails_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand("INSERT INTO CustomerDetails (Name, FatherName, BirthDate, Email, Address) VALUES " +
                                 "(@Name, @FatherName, @BirthDate, @Email, @Address)", con);

            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@FatherName", txtFather.Text);
            cmd.Parameters.AddWithValue("@BirthDate", dateTimePickerBirth.Value);
            cmd.Parameters.AddWithValue("@Email", txtName.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data has been added");
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand("UPDATE CustomerDetails SET Name=@a1,FatherName=@a2,BirthDate=@a3,Email=@a4,Address=@a5 WHERE Id=@a6", con);

            cmd.Parameters.AddWithValue("a1", txtName.Text);
            cmd.Parameters.AddWithValue("a2", txtFather.Text);
            cmd.Parameters.AddWithValue("a3", dateTimePickerBirth.Value);
            cmd.Parameters.AddWithValue("a4", txtEmail.Text);
            cmd.Parameters.AddWithValue("a5", txtAddress.Text);
            cmd.Parameters.AddWithValue("a6", Convert.ToInt32(txtId.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data has been updated");
        }
    }
}
