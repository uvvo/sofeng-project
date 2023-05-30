using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSTP_Management_System
{
    public partial class frmPrintShiftingForm : Form
    {
        public String Date, SName, CorSEc, Department, Gender, Dates, Time, Email, SN, Section, RI, CN, From, To, Con;

        private void btnE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }

        private void pictureBoPrint_Click(object sender, EventArgs e)
        {
            Print(this.panel1);
            PrintDialog printdialog1 = new PrintDialog();
            printdialog1.Document = printDocument1;
            DialogResult result = printPreviewDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        private void panelPrint_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBoPrint_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoPrint, "Print");
        }

        public Image img = null;
        public frmPrintShiftingForm()
        {
            InitializeComponent();
            Date = DateTime.Now.ToString("M/d/yyy");
        }
        private void Print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            panel1 = pnl;
            getprintarea(pnl);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.ShowDialog();
        }
        
        private Bitmap memoryimg;

        private void getprintarea(Panel pnl)
        {
            memoryimg = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memoryimg, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }


        private void frmPrintShiftingForm_Load(object sender, EventArgs e)
        {
            label45.Text = Date;
            pictureBox5.Image = img;
            lblName .Text = SName;
            lblCourse .Text = CorSEc;
            lblDeapart .Text = Department;
            lblGender .Text = Gender;
            lblDate.Text = Dates;
            lblTime.Text = Time;
            lblSn .Text = SN;
            lblEmail.Text = Email;
            lblSection .Text = Section;
            lblReg .Text = RI;
            lblCN .Text = CN;
            lblCPT.Text = From;
            lblCPF .Text = To;
            lblCNP .Text = Con;
        }
    }
}
