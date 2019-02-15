using System;
using System.Collections.Generic;

namespace proyectoBuzon.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Quejas = new HashSet<Quejas>();
        }

        public int IdEstado { get; set; }
        public string NomEstado { get; set; }

        public ICollection<Quejas> Quejas { get; set; }
    }
}
