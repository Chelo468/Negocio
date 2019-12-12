using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Configuracion
    {
        public static string daoFilePath = ConfigurationManager.AppSettings["daoFilePath"].ToString();
        public static string sqlConn = ConfigurationManager.AppSettings["sqlConn"].ToString();
    }
}
