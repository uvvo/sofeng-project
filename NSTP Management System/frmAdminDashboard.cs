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
    public partial class frmAdminDashboard : Form
    {
        public frmAdminDashboard()
        {
            InitializeComponent();
        }
        public void loadform(Object Form)
        {
            if (this.AdminPanel.Controls.Count > 0)
                this.AdminPanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.AdminPanel.Controls.Add(f);
            this.AdminPanel.Tag = f;
            f.Show();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            loadform(new frmStudentInfocs());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAtten_Click(object sender, EventArgs e)
        {
            loadform(new frmAttendance());
        }

        private void btnInven_Click(object sender, EventArgs e)
        {
            frmInventory s = new frmInventory();
            s.Show();
            this.Hide();
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void AdminPanel_Paint(object sender, PaintEventArgs e)
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
    }
}
