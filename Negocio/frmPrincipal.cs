using Entidades;
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
    public partial class frmPrincipal : Form
    {
        public Usuario usuario { get; set; }
        private frmPrincipal()
        {
            InitializeComponent();
        }

        public frmPrincipal(Usuario usuario)
        {
            if(usuario != null && usuario.id_usuario > 0)
            {
                this.usuario = usuario;

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
            mostrarForm(new frmVenta(this.usuario));
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
