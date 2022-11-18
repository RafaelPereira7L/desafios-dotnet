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
            Nota nota = new Nota();
            nota.CodNota = DateTime.Now.Day + DateTime.Now.Minute + DateTime.Now.Millisecond;
            nota.IDCliente = int.Parse(textBoxIDCliente.Text);
            nota.IDProduto = int.Parse(textBoxIDProduto.Text);


            bool retorno = nota.cadastrarNota();

            if (retorno)
            {
                MessageBox.Show("Cadastrado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();

            string sql = "select * from notas";

            DataTable dt = new DataTable();

            dt = bd.executarConsultaGenerica(sql);

            dataGridView2.DataSource = dt;
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

            Banco bd = new Banco();

            string sql = "select * from notas";

            DataTable dt = new DataTable();

            dt = bd.executarConsultaGenerica(sql);


            foreach(DataRow data in dt.Rows)
            {
                string conteudo = "";
                conteudo += "\nCódigo Nota: "+ data[0].ToString();
                conteudo += "\nCódigo Cliente: "+ data[1].ToString();
                conteudo += "\nCódigo Produto: "+ data[2].ToString();

                paragrafo.Add(conteudo+"\n");
                paragrafo.Add("--------------\n");
            }


            doc.Open();
            doc.Add(paragrafo);
            doc.Close();
        }
    }
}
