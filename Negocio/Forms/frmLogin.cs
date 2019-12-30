using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace Negocio
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario = UsuarioService.getByLogin(txtUsuario.Text, txtPassword.Text);

            if(usuario != null && usuario.id_usuarios > 0)
            {
                if(usuario.habilitado)
                {
                    if(!usuario.administrador)
                    {
                        SesionService.setUsuario(usuario);
                        frmPrincipal principal = new frmPrincipal();

                        this.Hide();

                        principal.ShowDialog();

                        this.Close();
                    }
                    else
                    {
                        //TODO: Hacer logica de administrador
                    }
                }
                else
                {
                    MessageBox.Show("Su usuario está deshabilitado. Comuniquese con el administrador");
                }
                
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos");
            }
            
        }
    }
}
