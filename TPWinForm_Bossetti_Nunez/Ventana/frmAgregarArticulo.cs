using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using Modelo;
using Negocio;


namespace Ventana
{
    public partial class frmAgregarArticulo : Form
    {
        private Articulo articulo = null;
        private OpenFileDialog archivo = null;
        
        Helper aux = new Helper();

        public frmAgregarArticulo()
        {
            InitializeComponent();
        }

        public frmAgregarArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Artículo";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                if (validarFiltro())
                    return;

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.ImagenURL = txtImagenURL.Text;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.Precio = decimal.Parse(txtPrecio.Text);

                if (articulo.IDArticulo != 0)
                {
                    negocio.Modificar(articulo);
                    MessageBox.Show("Artículo modificado exitosamente.");
                }
                else
                {
                    negocio.Agregar(articulo);
                    MessageBox.Show("Artículo agregado exitosamente.");
                }

                if(archivo!=null && !(txtImagenURL.Text.ToUpper().Contains("HTTP")))
                {
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["ImagenesTP"] + archivo.SafeFileName);
                }
                
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAgregarArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                if(articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtImagenURL.Text = articulo.ImagenURL;
                    cargarImagen(articulo.ImagenURL);
                    txtPrecio.Text = articulo.Precio.ToString();

                    cboMarca.SelectedValue = articulo.Marca.ID;
                    cboCategoria.SelectedValue = articulo.Categoria.ID;
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtImagenURL.Text);
        }
        private void cargarImagen(string imagen)
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

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png";

            if (archivo.ShowDialog()== DialogResult.OK)
            {
                txtImagenURL.Text = archivo.FileName;
                cargarImagen(archivo.FileName);
            }
        }

        private bool validarFiltro()
        {
            if (cboMarca.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione una marca.");
                return true;
            }

            if (cboCategoria.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione una categoría.");
                return true;
            }

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Por favor, ingrese un valor para el Codigo.");
                return true;
            }

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese un valor para el Nombre.");
                return true;
            }

            if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("Por favor, ingrese un valor para el Precio.");
                return true;
            }

            if (!(aux.validarNumeros(txtPrecio.Text)))
            {
                MessageBox.Show("Para precio solo pueden ingresar valores numéricos.");
                return true;
            }

            return false;
        }
    }
}
