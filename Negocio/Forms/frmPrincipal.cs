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
    public partial class frmPrincipal : Form
    {

        public frmPrincipal()
        {
            if (SesionService.getUsuario() != null && SesionService.getUsuario().id_usuarios > 0)
            {
                InitializeComponent();
            }
            else
            {
                MessageBox.Show("Debe iniciar sesión.");
                this.Close();
            }            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mostrarForm(new frmVenta());
        }

        private void mostrarForm(Form formAMostrar)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            formAMostrar.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            formAMostrar.StartPosition = FormStartPosition.CenterScreen;
            formAMostrar.MinimumSize = formAMostrar.Size;
            formAMostrar.MaximumSize = formAMostrar.Size;
            formAMostrar.ShowDialog();
            this.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
