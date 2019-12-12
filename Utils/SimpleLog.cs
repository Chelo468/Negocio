using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class SimpleLog
    {
        private static SimpleLog _objSimpleLog;
        private static bool _blCreated;

        /// <summary>
        /// Constructor de la clase (Oculto)
        /// </summary>
        public SimpleLog()
        {

        }

        /// <summary>
        /// Implementacion Singleton del Logger
        /// </summary>
        /// <returns></returns>
        public static SimpleLog Instancia()
        {
            if (_blCreated == false)
            {
                _objSimpleLog = new SimpleLog();
                _blCreated = true;
                return _objSimpleLog;
            }
            return _objSimpleLog;
        }

        /// <summary>
        /// Registra una entrada en el log de Presentacion
        /// </summary>
        /// <returns></returns>
        public void GuardarLog(Exception ex, string nameSpace, string clase, string metodo, string filePath)
        {
            string mensaje = armarMensajeExcepcion(ex);
            //string filePath = ConfigurationManager.AppSettings["WebLogFilePath"];

            if (!string.IsNullOrEmpty(filePath))
            {
                //Preparar el mensaje
                var strBuider = new StringBuilder();
                strBuider.Append("FECHA: ");
                strBuider.Append(DateTime.Now.ToShortDateString() + " : " + DateTime.Now.ToShortTimeString() + ", " + Environment.NewLine);
                strBuider.Append("NIVEL EN DEPLOY: " + nameSpace + ". " + Environment.NewLine);
                strBuider.Append("CLASE GENERADORA: " + clase + ". " + Environment.NewLine);
                strBuider.Append("METODO: " + metodo + ". " + Environment.NewLine);
                strBuider.Append("Excepcion completa: " + Environment.NewLine + mensaje + Environment.NewLine);
                strBuider.Append("-------------------------------------------------------------------- " + Environment.NewLine + Environment.NewLine);

                loguear(strBuider.ToString(), filePath);
            }
        }

        private string armarMensajeExcepcion(Exception ex)
        {
            StringBuilder mensaje = new StringBuilder();

            mensaje.AppendLine("------------------");

            while (ex != null)
            {
                mensaje.AppendLine("Excepción: " + ex.Message);
                mensaje.AppendLine("StackTrace: " + ex.StackTrace);
                ex = ex.InnerException;
            }

            mensaje.AppendLine("------------------");

            return mensaje.ToString();

        }

        private void loguear(string mensaje, string filePath)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(filePath, true, Encoding.UTF8);
                sw.WriteLine(mensaje);
                sw.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                if (sw != null) sw.Dispose();
            }
        }

    }
}
