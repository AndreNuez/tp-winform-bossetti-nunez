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
                datos.setearConsulta("Select a.Codigo, a.Nombre, a.Descripcion, b.Descripcion Marca_Descripcion, c.Descripcion Categoria_Descripcion, a.ImagenUrl, a.Precio From Articulos a Inner Join Marcas b on a.IdMarca = b.Id Inner Join Categorias c on a.IdCategoria = c.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca_Descripcion"];
                    aux.Categoria = new Categoria();

                    if (!(datos.Lector["Categoria_Descripcion"] is DBNull))
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria_Descripcion"];
                    
                    aux.ImagenURL = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

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


        public void Agregar (Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");

                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca.Descripcion);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Descripcion);
                //datos.setearParametro("@ImagenURL", nuevo.ImagenURL);
                datos.setearParametro("@Precio", nuevo.Precio);

                datos.ejecutarAccion();

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
