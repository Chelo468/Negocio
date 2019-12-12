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
    public partial class frmABMCliente : Form
    {
        //public frmABMCliente()
        //{
        //    InitializeComponent();
        //}

        private Cliente cliente;

        public frmABMCliente(Cliente cliente)
        {
            this.cliente = cliente;
            InitializeComponent();
        }

        private void frmABMCliente_Load(object sender, EventArgs e)
        {
            cliente.descripcion = "Hola mundo";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }
}
