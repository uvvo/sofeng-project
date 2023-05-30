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
    public partial class frm : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\uvo\Desktop\item.accdb");
        int chck;
        public frm()
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
                cmd.CommandText = "select * from item";
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
        private void frm_Load(object sender, EventArgs e)
        {
            dataviewer();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into item(ProductCode,ItemName,Discription,Suppliar,PriceSale,Stock,FreeStock,LastOrderDate,ReOrderDate,CostPrice)values('" + txtPC.Text + "','" + txtIN.Text + "','" + txtDis.Text + "','" + txtSupp.Text + "', '" + txtPS.Text + "', '" + txtStock.Text + "', '" + txtFS.Text + "', '" + dateTimePicker1.Text + "', '" + dateTimePicker2.Text + "', '" + txtCP.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Add save", "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                dataviewer();

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
                txtPC.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtIN.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtDis.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtSupp.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txtPS.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txtStock.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txtFS.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                dateTimePicker2.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                txtCP.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();

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
                cmd.CommandText = "update item set ProductCode='" + txtPC.Text + "' where ItemName ='" + txtIN.Text + "' and Discription = '" + txtDis.Text + "' ";
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

        private void btnDelere_Click(object sender, EventArgs e)
        {
            try
            {

                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete *from item where ProductCode='" + txtPC.Text + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Info Successfully Delete", "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataviewer();
                txtPC.Text = "";
                txtIN.Text = "";
                txtDis.Text = "";
                txtSupp.Text = "";
                txtPS.Text = "";
                txtStock.Text = "";
                txtFS.Text = "";
                dateTimePicker1.Text = "";
                dateTimePicker2.Text = "";
                txtCP.Text = "";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            dataviewer();
            txtPC.Text = "";
            txtIN.Text = "";
            txtDis.Text = "";
            txtSupp.Text = "";
            txtPS.Text = "";
            txtStock.Text = "";
            txtFS.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            txtCP.Text = "";
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
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to exit", "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
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
                cmd.CommandText = "select * from item where ProductCode='" + txtSearch.Text + "' or ItemName ='" + txtSearch.Text + "' or Discription ='" + txtSearch.Text + "'";
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Stock Report"; //give your report name
            printer.Title = "Stock Report"; //give your report name
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
}
