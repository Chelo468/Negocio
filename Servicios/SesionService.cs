using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class SesionService
    {
        public static Usuario usuario { get; set; }

        public static Usuario getUsuario()
        {
            return usuario;
        }

        public static void setUsuario(Usuario pUsuario)
        {
            usuario = pUsuario;
        }
    }
}
