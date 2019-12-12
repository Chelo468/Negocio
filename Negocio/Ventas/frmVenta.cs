using Entidades;
using iTextSharp.text.pdf;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public partial class frmVenta : Form
    {
        private Usuario usuario;
        //public frmVenta()
        //{
        //    InitializeComponent();
        //}

        public frmVenta(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            //PDFUtilitiesDLL.PDFUtilities pdfU = new PDFUtilitiesDLL.PDFUtilities();

            //string dato = pdfU.ConvertByteToPdfText(File.ReadAllBytes(@"C:\Users\mbrizuela.ENCODE-SIST-06\Desktop\Salida\ACertificanteFD\Nota_Adicional(1).pdf"));

            //txtCliente.Text = dato;
            int id_cliente = 0;
            string textoCliente = txtCodigoCliente.Text;

            if(!string.IsNullOrEmpty(textoCliente))
            {
                if (int.TryParse(textoCliente, out id_cliente))
                {
                    Cliente cliente = new Cliente();

                    if (id_cliente > 0)
                    {
                        cliente = ClienteService.getById(id_cliente);

                        if (cliente.id_cliente > 0)
                        {

                        }
                    }
                }
            }
            else
            {
                Cliente cliente = new Cliente();
                new frmABMCliente(cliente);

                txtCliente.Text = cliente.descripcion;
            }
        }
    }
}
