using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Modelo;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select a.Codigo, a.Nombre, a.Descripcion, b.Descripcion Marca_Descripcion, c.Descripcion Categoria_Desripcion, a.ImagenUrl, a.Precio From Articulos a Left Join Marcas b on a.IdMarca = b.Id Left Join Categorias c on a.IdCategoria = c.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca_Descripcion"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria_Descripcion"];
                    aux.URLImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (int)datos.Lector["Precio"];

                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
