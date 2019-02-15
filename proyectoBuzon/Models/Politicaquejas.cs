using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proyectoBuzon.Models
{
    public partial class Politicaquejas
    {
        public int IdPoliticaQuejas { get; set; }
        [Display(Name = "Queja")]
        [Required]
        [StringLength(100)]
        public int IdTipoq { get; set; }
        [Display(Name = "Política")]
        [Required]
        [StringLength(100)]
        public int IdPolitica { get; set; }
        [Display(Name = "Política")]
        public Politicas 
            IdPoliticaNavigation { get; set; }
        [Display(Name = "Queja")]
        public Tipoqueja IdTipoqNavigation { get; set; }
    }
}
