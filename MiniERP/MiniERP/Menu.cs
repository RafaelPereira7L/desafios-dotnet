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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormProdutos formProdutos = new FormProdutos();
            formProdutos.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormFornecedores formFornecedores = new FormFornecedores();
            formFornecedores.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormClientes formClientes = new FormClientes();
            formClientes.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormNotas formNotas = new FormNotas();
            formNotas.Show();
        }
    }
}
