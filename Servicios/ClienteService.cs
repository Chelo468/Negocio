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

                    if (cliente == null)
                        cliente = new Cliente();
                }
            }
            catch (Exception ex)
            {
                return new Cliente();
            }

            return cliente;
        }

        public static bool crear(ref Cliente cliente)
        {
            try
            {
                Cliente clienteExistente = ClienteDataAccess.getExistente(cliente);

                if(clienteExistente != null && clienteExistente.id_cliente > 0)
                {
                    cliente = clienteExistente;
                    return false;
                }
                else
                {
                    cliente.fecha_alta = DateTime.Now;
                    ClienteDataAccess.crear(ref cliente);
                    return true;
                }

                
               
            }
            catch (Exception ex)
            {
                throw new Exception("El usuario ya existe");
            }
        }
    }
}
