using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using TerminalControleDeVendas.domain;
using TerminalControleDeVendas.dao;


namespace TerminalControleDeVendas.utils
{


    public class ImprimeVendaVista : PrintDocument
    {
        private Empresa empresa = new EmpresaDAO().getEmpresa();
        private Venda venda;
        private Font bold = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
        private Font regular = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
        private Font regularItens = new Font(FontFamily.GenericSansSerif, 6, FontStyle.Regular);

        public ImprimeVendaVista(Venda venda)
        {
            this.venda = venda;
            this.PrinterSettings.PrinterName = DefaultPrinter.GetDefaultPrinterName();
            this.OriginAtMargins = false;
            this.PrintPage += new PrintPageEventHandler(printPage);
        }

        private void printPage(object send, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int offset = 105;

            //print header
            graphics.DrawString(empresa.razaoSocial, bold, Brushes.Black, 20, 0);
            graphics.DrawString(empresa.endereco.endereco + " Nº " + empresa.endereco.numero, regular, Brushes.Black, 100, 15);
            graphics.DrawLine(Pens.Black, 20, 30, 310, 30);
            graphics.DrawString("CUPOM NÃO FISCAL", bold, Brushes.Black, 80, 35);
            graphics.DrawLine(Pens.Black, 20, 50, 310, 50);
            graphics.DrawString("PEDIDO: " + FormatId.formatLong(venda.id), regular, Brushes.Black, 20, 60);
            graphics.DrawLine(Pens.Black, 20, 75, 310, 75);

            //itens header
            graphics.DrawString("PRODUTO", regular, Brushes.Black, 20, 80);
            graphics.DrawString("UNIT.", regular, Brushes.Black, 150, 80);
            graphics.DrawString("QTD.", regular, Brushes.Black, 200, 80);
            graphics.DrawString("TOTAL", regular, Brushes.Black, 245, 80);
            graphics.DrawLine(Pens.Black, 20, 95, 310, 95);

            //itens de venda
            foreach (ItemVenda iv in venda.items)
            {
                string produto = iv.produto.descricao;
                graphics.DrawString(produto.Length > 20 ? produto.Substring(0, 20) + "..." : produto, regularItens, Brushes.Black, 20, offset);
                graphics.DrawString(FormataMonetario.format(iv.valorUn), regularItens, Brushes.Black, 155, offset);
                graphics.DrawString(Convert.ToString(iv.quantidade), regularItens, Brushes.Black, 215, offset);
                graphics.DrawString(FormataMonetario.format(iv.total), regularItens, Brushes.Black, 250, offset);
                offset += 20;
            }
            //total
            graphics.DrawLine(Pens.Black, 20, offset, 310, offset);
            offset += 5;

            decimal total = 0;
            foreach (ItemVenda iv in venda.items)
            {
                total += iv.total;
            }
            graphics.DrawString("TOTAL R$: ", bold, Brushes.Black, 20, offset);
            graphics.DrawString(FormataMonetario.format(total), bold, Brushes.Black, 230, offset);
            offset += 15;

            graphics.DrawLine(Pens.Black, 20, offset, 310, offset);
            offset += 5;

            //bottom
            graphics.DrawString("Data: " + DateTime.Now.ToString("dd/MM/yyyy"), regularItens, Brushes.Black, 20, offset);
            graphics.DrawString("HORA: " + DateTime.Now.ToString("HH:mm:ss"), regularItens, Brushes.Black, 220, offset);

            e.HasMorePages = false;

        }


    }
}