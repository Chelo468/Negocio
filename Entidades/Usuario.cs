using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Entidades
{
    public class Usuario
    {
        [AlternativeNameAttribute("id_usuario")]
        [KeyDataAttribute]
        public int id_usuarios { get; set; }
        public string nombre_usuario { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public string telefono { get; set; }
        public bool habilitado { get; set; }
        public bool administrador { get; set; }
    }
}
