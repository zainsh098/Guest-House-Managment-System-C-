using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuestHouseSystem
{
    public partial class Splash : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
           (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
            );
        public Splash()
        {
            InitializeComponent();

            this.MinimumSize = new Size(597, 380);
            this.MaximumSize = new Size(597, 380);
            this.FormBorderStyle = FormBorderStyle.None;
            timer1.Start();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
        }







        private void timer_Tick(object sender, EventArgs e)
        {
            panelslide.Left += 25;
            if (panelslide.Left > 570)
            {
                panelslide.Left = 5;
            }
            if (panelslide.Left < 0)
            {
                panelslide.Left = 570;
            }
        }
        Timer tmr;





        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            tmr = new Timer();
            //set time interval 5 sec
            tmr.Interval = 5000;
            //starts the timer
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            //after 5 sec stop the timer
            tmr.Stop();
            //display mainform
            this.Hide();
            var form = new Login();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void panelslide_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
