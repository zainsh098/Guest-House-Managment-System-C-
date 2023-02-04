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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GuestHouseSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            CountBook();
            CountCustomers();
            CountBookings();
            GetCustomer();
           
        }


        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\source\repos\GuestHouseSystem\GuestHouseSystem\GuestHouseData.mdf;Integrated Security=True");
        int free, Booked;
        int  Bper, FreePer;
        private void CountBook()
        {
            string Status = "Booked";
       
            con.Open();
            SqlDataAdapter sda=new SqlDataAdapter("Select  Count(*) from Room where RStatus='"+Status+"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            free = 20 - int.Parse(dt.Rows[0][0].ToString());
            Booked= int.Parse(dt.Rows[0][0].ToString());
            Bper = (Booked / 20 )*100 ;
            FreePer = (free / 20 ) *100 ;
            BookingLBl.Text = dt.Rows[0][0].ToString()+ " Booked Rooms";
            AvblLB.Text = free + " Free Rooms";
            Avalab1.Text = free+"";
           
            BvpProgress.Value = Booked;
            AVPProgress.Value=free;
            FreeRoomProgressBar.Value =free;




            con.Close();
        
        
        
        }


        private void CountCustomers()
        {
         

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Customers ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
           
            CustNumber.Text = dt.Rows[0][0].ToString() + " Customers ";
           




            con.Close();



        }


        private void CountBookings()
        {


            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Booking ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

           BookingNumber.Text = dt.Rows[0][0].ToString() + " Booking ";





            con.Close();



        }


        private void GetCustomer()

        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select CusId From Customers ",con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CusId", typeof(int));
            dt.Load(rdr);
            CCombo.ValueMember = "CusId";
            CCombo.DataSource = dt;
            con.Close();

        }


        int RoomNumber = 0;


        private void GetCustName()
        {

            con.Open();
            string query = "Select * from Customers  where CusId =" + CCombo.SelectedValue.ToString();
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                CNametb.Text = dr["CusName"].ToString();
            }
            con.Close();

        }
        string Rtype;
        int RC;
        private void GetRoomType()
        {

            con.Open();
            string query = "Select * from Room  where RId =" + RoomNumber + " ";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                Rtype = dr["Rtype"].ToString();
                RC = int.Parse(dr["RCost"].ToString());
               

            }
            con.Close();

        }

        private void UpdateRoom()
        {

            string status = "Booked";
           

                con.Open();
                SqlCommand cmd = new SqlCommand("Update Room Set RStatus=@RS  where RId=@RKey", con);
                cmd.Parameters.AddWithValue("@RS", status);
              
                cmd.Parameters.AddWithValue("@RKey", RoomNumber);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Room Updated ");
                con.Close();


              
              //  Reset();

            


        }



        private void BookCBtn_Click(object sender, EventArgs e)
        {
         
            if (CNametb.Text == "" || RoomNumber==0)
            {
                MessageBox.Show("Select A Room Number and a Customer ");
            }
            else
            {
                GetRoomType();
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Booking(CusId,CusName,RId,RNum,RType,RCost) values(@cid,@cName,@rID,@rtype,@rcost,@Rkey )", con);
                cmd.Parameters.AddWithValue("cid", CCombo.SelectedValue);

                cmd.Parameters.AddWithValue("@cNAME", CNametb.Text);
                cmd.Parameters.AddWithValue("@rID", RoomNumber);

                cmd.Parameters.AddWithValue("@rtype", RoomNumber);
                cmd.Parameters.AddWithValue("@rcost", Rtype);

                cmd.Parameters.AddWithValue("@RKey", RC);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Room Saved");
                con.Close();
                UpdateRoom();

              
               
            }
            con.Close();

        }



















        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel39_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel40_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Panel37_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel38_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Panel35_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel33_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel36_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Panel25_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel34_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Panel31_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel27_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Panel32_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void guna2Panel29_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel30_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Panel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel28_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel23_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel24_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel19_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void guna2Panel20_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Panel15_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Panel16_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel11_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void guna2Panel12_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel7_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel8_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Dashboard = new Login();
           Dashboard.Closed += (s, args) => this.Close();
            Dashboard.Show();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Customers = new Customers();
            Customers.Closed += (s, args) => this.Close();
            Customers.Show();

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var booking = new Bookings();
          booking.Closed += (s, args) => this.Close();
          booking.Show();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2ProgressBar2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void CCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCustName();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void R1_Click(object sender, EventArgs e)
        {
            RoomNumber = 1;
        }

        private void R2_Click(object sender, EventArgs e)
        {
            RoomNumber = 2;
        }

        private void R3_Click(object sender, EventArgs e)
        {
            RoomNumber = 3;
        }

        private void R4_Click(object sender, EventArgs e)
        {
            RoomNumber = 4;
           
        }

        private void R5_Click(object sender, EventArgs e)
        {
            RoomNumber = 5;
        }

        private void R6_Click(object sender, EventArgs e)
        {
            RoomNumber = 6;
        }

        private void R7_Click(object sender, EventArgs e)
        {
            RoomNumber = 7;
        }

        private void R8_Click(object sender, EventArgs e)
        {
            RoomNumber = 8;
        }

        private void R9_Click(object sender, EventArgs e)
        {
            RoomNumber = 9;
        }

        private void R10_Click(object sender, EventArgs e)
        {
            RoomNumber = 10;
        }

        private void R11_Click(object sender, EventArgs e)
        {
            RoomNumber = 11;
        }

        private void R12_Click(object sender, EventArgs e)
        {
            RoomNumber = 12;
        }

        private void R13_Click(object sender, EventArgs e)
        {
            RoomNumber = 13;
        }

        private void R14_Click(object sender, EventArgs e)
        {
            RoomNumber = 14;
        }

        private void R15_Click(object sender, EventArgs e)
        {
            RoomNumber = 15;
        }

        private void R16_Click(object sender, EventArgs e)
        {
            RoomNumber = 16;
        }

        private void R17_Click(object sender, EventArgs e)
        {
            RoomNumber = 17;
        }

        private void R18_Click(object sender, EventArgs e)
        {
            RoomNumber = 18;
        }

        private void R19_Click(object sender, EventArgs e)
        {
            RoomNumber = 19;
        }

        private void R20_Click(object sender, EventArgs e)
        {
            RoomNumber = 5;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
