using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Models
{
    internal class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [Required, MaxLength(100)]
        public string Nome { get; set; }

    }
}
