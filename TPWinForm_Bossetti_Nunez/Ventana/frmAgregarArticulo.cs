using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
using Negocio;

namespace Ventana
{
    public partial class frmAgregarArticulo : Form
    {
        public frmAgregarArticulo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Marca = (Marca)cboMarca.SelectedItem;
                //nuevo.Categoria = (Categoria)cboCategoria.SelectedItem;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                negocio.Agregar(nuevo);
                MessageBox.Show("Articulo agregado correctamente.");
                Close();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void frmAgregarArticulo_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            try
            {
                cboMarca.DataSource = articuloNegocio.listar();
                //cboCategoria.DataSource = articuloNegocio.listar();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
