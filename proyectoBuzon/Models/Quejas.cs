using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proyectoBuzon.Models
{
    public partial class Quejas
    {
        public Quejas()
        {
            Respuestasqueja = new HashSet<Respuestasqueja>();
        }

        public int IdQ { get; set; }
        public int IdCl { get; set; }
        public int IdTipoq { get; set; }
        public int IdPolitica { get; set; }
        public int IdPedido { get; set; }
        public int IdEstado { get; set; }
        
        [Required]
        [StringLength(100)]
        public string DescripcionQ { get; set; }
        public DateTime? FechaQ { get; set; }

        public TblCliente IdClNavigation { get; set; }
        public Estado IdEstadoNavigation { get; set; }
        public Pedido IdPedidoNavigation { get; set; }
        public Politicas IdPoliticaNavigation { get; set; }
        public Tipoqueja IdTipoqNavigation { get; set; }
        public ICollection<Respuestasqueja> Respuestasqueja { get; set; }
    }
}
