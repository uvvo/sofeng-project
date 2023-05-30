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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Login s = new Login ();
            s.Show();
            this.Hide();
       }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel3.Width += 3;

            if(panel3.Width >= 599)
            {
                timer1.Stop();
                Login login = new Login ();
                login.Show();
                this.Hide();
            }
        }
    }
}
