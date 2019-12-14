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
    public class ClienteDataAccess
    {
        public static Cliente getById(int id_cliente)
        {
            try
            {
                Cliente cliente = new Cliente();

                DataTable result = new DataTable();

                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(new SqlParameter("@id_cliente", id_cliente));

                result = DataAccess.executeQueryProc("clienteGetById", parametros);

                cliente = DAO.DataTableToObject<Cliente>(result);

                return cliente;
            }
            catch (Exception ex)
            {
                DataAccess.loguearExcepcion(ex, "DataAccess", "ClienteDataAccess", "getByCodigo");
                throw ex;
            }
        }

        public static Cliente getExistente(Cliente cliente)
        {
            try
            {
                Cliente clienteExistente = new Cliente();

                DataTable result = new DataTable();

                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(new SqlParameter("@descripcion", cliente.descripcion));
                parametros.Add(new SqlParameter("@mail", cliente.mail));
                parametros.Add(new SqlParameter("@telefono", cliente.telefono));

                result = DataAccess.executeQueryProc("clienteGetExistente", parametros);

                clienteExistente = DAO.DataTableToObject<Cliente>(result);

                return clienteExistente;
            }
            catch (Exception ex)
            {
                DataAccess.loguearExcepcion(ex, "DataAccess", "ClienteDataAccess", "getExistente");
                throw ex;
            }
        }

        public static void crear(ref Cliente cliente)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(new SqlParameter("@descripcion", cliente.descripcion));
                parametros.Add(new SqlParameter("@mail", cliente.mail));
                parametros.Add(new SqlParameter("@telefono", cliente.telefono));
                parametros.Add(new SqlParameter("@fecha_alta", cliente.fecha_alta));
                parametros.Add(new SqlParameter("@usuario_alta", cliente.usuario_alta.id_usuario));

                DataTable result = DataAccess.executeQueryProc("clienteInsert", parametros);

                if(result.Rows.Count > 0)
                {
                    cliente.id_cliente = int.Parse(result.Rows[0][0].ToString());
                }
                                
            }
            catch (Exception ex)
            {
                DataAccess.loguearExcepcion(ex, "DataAccess", "ClienteDataAccess", "crear");
                throw ex;
            }
        }
    }
}
