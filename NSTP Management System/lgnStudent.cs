using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NSTP_Management_System
{
    public partial class lgnStudent : Form
    {
        public lgnStudent()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void lgnStudent_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            con.Open();
            string login = "SELECT * FROM tbl_users WHERE username= '" + txtUS.Text + "' and password ='" + txtPass.Text + "'";
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                new frmStudentDashboard().Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid username or password try again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUS.Text = "";
                txtPass.Text = "";
                txtUS.Focus();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new frmRegistration ().Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUS.Text = "";
            txtPass.Text = "";
            txtUS.Focus();
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Login s = new Login();
            s.Show();
            this.Hide();
        }
    }
}
