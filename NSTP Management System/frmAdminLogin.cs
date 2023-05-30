using NSTP_Management_System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NSTP_Management_System
{
    public partial class frmAdminLogin : Form
    {
        public frmAdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUS.Text=="admin" && txtPass.Text == "123")
            {
                new frmAdminDashboard().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username and Password is incorrect, try again!");
                txtUS.Clear();
                txtPass.Clear(); 
                txtUS .Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPass.PasswordChar = '\0';

            }
            else
            {
                txtPass.PasswordChar = '•';

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Login s = new Login();
            s.Show();
            this.Hide();
        }
    }
}
