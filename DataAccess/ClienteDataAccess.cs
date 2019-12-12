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
    }
}
