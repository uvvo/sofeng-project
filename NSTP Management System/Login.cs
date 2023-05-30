using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NSTP_Management_System
{
    public partial class Login : Form
    {    
        
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lgnStudent  s = new lgnStudent ();
            s.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAdminLogin s = new frmAdminLogin ();
            s.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void btnA_Click(object sender, EventArgs e)
        {
            frmAdminLogin s = new frmAdminLogin();
            s.Show();
            this.Hide();
        }
        private void btnS_Click(object sender, EventArgs e)
        {
            lgnStudent s = new lgnStudent();
            s.Show();
            this.Hide();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; 
        }
        private void btnMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private void btnE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
