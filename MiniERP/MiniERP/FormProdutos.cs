using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniERP
{
    public partial class FormProdutos : Form
    {
        public FormProdutos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            produto.idFornecedor = int.Parse(textBoxId.Text);
            produto.Nome = textBoxProduto.Text;


            bool retorno = produto.cadastrarProduto();

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

            string sql = "select * from produtos";

            DataTable dt = new DataTable();

            dt = bd.executarConsultaGenerica(sql);

            dataGridView2.DataSource = dt;
        }
    }
}
