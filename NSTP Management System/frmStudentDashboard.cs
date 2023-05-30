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
    public partial class frmStudentDashboard : Form
    {
        public frmStudentDashboard()
        {
            InitializeComponent();
        }


        public void  loadform(Object Form)
        {
            if (this.mainpanel.Controls.Count >0) 
                this.mainpanel.Controls.RemoveAt(0);
           Form f =Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }
        private void btnSF_Click(object sender, EventArgs e)
        {
            loadform(new frmShiftingForm ()); 
           
        }
        private void btnEmail_Click(object sender, EventArgs e)
        {
            loadform(new frmEmail());
        }

        private void frmStudentDashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to logout", "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
            Login s = new Login();
            s.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
