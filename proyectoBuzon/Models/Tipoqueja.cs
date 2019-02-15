using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proyectoBuzon.Models
{
    public partial class Tipoqueja
    {
        public Tipoqueja()
        {
            Politicaquejas = new HashSet<Politicaquejas>();
            Quejas = new HashSet<Quejas>();
        }

        public int IdTipoq { get; set; }
        [Display(Name = "Tipo de Queja")]
        [Required]
        [StringLength(100)]
        public string NombreTipoq { get; set; }

        public ICollection<Politicaquejas> Politicaquejas { get; set; }
        public ICollection<Quejas> Quejas { get; set; }
    }
}
