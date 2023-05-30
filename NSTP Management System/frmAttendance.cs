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
using DGVPrinterHelper;

namespace NSTP_Management_System
{
    public partial class frmAttendance : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\uvo\Desktop\attendance.accdb");
        int chck;
        public frmAttendance()
        {
            InitializeComponent();
        }
        void dataviewer()
        {
            try
            {

                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from attendance";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
                dp.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }

        private void frmAttendance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'attendanceDataSet.attendance' table. You can move, or remove it, as needed.
            this.attendanceTableAdapter.Fill(this.attendanceDataSet.attendance);
            dataviewer();
        }

        private void btnAddData_Click(object sender, EventArgs e)
        {
            try
            {

                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into attendance(StudentNo,LastName,FirstName,TPresent,Week1,Week2,Week3,Week4,Week5,Week6,Week7,Week8,Week9,Week10,Week11,Week12,Week13,Week14,Week15,Week16,Week17,Week18)values('" + txtSN.Text + "','" + txtLN.Text + "','" + txtFN.Text + "','" + comboBox19.Text + "', '" + comboBox1.Text + "', '" + comboBox2.Text
                    + "', '" + comboBox3.Text + "', '" + comboBox4.Text + "','" + comboBox5.Text + "','" + comboBox6.Text + "','" + comboBox7.Text + "','" + comboBox8.Text + "','" + comboBox9.Text + "','" + comboBox10.Text + "','" + comboBox11.Text + "','" + comboBox12.Text + "','" + comboBox13.Text + "','" + comboBox14.Text + "','" + comboBox15.Text + "','" + comboBox16.Text + "','" + comboBox17.Text + "','" + comboBox18.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record save", "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                dataviewer();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update attendance set StudentNo='" + txtSN.Text + "' where LastName ='" + txtLN.Text + "' and FirstName = '" + txtFN.Text + "' ";
                cmd.CommandText = "update attendance set LastName='" + txtLN.Text + "' where LastName ='" + txtLN.Text + "' and FirstName = '" + txtFN.Text + "' ";
                cmd.CommandText = "update attendance set FirstName='" + txtFN.Text + "' where LastName ='" + txtLN.Text + "' and FirstName = '" + txtFN.Text + "' ";
                cmd.CommandText = "update attendance set TPresent='" + comboBox19.Text + "' where LastName ='" + txtLN.Text + "' and FirstName = '" + txtFN.Text + "' ";

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Record Updated Successfully", "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataviewer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete *from attendance where StudentNo='" + txtSN.Text + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Record Successfully Delete", "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataviewer();
                txtSN.Text = "";
                txtLN.Text = "";
                txtFN.Text = "";
                comboBox19.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";
                comboBox6.Text = "";
                comboBox7.Text = "";
                comboBox8.Text = "";
                comboBox9.Text = "";
                comboBox10.Text = "";
                comboBox11.Text = "";
                comboBox12.Text = "";
                comboBox13.Text = "";
                comboBox14.Text = "";
                comboBox15.Text = "";
                comboBox16.Text = "";
                comboBox17.Text = "";
                comboBox18.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataviewer();
            txtSN.Text = "";
            txtLN.Text = "";
            txtFN.Text = "";
            comboBox19.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
            comboBox9.Text = "";
            comboBox10.Text = "";
            comboBox11.Text = "";
            comboBox12.Text = "";
            comboBox13.Text = "";
            comboBox14.Text = "";
            comboBox15.Text = "";
            comboBox16.Text = "";
            comboBox17.Text = "";
            comboBox18.Text = "";
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dataviewer();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            {
                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Attendance Report"; //give your report name
                printer.Title = "Attendance Report"; //give your report name
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true; // if you need page numbers you can keep this as true other wise false
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = ""; //this is the footer
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dataGridView1);

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            chck = 0;
            try
            {

                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from attendance where StudentNo='" + txtSearch.Text + "' or LastName ='" + txtSearch.Text + "' or FirstName ='" + txtSearch.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
                dp.Fill(dt);
                chck = Convert.ToInt32(dt.Rows.Count.ToString());
                dataGridView1.DataSource = dt;
                conn.Close();

                if (chck == 0)
                {
                    MessageBox.Show("Record not found", "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSearch.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtSN.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtLN.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtFN.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox19.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                comboBox3.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                comboBox4.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                comboBox5.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                comboBox6.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                comboBox7.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                comboBox8.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                comboBox9.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                comboBox10.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                comboBox11.Text = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
                comboBox12.Text = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                comboBox13.Text = dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
                comboBox14.Text = dataGridView1.SelectedRows[0].Cells[17].Value.ToString();
                comboBox15.Text = dataGridView1.SelectedRows[0].Cells[18].Value.ToString();
                comboBox16.Text = dataGridView1.SelectedRows[0].Cells[19].Value.ToString();
                comboBox17.Text = dataGridView1.SelectedRows[0].Cells[20].Value.ToString();
                comboBox18.Text = dataGridView1.SelectedRows[0].Cells[21].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to exit", "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (iExit == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            if (cbxFill.Text == "Present")
            {

                comboBox1.Text = "Present";
                comboBox2.Text = "Present";
                comboBox3.Text = "Present";
                comboBox4.Text = "Present";
                comboBox5.Text = "Present";
                comboBox6.Text = "Present";
                comboBox7.Text = "Present";
                comboBox8.Text = "Present";
                comboBox9.Text = "Present";
                comboBox10.Text = "Present";
                comboBox11.Text = "Present";
                comboBox12.Text = "Present";
                comboBox13.Text = "Present";
                comboBox14.Text = "Present";
                comboBox15.Text = "Present";
                comboBox16.Text = "Present";
                comboBox17.Text = "Present";
                comboBox18.Text = "Present";

            }
            else if (cbxFill.Text == "Absent")
            {
                comboBox1.Text = "Absent";
                comboBox2.Text = "Absent";
                comboBox2.Text = "Absent";
                comboBox3.Text = "Absent";
                comboBox4.Text = "Absent";
                comboBox5.Text = "Absent";
                comboBox6.Text = "Absent";
                comboBox7.Text = "Absent";
                comboBox8.Text = "Absent";
                comboBox9.Text = "Absent";
                comboBox10.Text = "Absent";
                comboBox11.Text = "Absent";
                comboBox12.Text = "Absent";
                comboBox13.Text = "Absent";
                comboBox14.Text = "Absent";
                comboBox15.Text = "Absent";
                comboBox16.Text = "Absent";
                comboBox17.Text = "Absent";
                comboBox18.Text = "Absent";

            }
            else if (cbxFill.Text == "Late")
            {
                comboBox1.Text = "Late";
                comboBox2.Text = "Late ";
                comboBox3.Text = "Late ";
                comboBox4.Text = "Late ";
                comboBox5.Text = "Late ";
                comboBox6.Text = "Late ";
                comboBox7.Text = "Late ";
                comboBox8.Text = "Late ";
                comboBox9.Text = "Late ";
                comboBox10.Text = "Late ";
                comboBox11.Text = "Late ";
                comboBox12.Text = "Late ";
                comboBox13.Text = "Late ";
                comboBox14.Text = "Late ";
                comboBox15.Text = "Late ";
                comboBox16.Text = "Late ";
                comboBox17.Text = "Late ";
                comboBox18.Text = "Late ";


            }



            else if (cbxFill.Text == "Excuse")

            {
                comboBox1.Text = "Excuse ";
                comboBox2.Text = "Excuse ";
                comboBox3.Text = "Excuse ";
                comboBox4.Text = "Excuse ";
                comboBox5.Text = "Excuse ";
                comboBox6.Text = "Excuse ";
                comboBox7.Text = "Excuse ";
                comboBox8.Text = "Excuse ";
                comboBox9.Text = "Excuse ";
                comboBox10.Text = "Excuse ";
                comboBox11.Text = "Excuse ";
                comboBox12.Text = "Excuse ";
                comboBox13.Text = "Excuse ";
                comboBox14.Text = "Excuse ";
                comboBox15.Text = "Excuse ";
                comboBox16.Text = "Excuse ";
                comboBox17.Text = "Excuse ";
                comboBox18.Text = "Excuse ";

            }

            else if (cbxFill.Text == "Present ")
            {

                comboBox1.Text = "Present";
                comboBox2.Text = "Present";
                comboBox3.Text = "Present";
                comboBox4.Text = "Present";
                comboBox5.Text = "Present";
                comboBox6.Text = "Present";
                comboBox7.Text = "Present";
                comboBox8.Text = "Present";
                comboBox9.Text = "Present";
                comboBox10.Text = "Present";
                comboBox11.Text = "Present";
                comboBox12.Text = "Present";
                comboBox13.Text = "Present";
                comboBox14.Text = "Present";
                comboBox15.Text = "Present";
                comboBox16.Text = "Present";
                comboBox17.Text = "Present";
                comboBox18.Text = "Present";
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {

                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }
    }
}
