using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductoDataAccess
    {
        public static List<Producto> getAll()
        {
            try
            {
                List<Producto> productos = new List<Producto>();

                DataTable result = new DataTable();

                result = DataAccess.executeQueryProc("productosGetAll", null);

                productos = DAO.DataTableToObjectList<Producto>(result);

                return productos;
            }
            catch (Exception ex)
            {
                DataAccess.loguearExcepcion(ex, "DataAccess", "ProductoDataAccess", "getAll");
                throw ex;
            }
        }

        public static List<Producto> getByNombre(string descripcion)
        {
            try
            {
                List<Producto> productos = new List<Producto>();

                DataTable result = new DataTable();

                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(new SqlParameter("@nombre", descripcion));

                result = DataAccess.executeQueryProc("productosGetByNombre", parametros);

                productos = DAO.DataTableToObjectList<Producto>(result);

                return productos;
            }
            catch (Exception ex)
            {
                DataAccess.loguearExcepcion(ex, "DataAccess", "ProductoDataAccess", "getByDescripcion");
                throw ex;
            }
        }

        public static Producto getExistente(Producto producto)
        {
            try
            {
                DataTable result = new DataTable();

                Producto productoExistente = new Producto();

                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(new SqlParameter("@nombre", producto.nombre));
                parametros.Add(new SqlParameter("@observacion", producto.observacion));

                result = DataAccess.executeQueryProc("productosGetByNombreObservacion", parametros);

                if(result.Rows.Count > 0)
                    productoExistente = DAO.DataTableToObject<Producto>(result);

                return productoExistente;
            }
            catch (Exception ex)
            {
                DataAccess.loguearExcepcion(ex, "DataAccess", "ProductoDataAccess", "getExistente");
                throw ex;
            }
        }

        public static void asignarProveedor(Producto producto, Proveedor proveedor)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(new SqlParameter("@id_producto", producto.id_producto));
                parametros.Add(new SqlParameter("@id_proveedor", proveedor.id_proveedor));

            }
            catch (Exception ex)
            {
                DataAccess.loguearExcepcion(ex, "DataAccess", "ProductoDataAccess", "asignarProveedor");
            }
        }

        public static void crear(ref Producto producto)
        {
            try
            {
                DataTable result = new DataTable();

                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(new SqlParameter("@nombre", producto.nombre));
                parametros.Add(new SqlParameter("@observacion", producto.observacion));
                parametros.Add(new SqlParameter("@precio_compra", producto.precio_compra));
                parametros.Add(new SqlParameter("@precio_venta", producto.precio_venta));
                parametros.Add(new SqlParameter("@fecha_alta", producto.fecha_alta));
                parametros.Add(new SqlParameter("@usuario_alta", producto.usuario_alta));

                result = DataAccess.executeQueryProc("productosInsert", parametros);

                if (result.Rows.Count > 0)
                {
                    producto.id_producto = int.Parse(result.Rows[0][0].ToString());
                }
            }
            catch (Exception ex)
            {
                DataAccess.loguearExcepcion(ex, "DataAccess", "ProductoDataAccess", "crear");
                throw ex;
            }
        }
    }
}
