using DataAccess;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ProveedorService
    {
        public static List<Proveedor> getAll()
        {
            try
            {
                return ProveedorDataAccess.getAll();
            }
            catch (Exception)
            {
                return new List<Proveedor>();
            }
        }

        public static Proveedor getById(int id_proveedor)
        {
            try
            {
                return ProveedorDataAccess.getById(id_proveedor);
            }
            catch (Exception)
            {
                return new Proveedor();
            }
        }
    }
}
