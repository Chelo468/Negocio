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
    public class ProveedorDataAccess
    {
        public static List<Proveedor> getAll()
        {
            try
            {
                List<Proveedor> proveedores = new List<Proveedor>();

                DataTable result = new DataTable();

                result = DataAccess.executeQueryProc("proveedoresGetAll", null);

                proveedores = DAO.DataTableToObjectList<Proveedor>(result);

                return proveedores;
            }
            catch (Exception ex)
            {
                DataAccess.loguearExcepcion(ex, "DataAcces", "ProveedorDataAccess", "getAll");
                throw ex;
            }
        }

        public static Proveedor getById(int id_proveedor)
        {
            try
            {
                DataTable result = new DataTable();

                Proveedor prov = new Proveedor();

                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(new SqlParameter("@id_proveedor", id_proveedor));

                result = DataAccess.executeQueryProc("proveedorGetById", parametros);

                if(result.Rows.Count > 0)
                    prov = DAO.DataTableToObject<Proveedor>(result);

                return prov;
            }
            catch (Exception ex)
            {
                DataAccess.loguearExcepcion(ex, "DataAccess", "ProveedorDataAccess", "getById");
                throw ex;
            }
        }
    }
}
