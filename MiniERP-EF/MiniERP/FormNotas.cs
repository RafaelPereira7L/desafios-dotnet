using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore;
using MiniERP.Models;

namespace MiniERP
{
    public partial class FormNotas : Form
    {
        public FormNotas()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var db = new BancoContext())
            {
                try
                {
                    Nota nota = new Nota();
                    nota.IdCliente = int.Parse(textBoxIDCliente.Text);
                    nota.IdProduto = int.Parse(textBoxIDProduto.Text);
                    nota.Total = db.Produtos.Find(nota.IdProduto).Preco;

                    db.Notas.Add(nota);
                    db.SaveChanges();
                    MessageBox.Show("Cadastrado com sucesso!");
                }
                catch
                {
                    MessageBox.Show("Erro ao cadastrar!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new BancoContext())
            {
                dataGridView2.DataSource = db.Notas.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nomeNota = DateTime.Now.Day + DateTime.Now.Minute + DateTime.Now.Millisecond;
            string nomeArquivo = @"C:\Users\Fael\Desktop\" + nomeNota + "nota.pdf";

            FileStream arquivoPDF = new FileStream(nomeArquivo, FileMode.Create);
            Document doc = new Document(PageSize.A4);
            PdfWriter escritorPDF = PdfWriter.GetInstance(doc, arquivoPDF);

            string dados = "";

            Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold));
            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Add("-=-=-=-=-=-NOTA GERADA MINI ERP-=-=-=-=-=-\n");
            paragrafo.Add("--------------\n");

            using (var db = new BancoContext())
            {
                var dt = db.Notas.ToList();

                foreach (var data in dt)
                {
                    string conteudo = "";
                    conteudo += "\nCódigo Nota: " + data.IdNota;
                    conteudo += "\nCódigo Cliente: " + data.IdCliente;
                    conteudo += "\nCódigo Produto: " + data.IdProduto;
                    conteudo += "\nPreço Produto: R$" + data.Total;

                    paragrafo.Add(conteudo + "\n");
                    paragrafo.Add("--------------\n");
                }

                double total = 0;
                foreach(var item in dt)
                {
                    total += item.Total;
                }
                paragrafo.Add("Total do pedido: R$" + total);

                doc.Open();
                doc.Add(paragrafo);
                doc.Close();
            }
        }
    }
}
