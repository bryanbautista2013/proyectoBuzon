using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proyectoBuzon.Models
{
    public partial class Sugerencias
    {
        public int IdS { get; set; }
        public int IdCl { get; set; }
        [Display(Name = "Descripción")]
        [Required]
        [StringLength(100)]
        public string DescripcionS { get; set; }
        [Display(Name = "Fecha de Sugerencia")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required]
        public DateTime FechaS { get; set; }
        public int IdTiposug { get; set; }

        public TblCliente IdClNavigation { get; set; }
        public Tiposugerencia IdTiposugNavigation { get; set; }
    }
}
