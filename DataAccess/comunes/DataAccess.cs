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
    public sealed class DataAccess
    {
        private static SqlConnection conexion { get; set; }

        private static SqlConnection getConnection()
        {
            if(conexion == null)
            {
                conexion = new SqlConnection(Configuracion.sqlConn);
            }

            return conexion;

        }

        protected internal static DataTable executeQueryProc(string storedProcedure, List<SqlParameter> parameterList)
        {
            try
            {
                DataTable result = new DataTable();

                SqlConnection conexion = getConnection();//new SqlConnection(Configuracion.sqlConn);

                conexion.Open();

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = storedProcedure;

                if (parameterList != null && parameterList.Count > 0)
                {
                    foreach (var parametro in parameterList)
                    {
                        comando.Parameters.Add(parametro);
                    }
                }

                result.Load(comando.ExecuteReader());

                conexion.Close();

                return result;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        protected internal static void executeNonQueryProc(string storedProcedure, List<SqlParameter> parameterList)
        {
            try
            {
                SqlConnection conexion = getConnection();//new SqlConnection(Configuracion.sqlConn);

                conexion.Open();

                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = storedProcedure;

                if (parameterList != null && parameterList.Count > 0)
                {
                    foreach (var parametro in parameterList)
                    {
                        comando.Parameters.Add(parametro);
                    }
                }

                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            

        }

        protected internal static void loguearExcepcion(Exception ex, string nameSpace, string clase, string metodo)
        {
            SimpleLog.Instancia().GuardarLog(ex, nameSpace, clase, metodo, Configuracion.daoFilePath);
        }
    }
}
