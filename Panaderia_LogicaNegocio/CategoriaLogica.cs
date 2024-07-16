using Panaderia_AccesoDatos.DAO;
using Panaderia_AccesoDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia_LogicaNegocio
{
    public class CategoriaLogica
    {
        private CategoriaDAO categoriaDAO;

        public CategoriaLogica()
        {
            categoriaDAO = new CategoriaDAO();
        }

        //Metodo para insertar una categoria
        public bool InsertarCategoria(Categoria categoria)
        {
            try
            {
                categoriaDAO.InsertarCategoria(categoria);
                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error al insertar el producto: " + ex.Message);
                //return false;
                throw new Exception("Error" + ex.Message);
            }
        }

        //Metodo para obtener todas las categorias
        public DataTable ObtenerCategorias()
        {
            try
            {
                return categoriaDAO.ListarCategorias();
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }


        //Metodo para obtener todas las categorias
        public List<Categoria> ObtenerCategoriasList()
        {
            try
            {
                DataTable dt = categoriaDAO.ListarCategorias();
                List<Categoria> categorias = new List<Categoria>();

                Console.WriteLine("Cantidad de categorias: " + dt.Rows.Count);
                foreach (DataRow row in dt.Rows)
                {
                    Categoria categoria = new Categoria
                    {
                        ID_categoria = Convert.ToInt32(row["ID_categoria"]),
                        Nombre = row["ID_categoria"].ToString() + ' ' + row["Nombre"].ToString()
                       
                    };
                    categorias.Add(categoria);
                }

                return categorias;
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }

        //Metodo para insertar una categoria
        public bool insertarCategoria(Categoria categoria)
        {
            try
            {
                categoriaDAO.InsertarCategoria(categoria);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }

        //implementa actualizacion de categoria
        public void ActualizarCategoria(Categoria categoria)
        {
            try
            {
                categoriaDAO.ModificarCategoriaConSP(categoria);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar categoria: " + ex.Message);
            }
        }

        //Metodo para eliminar las categorias
        public void EliminarCategoria(int idCategoria)
        {
            try
            {
                categoriaDAO.EliminarCategoriaSinSP(idCategoria);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar categoria: " + ex.Message);
            }
        }
     

     
    }
}
