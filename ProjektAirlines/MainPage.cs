using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektAirlines
{
    //Glowne okno po logowaniu, sluzy do otwierania pozostalych okien
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void addCustomerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.MdiParent = this;
            customer.Show();
        }

        private void searchCustomerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SearchCustomer search = new SearchCustomer();
            search.MdiParent = this;
            search.Show();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlightDetails flight = new FlightDetails();
            flight.MdiParent = this;
            flight.Show();
        }

        private void searchCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchFlight search = new SearchFlight();
            search.MdiParent = this;
            search.Show();
        }

        private void flightDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
