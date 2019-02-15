using System;
using System.Collections.Generic;

namespace proyectoBuzon.Models
{
    public partial class Tiposugerencia
    {
        public Tiposugerencia()
        {
            Sugerencias = new HashSet<Sugerencias>();
        }

        public int IdTiposug { get; set; }
        public string NombreTipoq { get; set; }

        public ICollection<Sugerencias> Sugerencias { get; set; }
    }
}
