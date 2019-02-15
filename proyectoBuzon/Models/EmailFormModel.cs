using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoBuzon.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name = "Destinatario"), EmailAddress]
        public string Destinatario { get; set; }
        [Required, Display(Name = "Asunto")]
        public string Asunto { get; set; }
        [Required, Display(Name = "Mensaje")]
        public string Mensaje { get; set; }
    }
}
