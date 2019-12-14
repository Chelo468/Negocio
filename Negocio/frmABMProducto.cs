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
    public partial class frmABMProducto : Form
    {
        public frmABMProducto()
        {
            InitializeComponent();
        }

        private void frmABMProducto_Load(object sender, EventArgs e)
        {
            List<Proveedor> proveedores = ProveedorService.getAll();

            cboProveedor.DataSource = proveedores;
            cboProveedor.ValueMember = "id_proveedor";
            cboProveedor.DisplayMember = "descripcion";
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if(validarFormulario())
            {
                decimal precio_compra;
                decimal precio_venta;
                if(!decimal.TryParse(txtPrecioCompra.Text, out precio_compra))
                {
                    MessageBox.Show("Verifique el precio de compra");
                    txtPrecioCompra.Focus();
                    return;
                }

                if (!decimal.TryParse(txtPrecioVenta.Text, out precio_venta))
                {
                    MessageBox.Show("Verifique el precio de venta");
                    txtPrecioVenta.Focus();
                    return;
                }

                Producto producto = new Producto();

                producto.nombre = txtNombreProd.Text;
                producto.observacion = txtObservacionProd.Text;
                producto.precio_compra = precio_compra;
                producto.precio_venta = precio_venta;

                ProductoService.crear(ref producto);

                if(producto != null && producto.id_producto > 0)
                {
                    Proveedor proveedor = ProveedorService.getById(int.Parse(cboProveedor.SelectedValue.ToString()));
                                        
                    ProductoService.asignarProveedor(producto, proveedor);
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos");
            }
        }

        private bool validarFormulario()
        {
            if(string.IsNullOrEmpty(txtNombreProd.Text) || string.IsNullOrEmpty(txtObservacionProd.Text) || string.IsNullOrEmpty(txtPrecioCompra.Text) || string.IsNullOrEmpty(txtPrecioVenta.Text))
            {
                return false;
            }

            if (string.IsNullOrEmpty(cboProveedor.SelectedText))
                return false;

            return true;
        }
    }
}
