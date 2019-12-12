using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        public int id_cliente { get; set; }
        public string descripcion { get; set; }
        public string mail { get; set; }
        public string telefono { get; set; }
        public DateTime fecha_alta { get; set; }
        public Usuario usuario_alta { get; set; }

        public override string ToString()
        {
            StringBuilder cliente = new StringBuilder();

            cliente.AppendLine("Descripcion: " + descripcion);
            cliente.AppendLine("Mail: " + mail);
            cliente.AppendLine("Telefono: " + telefono);
            cliente.AppendLine("Fecha de Alta: " + fecha_alta);
            return cliente.ToString();
        }
    }
}
