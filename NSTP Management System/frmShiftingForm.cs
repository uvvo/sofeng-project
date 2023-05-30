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
    public partial class frmShiftingForm : Form
    {
        private string Gender = "";
        public frmShiftingForm()
        {
            InitializeComponent();
        }
        private void UploadImage()
        {
            try
            {
                openFileDialog1.Filter = "JPG FILES (*.jpg)|*.jpg|PNG FILES (*.png)|*.png";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error image upload. \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmStudentDashboard  s = new frmStudentDashboard();
            s.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                Gender = "Male";
            if (radioButton2.Checked)
                Gender = "Female";
            frmPrintShiftingForm  Frm2 = new frmPrintShiftingForm ();
            Frm2.img = pictureBox1.Image;
            Frm2.SName = textBox1.Text;
            if (comboBox1.SelectedIndex == -1)
                Frm2.CorSEc = "";
            else
                Frm2.CorSEc = comboBox1.SelectedItem.ToString();
            if (comboBox2.SelectedIndex == -1)
                Frm2.Department = "";
            else
                Frm2.Department = comboBox2.SelectedItem.ToString();
            Frm2.Gender = Gender;
            Frm2.Dates = dateTimePicker1.Text;
            if (comboBox3.SelectedIndex == -1)
                Frm2.Time = "";
            else
                Frm2.Time = comboBox3.SelectedItem.ToString();
            Frm2.SN = textBox3.Text;
            Frm2.Section = textBox2.Text;
            if (comboBox4.SelectedIndex == -1)
                Frm2.RI = "";
            else
                Frm2.RI = comboBox4.SelectedItem.ToString();
            Frm2.Email = textBox4.Text;
            Frm2.CN = textBox5.Text;
            if (comboBox5.SelectedIndex == -1)
                Frm2.From = "";
            else
                Frm2.From = comboBox5.SelectedItem.ToString();
            if (comboBox6.SelectedIndex == -1)
                Frm2.To = "";
            else
                Frm2.To = comboBox6.SelectedItem.ToString();
            if (comboBox7.SelectedIndex == -1)
                Frm2.Con = "";
            else
                Frm2.Con = comboBox7.SelectedItem.ToString();
            Frm2.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UploadImage();
        }

        private void frmShiftingForm_Load(object sender, EventArgs e)
        {

        }
    }
}
