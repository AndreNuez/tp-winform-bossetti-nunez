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
            txtDetNombre.Text = detalle.Nombre;
            txtDetDescripcion.Text = detalle.Descripcion;
            txtDetMarca.Text = detalle.Marca.ToString();
            txtDetCategoria.Text = detalle.Categoria.ID.ToString();
            txtDetPrecio.Text = detalle.Precio.ToString();
            txtDetImagen.Text = detalle.ImagenURL.ToString();

        }
    }
}
