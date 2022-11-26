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
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new BancoContext())
            {
                try
                {
                    Cliente cliente = new Cliente();
                    cliente.Nome = textBoxCliente.Text;
                    db.Clientes.Add(cliente);
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
                dataGridView2.DataSource = db.Clientes.ToList();
            }
        }
    }
}
