using MiniERP.Models;
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

            using (var db = new BancoContext())
            {
                try
                {
                    Produto produto = new Produto();
                    produto.IdFornecedor = int.Parse(textBoxId.Text);
                    produto.Preco = double.Parse(textBoxPreco.Text);
                    produto.Nome = textBoxProduto.Text;
                    db.Produtos.Add(produto);
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
                dataGridView2.DataSource = db.Produtos.ToList();
            }
        }
    }
}
