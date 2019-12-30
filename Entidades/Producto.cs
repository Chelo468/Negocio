using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Entidades
{
    public class Producto
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public string observacion { get; set; }
        public DateTime fecha_alta { get; set; }
        public decimal precio_compra { get; set; }
        public decimal precio_venta { get; set; }

        [SpecialName]
        [RelationDataAttribute("id_usuario")]
        public Usuario usuario_alta { get; set; }
    }
}
