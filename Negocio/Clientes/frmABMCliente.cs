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
    public partial class frmABMCliente : Form
    {
        //public frmABMCliente()
        //{
        //    InitializeComponent();
        //}

        private Cliente cliente;
        private Usuario usuario;

        public frmABMCliente(Cliente cliente, Usuario usuario)
        {
            this.cliente = cliente;
            this.usuario = usuario;
            InitializeComponent();
        }

        private void frmABMCliente_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(validarFormulario())
            {
                cliente.descripcion = txtDescripcion.Text;
                cliente.mail = txtMail.Text;
                cliente.telefono = txtTelefono.Text;
                cliente.usuario_alta = usuario;

                try
                {
                    ClienteService.crear(ref cliente);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                

                this.Close();
            }
            else
            {
                MessageBox.Show("Complete todos los campos");
            }
        }

        private bool validarFormulario()
        {
            if(string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(txtMail.Text) || string.IsNullOrEmpty(txtTelefono.Text))
            {
                return false;
            }

            return true;
        }
    }
}
