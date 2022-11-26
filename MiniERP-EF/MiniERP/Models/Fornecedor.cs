using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Models
{
    internal class Fornecedor
    {
        [Key]
        public int IdFornecedor { get; set; }
        [Required, MaxLength(100)]
        public string Nome { get; set; }

        public List<Produto> Produtos { get; set; }

    }
}
