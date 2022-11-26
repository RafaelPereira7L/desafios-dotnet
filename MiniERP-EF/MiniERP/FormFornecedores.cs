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
    public partial class FormFornecedores : Form
    {

        public FormFornecedores()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new BancoContext())
            {
                try
                {
                    Fornecedor fornecedor = new Fornecedor();
                    fornecedor.Nome = textBoxFornecedor.Text;
                    db.Fornecedores.Add(fornecedor);
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
                dataGridView1.DataSource = db.Fornecedores.ToList();
            }
        }
    }
}
