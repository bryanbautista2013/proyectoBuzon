using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proyectoBuzon.Models
{
    public partial class TblCliente
    {
        public TblCliente()
        {
            Pedido = new HashSet<Pedido>();
            Quejas = new HashSet<Quejas>();
            Sugerencias = new HashSet<Sugerencias>();
        }

        public int IdCl { get; set; }
        [Display(Name = "Cédula")]
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string CedulaCl { get; set; }
        [Display(Name = "Nombre")]
        [StringLength(100)]
        [Required]
        public string NombresCl { get; set; }
        [Display(Name = "Apellido")]
        [StringLength(100)]
        [Required]
        public string ApellidosCl { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required]
        public DateTime FechaNacimientoCl { get; set; }
        [Display(Name = "Teléfono")]
        [Phone]
        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string TelefonoCl { get; set; }
        [Display(Name = "Correo Electrónico")]
        [EmailAddress]
        [Required]
        public string CorreoCl { get; set; }

        public ICollection<Pedido> Pedido { get; set; }
        public ICollection<Quejas> Quejas { get; set; }
        public ICollection<Sugerencias> Sugerencias { get; set; }
    }
}
