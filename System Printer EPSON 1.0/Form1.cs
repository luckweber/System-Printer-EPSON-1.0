using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Printer_EPSON_1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            document.Print();
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string texto = "fkldklfd";
            Font letra = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            SolidBrush cor = new SolidBrush(Color.Black);
            Point ponto = new Point(100, 100);

            e.Graphics.DrawString(texto, letra, cor, ponto);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PrintPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            string texto = "fkldklfd";
            Font letra = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            SolidBrush cor = new SolidBrush(Color.Black);
            Point ponto = new Point(100, 100);

            e.Graphics.DrawString(texto, letra, cor, ponto);
        }

        private void TabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            document.Print();
        }

        private void Panel2_Paint_1(object sender, PaintEventArgs e)
        {
            string texto = "fkldklfd";
            Font letra = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            SolidBrush cor = new SolidBrush(Color.Black);
            Point ponto = new Point(100, 100);

            e.Graphics.DrawString(texto, letra, cor, ponto);
        }
    }
}
