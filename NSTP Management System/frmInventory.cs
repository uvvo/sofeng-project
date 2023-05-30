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
    public partial class frmInventory : Form
    {
        public frmInventory()
        {
            InitializeComponent();
        }
        public void loadform(Object Form)
        {
            if (this.panel2.Controls.Count > 0)
                this.panel2.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(f);
            this.panel2.Tag = f;
            f.Show();
        }
        private void frmInventory_Load(object sender, EventArgs e)
        {

        }

        private void btnPos_Click(object sender, EventArgs e)
        {
            loadform(new frmPOS());
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            loadform(new frm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadform(new frmReportsale());
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmAdminDashboard s = new frmAdminDashboard();
            s.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
