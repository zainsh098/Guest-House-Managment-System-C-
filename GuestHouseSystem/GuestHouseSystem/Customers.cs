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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\source\repos\GuestHouseSystem\GuestHouseSystem\GuestHouseData.mdf;Integrated Security=True");

        private void Reset()
        {

            CName.Text = "";
            CPhone.Text = "";
            CComobo.Text = "";
            CDateTimePicker.Text = "";



        }




        private void ShowCustomers()
        {

            sqlConnection.Open();
            string query = "Select *  From Customers";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookingDGVC.DataSource = ds.Tables[0];
            sqlConnection.Close();




        }

        private void SaveCBtn_Click(object sender, EventArgs e)
        {
            if (CName.Text == "" || CPhone.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {

                sqlConnection.Open();
              SqlCommand cmd = new SqlCommand("insert into Customers   (CusName,CusPhone,CusGen,CusDob)  values (@CN,@CP,@CGN,@CDob)", sqlConnection);
                cmd.Parameters.AddWithValue("@CN", CName.Text);
                cmd.Parameters.AddWithValue("@CP", CPhone.Text);
                cmd.Parameters.AddWithValue("@CGN", CComobo.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@CDob", CDateTimePicker.Value.Date);

            //    cmd.Parameters.AddWithValue("@UKey", Key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Data Saved ");
                sqlConnection.Close();
                ShowCustomers();
                Reset();
            }
            sqlConnection.Close();









        }
        int Key = 0;
        private void UDVC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
         
                CName.Text = BookingDGVC.SelectedRows[0].Cells[1].Value.ToString();
                CPhone.Text = BookingDGVC.SelectedRows[0].Cells[2].Value.ToString();
                CComobo.Text = BookingDGVC.SelectedRows[0].Cells[3].Value.ToString();
            CDateTimePicker.Text = BookingDGVC.SelectedRows[0].Cells[4].Value.ToString();
           

                    Key = Convert.ToInt32(BookingDGVC.SelectedRows[0].Cells[0].Value.ToString());

                



            }

        private void DeleteCBtn_Click(object sender, EventArgs e)
        {
            if (deleteID.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {

                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("Delete from Customers  where CusId=" + deleteID.Text, sqlConnection);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer  Deleted");
                sqlConnection.Close();


                ShowCustomers();
                Reset();

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EditCbtn_Click(object sender, EventArgs e)
        {

            sqlConnection.Open();
            if (CName.Text == "" || CPhone.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {

              
                SqlCommand cmd = new SqlCommand("Update Customers Set CusName=@UN,CusPhone=@UP,CusGen=@UPA,CusDob=@UDOB  where CusID=@Ukey ", sqlConnection);
                cmd.Parameters.AddWithValue("@UN", CName.Text);
                cmd.Parameters.AddWithValue("@UP", CPhone.Text);
                cmd.Parameters.AddWithValue("@UPA", CComobo.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@UDOB", CDateTimePicker.Value.ToString());

                cmd.Parameters.AddWithValue("@UKey", Key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Edited");
                sqlConnection.Close();


                ShowCustomers();

            }
            sqlConnection.Close();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Dashboard = new Dashboard();
            Dashboard.Closed += (s, args) => this.Close();
            Dashboard.Show();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Dashboard = new Customers();
            Dashboard.Closed += (s, args) => this.Close();
            Dashboard.Show();
            ;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ShowCustomers();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            this.Size = new Size(900, 550);

        }
    }
}
