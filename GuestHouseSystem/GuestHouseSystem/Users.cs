using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuestHouseSystem
{
    public partial class Users : Form
    {


        public Users()
        {
          
            InitializeComponent();
            ShowUsers();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\source\repos\GuestHouseSystem\GuestHouseSystem\GuestHouseData.mdf;Integrated Security=True");

        private void Reset()
        {

            UName.Text = "";
            UPhone.Text = "";
            UPass.Text = "";
            deleteID.Text = "";



        }




        private void ShowUsers()
        {

            sqlConnection.Open();
            string query = "Select *  From Users";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds=new DataSet();   
            sda.Fill(ds);
            UDV.DataSource = ds.Tables[0];
            sqlConnection.Close();
        
        
        
        
        }

        private void SaveUBtn_Click(object sender, EventArgs e)
        {
            if (UName.Text == "" || UPhone.Text == "" || UPass.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                
                    sqlConnection.Open();
                    SqlCommand cmd= new SqlCommand("insert into Users(UName,UPhone,UPass) values('"+UName.Text +"','"+UPhone.Text+"','"+UPass.Text +"')", sqlConnection);
                  
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Saved");
                       sqlConnection.Close();

                ShowUsers();
                Reset();
                }

            }
        int Key=0;
        private void UDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UName.Text = UDV.SelectedRows[0].Cells[1].Value.ToString();
            UPhone.Text = UDV.SelectedRows[1].Cells[2].Value.ToString();
            UPass.Text = UDV.SelectedRows[2].Cells[3].Value.ToString();
            if (UName.Text == "")
            {

                Key = 0;
            }
            else { 
            
            Key=Convert.ToInt32(UDV.SelectedRows[0].Cells[0].Value.ToString());
            
            }


        }

        private void EditUBtn_Click(object sender, EventArgs e)
        {

            if (UName.Text == "" || UPhone.Text == "" || UPass.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {

                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("Update Users Set UName=@UN,UPhone=@UP,UPass=@UPA  where UId=@UKey",sqlConnection);
                cmd.Parameters.AddWithValue("@UN", UName.Text);
                cmd.Parameters.AddWithValue("@UP", UPhone.Text);
                cmd.Parameters.AddWithValue("@UPA", UPass.Text);
                cmd.Parameters.AddWithValue("@UKey", Key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Edited");
                sqlConnection.Close();
            

                ShowUsers();
                Reset();

            }


        }

        private void DeleteUBtn_Click(object sender, EventArgs e)
        {
            if (deleteID.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {

                sqlConnection.Open();
           
                SqlCommand cmd = new SqlCommand("Delete from  Users where UId="+deleteID.Text   ,  sqlConnection);

                cmd.ExecuteNonQuery();
                MessageBox.Show("User Deleted");
                sqlConnection.Close();


                ShowUsers();
                Reset();

            }
        }
    }
    }

