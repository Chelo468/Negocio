using DataAccess;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Servicios
{
    public class ProductoService
    {
        public static List<Producto> getAll()
        {
            try
            {
                return ProductoDataAccess.getAll();
            }
            catch (Exception)
            {
                return new List<Producto>();
            }
        }

        public static List<Producto> getByNombre(string descripcion)
        {
            try
            {
                return ProductoDataAccess.getByNombre(descripcion);
            }
            catch (Exception)
            {
                return new List<Producto>();
            }
        }

        public static bool crear(ref Producto producto)
        {
            try
            {
                producto.fecha_alta = DateTime.Now;
                producto.usuario_alta = SesionService.getUsuario();

                Producto productoExistente = ProductoDataAccess.getExistente(producto);

                if (productoExistente != null && productoExistente.id_producto > 0)
                {
                    producto = productoExistente;
                    return false;
                }                    
                else
                {
                    ProductoDataAccess.crear(ref producto);
                }

                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
            

        }

        public static void asignarProveedor(Producto producto, Proveedor proveedor)
        {
            try
            {
                if (proveedor != null && proveedor.id_proveedor > 0)
                {
                    ProductoDataAccess.asignarProveedor(producto, proveedor);
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}
