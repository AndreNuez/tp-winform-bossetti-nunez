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

namespace Ventana
{
    public partial class frmDetalle : Form
    {
        Articulo detalle = new Articulo();

        public frmDetalle(Articulo detalle)
        {
            InitializeComponent();
            this.detalle = detalle;
            Text = "Detalle Artículo";
        }

        private void frmDetalle_Load(object sender, EventArgs e)
        {
            txtDetCodigo.Text = detalle.Codigo;
            txtDetCodigo.Enabled = false;
            txtDetNombre.Text = detalle.Nombre;
            txtDetNombre.Enabled = false;
            txtDetDescripcion.Text = detalle.Descripcion;
            txtDetDescripcion.Enabled = false;
            txtDetMarca.Text = detalle.Marca.ToString();
            txtDetMarca.Enabled = false;
            txtDetCategoria.Text = detalle.Categoria.ToString();
            txtDetCategoria.Enabled = false;
            txtDetPrecio.Text = detalle.Precio.ToString();
            txtDetPrecio.Enabled = false;
            txtDetImagen.Text = detalle.ImagenURL.ToString();
            txtDetImagen.Enabled = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
