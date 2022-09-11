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
    public partial class frmGestion : Form
    {
        private List<Articulo> listaArticulo;
        public frmGestion()
        {
            InitializeComponent();
        }

        private void frmGestion_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                ArticuloNegocio negocioArticulo = new ArticuloNegocio();
                listaArticulo = negocioArticulo.listar();
                dgvArticulos.DataSource = listaArticulo;
                dgvArticulos.Columns["ImagenUrl"].Visible = false;
                cargaImagen(listaArticulo[0].ImagenURL);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void frmGestion_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Gracias por usar nuestra aplicación.");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarArticulo agregar = new frmAgregarArticulo();
            agregar.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            cargaImagen(seleccionado.ImagenURL);
        }

        private void cargaImagen(string imagen)
        {

            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxArticulo.Load("https://media.istockphoto.com/vectors/thumbnail-image-vector-graphic-vector-id1147544807?k=20&m=1147544807&s=612x612&w=0&h=pBhz1dkwsCMq37Udtp9sfxbjaMl27JUapoyYpQm0anc=");
            }
        }
    }
}
