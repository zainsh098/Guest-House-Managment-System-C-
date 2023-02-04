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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Users obj=new Users();
            obj.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\source\repos\GuestHouseSystem\GuestHouseSystem\GuestHouseData.mdf;Integrated Security=True");

        private void BookCBtn_Click(object sender, EventArgs e)
        {
            if (nameTb.Text == "" || passTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else {

                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Users where UName='" + nameTb.Text + "' and UPass='"+passTb.Text+ "'" , con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1") 

                {
                    this.Hide();
                    var Dashboard = new Dashboard();
                    Dashboard.Closed += (s, args) => this.Close();
                    Dashboard.Show(); 

                 
                  

                }
                con.Close();


            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
