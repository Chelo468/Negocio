using DataAccess;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ClienteService
    {
        public static Cliente getById(int id_cliente)
        {
            Cliente cliente = new Cliente();
            try
            {
                if (id_cliente > 0)
                {
                    cliente = ClienteDataAccess.getById(id_cliente);
                }
            }
            catch (Exception ex)
            {
                return new Cliente();
            }

            return cliente;
        }
    }
}
