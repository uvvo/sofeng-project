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
using System.Globalization;
using DGVPrinterHelper;

namespace NSTP_Management_System
{
    public partial class frmPOS : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\uvo\source\repos\pos\sale.accdb");
        public frmPOS()
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
                cmd.CommandText = "select * from sale";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
                dp.Fill(dt);
                dataGridView2.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }

        public double Cost_of_Items()
        {
            Double sum = 0;
            int i = 0;

            for (i = 0; i < (dataGridView1.Rows.Count);
            i++)
            {
                sum = sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
            }
            return sum;
        }
        private void AddCost()
        {
            Double tax, g;
            tax = 0.0;
            if (dataGridView1.Rows.Count > 0)
            {
                lblTax.Text = String.Format(new CultureInfo("fil-PH"), "{0:C}", (((Cost_of_Items() * tax) / 100)));
                lblSub.Text = String.Format(new CultureInfo("fil-PH"), "{0:C}", (Cost_of_Items()));
                g = ((Cost_of_Items() * tax) / 100);
                lblTotal.Text = String.Format(new CultureInfo("fil-PH"), "{0:C}", ((Cost_of_Items() + g)));
                lblCode.Text = Convert.ToString(g + Cost_of_Items());


            }
        }
        private void Change()
        {
            Double tax, g, c;
            tax = 0.0;
            if (dataGridView1.Rows.Count > 0)
            {
                g = ((Cost_of_Items() * tax) / 100) + Cost_of_Items();
                c = Convert.ToInt32(lblTax.Text);
                lblTax.Text = String.Format(new CultureInfo("fil-PH"), "{0:C}", c - g);
                    
            }
        }


        private void frmPOS_Load(object sender, EventArgs e)
        {
            dataviewer();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                lblCode.Text = "";
                comboBox1.Text = "";
                lblSub.Text = "";
                lblTax.Text = "";
                lblTotal.Text = "";
                txtItem.Text = "";
                txtQty.Text = "";
                txtPrice.Text = "";
                comboBox1.Text = "";
                dateTimePicker1.Text = "";
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnItem1_Click(object sender, EventArgs e)
        {

            Double CostofItem = 100;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Bandage"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;
                }
            }
            dataGridView1.Rows.Add("Bandage", "1", CostofItem);
            AddCost();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into sale(Item,Qty,Price,MethodPayment,DateOrder,Total)values('" + txtItem.Text + "','" + txtQty.Text + "','" + txtPrice.Text + "','" + comboBox1.Text + "','" + dateTimePicker1.Text + "','" + lblTotal.Text + "')";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete *from sale where Item='" + txtItem.Text + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Record Successfully Delete", "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataviewer();
                lblTotal.Text = "";
                txtItem.Text = "";
                txtQty.Text = "";
                txtPrice.Text = "";
                comboBox1.Text = "";
                dateTimePicker1.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtItem.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                txtQty.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                txtPrice.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
                dateTimePicker1.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
                lblTotal.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Access Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                lblCode.Text = "";
                comboBox1.Text = "";
                lblSub.Text = "";
                lblTax.Text = "";
                lblTotal.Text = "";
                txtItem.Text = "";
                txtQty.Text = "";
                txtPrice.Text = "";
                comboBox1.Text = "";
                dateTimePicker1.Text = "";
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Invoice"; //give your report name
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true; // if you need page numbers you can keep this as true other wise false
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "footer"; //this is the footer
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(dataGridView1);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnItem2_Click(object sender, EventArgs e)
        {

            Double CostofItem = 200;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "NSTP t-shirt"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;
                }
            }
            dataGridView1.Rows.Add("NSTP t-shirt", "1", CostofItem);
            AddCost();
        }
    }
}
