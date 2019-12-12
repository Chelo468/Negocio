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

            if(usuario != null && usuario.id_usuario > 0)
            {
                frmPrincipal principal = new frmPrincipal(usuario);

                this.Hide();

                principal.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos");
            }
            
        }
    }
}
