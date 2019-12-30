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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtDescripcionProducto.Text))
            {
                List<Producto> productos = ProductoService.getAll();

                grdProductos.DataSource = productos;
            }
            else
            {
                List<Producto> productos = new List<Producto>();

                productos = ProductoService.getByNombre(txtDescripcionProducto.Text);

                grdProductos.DataSource = productos;
            }
        }
    }
}
