using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Utils;

namespace Servicios
{
    public class UsuarioService
    {
        public static Usuario getByLogin(string nombre_usuario, string password)
        {
            Usuario usuario = new Usuario();
            try
            {
                if(!string.IsNullOrEmpty(nombre_usuario) && !string.IsNullOrEmpty(password))
                {
                    password = MD5Utilities.GetSHA1(password);

                    usuario = UsuarioDataAccess.getByLogin(nombre_usuario, password);
                }
            }
            catch(Exception ex)
            {
                return new Usuario();
            }

            return usuario;
        }
    }
}
