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
    public partial class frmRegistration : Form
    {
        public frmRegistration()
        {
            InitializeComponent();
        }
        
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        private void frmRegistration_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUS.Text == "" && txtPass.Text == "" && txtConfirm.Text == "")
            {
                MessageBox.Show("Username and Password field are empty", "Registration is failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPass.Text == txtConfirm.Text)
            {
                con.Open();

                string register = "INSERT INTO tbl_users VALUES ('" + txtUS.Text + "','" + txtPass.Text + "' )";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();

                txtUS.Text = "";
                txtPass.Text = "";
                txtConfirm.Text = "";
                MessageBox.Show("Your Account is created has been sucessfully", "Registration  sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Password doest match, Please  re-enter", "Registration is failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Text = "";
                txtConfirm.Text = "";
                txtPass.Focus();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUS.Text = "";
            txtPass.Text = "";
            txtConfirm.Text = "";
            txtUS.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPass.PasswordChar = '\0';
                txtConfirm.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '•';
                txtConfirm.PasswordChar = '•';
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new lgnStudent ().Show();
            this.Hide();
        }
    }
}
