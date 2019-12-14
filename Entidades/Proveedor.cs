using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Proveedor
    {
        public int id_proveedor { get; set; }
        public string descripcion { get; set; }
        public string observacion { get; set; }
        public string mail { get; set; }
        public string telefono { get; set; }
        public string calle { get; set; }
        public int calle_nro { get; set; }
        public DateTime fecha_alta { get; set; }

        [SpecialName]
        public Usuario usuario_alta { get; set; }
    }
}
