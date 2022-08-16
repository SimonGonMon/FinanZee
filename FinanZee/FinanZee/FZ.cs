using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;




namespace FinanZee
{
    public partial class FZ : Form  
    {


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );


        public FZ()
        {
            InitializeComponent();


            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            //btnDashboard.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Inicio";
            this.pnlLoader.Controls.Clear();
            FZ_Main Form2_Vrb = new FZ_Main()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true


            };
            Form2_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlLoader.Controls.Add(Form2_Vrb);
            Form2_Vrb.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46,51,73);

            lblTitle.Text = "Inicio";
            this.pnlLoader.Controls.Clear();
            FZ_Main Form2_Vrb = new FZ_Main()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true


            };
            Form2_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlLoader.Controls.Add(Form2_Vrb);
            Form2_Vrb.Show();
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnAnalytics.Height;
            pnlNav.Top = btnAnalytics.Top;
            pnlNav.Left = btnAnalytics.Left;
            btnAnalytics.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Analíticas";
            this.pnlLoader.Controls.Clear();
            FZ_Analytics Form2_Vrb = new FZ_Analytics()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true


            };
            Form2_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlLoader.Controls.Add(Form2_Vrb);
            Form2_Vrb.Show();
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnCalendar.Height;
            pnlNav.Top = btnCalendar.Top;
            pnlNav.Left = btnCalendar.Left;
            btnCalendar.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Calendario";
            this.pnlLoader.Controls.Clear();
            FZ_Calendar Form2_Vrb = new FZ_Calendar()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true


            };
            Form2_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlLoader.Controls.Add(Form2_Vrb);
            Form2_Vrb.Show();
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnContact.Height;
            pnlNav.Top = btnContact.Top;
            pnlNav.Left = btnContact.Left;
            btnContact.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Soporte";
            this.pnlLoader.Controls.Clear();
            FZ_Contact Form2_Vrb = new FZ_Contact()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true


            };
            Form2_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlLoader.Controls.Add(Form2_Vrb);
            Form2_Vrb.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnSettings.Height;
            pnlNav.Top = btnSettings.Top;
            pnlNav.Left = btnSettings.Left;
            btnSettings.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Ajustes";
            this.pnlLoader.Controls.Clear();
            FZ_Settings Form2_Vrb = new FZ_Settings()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true


            };
            Form2_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlLoader.Controls.Add(Form2_Vrb);
            Form2_Vrb.Show();
        }

        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnAnalytics_Leave(object sender, EventArgs e)
        {
            btnAnalytics.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnCalendar_Leave(object sender, EventArgs e)
        {
            btnCalendar.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnContact_Leave(object sender, EventArgs e)
        {
            btnContact.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnSettings_Leave(object sender, EventArgs e)
        {
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pnlLoader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
