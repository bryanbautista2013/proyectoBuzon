using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proyectoBuzon.Models
{
    public partial class Respuestasqueja
    {
        public int IdRespuestaq { get; set; }
        public int IdQ { get; set; }
        [Required]
        [StringLength(100)]
        public string DescResp { get; set; }

        public Quejas IdQNavigation { get; set; }
    }
}
