using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proyectoBuzon.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            Quejas = new HashSet<Quejas>();
        }

        [Display(Name = "ID")]
        public int IdPedido { get; set; }
        [Display(Name = "Cliente")]
        public int IdCl { get; set; }
        [Display(Name = "Cliente")]
        public TblCliente IdClNavigation { get; set; }
        public ICollection<Quejas> Quejas { get; set; }
    }
}
