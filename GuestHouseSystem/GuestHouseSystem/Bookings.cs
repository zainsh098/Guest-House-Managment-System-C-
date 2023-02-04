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

namespace GuestHouseSystem
{
    public partial class Bookings : Form
    {
        private string Search_data_query = "select * from Booking where CusName=@search";
        public Bookings()
        {
            InitializeComponent();
            ShowBookings();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\source\repos\GuestHouseSystem\GuestHouseSystem\GuestHouseData.mdf;Integrated Security=True");



        public void SEARCH_DATA( )
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\source\repos\GuestHouseSystem\GuestHouseSystem\GuestHouseData.mdf;Integrated Security=True"))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(Search_data_query, con))
                    {
                        sqlCommand.Parameters.AddWithValue("@search",nameSearchTb.Text);
               
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        adapter.Fill(dt);
                        BookingDGVC.DataSource = dt;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }



        private void ShowBookings()
        {

            con.Open();
            string query = "Select *  From Booking";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookingDGVC.DataSource = ds.Tables[0];
            con.Close();




        }
        private void Filter()
        {

            con.Open(); 
            string query = "Select *  From Booking where  RType ='"+ RTypeCb.SelectedItem.ToString()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookingDGVC.DataSource = ds.Tables[0];
            con.Close();




        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ShowBookings(); 



        }

        private void RTypeCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Filter();   
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Dashboard = new Dashboard();
            Dashboard.Closed += (s, args) => this.Close();
            Dashboard.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Dashboard = new Customers();
            Dashboard.Closed += (s, args) => this.Close();
            Dashboard.Show();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Dashboard = new Bookings();
            Dashboard.Closed += (s, args) => this.Close();
            Dashboard.Show();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Dashboard = new Login();
            Dashboard.Closed += (s, args) => this.Close();
            Dashboard.Show();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SEARCH_DATA();

        }
    }
}
