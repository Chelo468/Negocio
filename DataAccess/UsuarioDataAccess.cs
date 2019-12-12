using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace DataAccess
{
    public class UsuarioDataAccess
    {
        public static Usuario getByLogin(string nombre_usuario, string password)
        {
            try
            {
                DataTable result = new DataTable();

                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(new SqlParameter("@nombre_usuario", nombre_usuario));
                parametros.Add(new SqlParameter("@password", password));

                result = DataAccess.executeQueryProc("usuarioGetByLogin", parametros);

                Usuario usuario = DAO.DataTableToObject<Usuario>(result);

                return usuario;
            }
            catch (Exception ex)
            {
                DataAccess.loguearExcepcion(ex, "DataAccess","UsuarioDataAccess", "getByLogin");
                throw ex;
            }
        }
    }
}
