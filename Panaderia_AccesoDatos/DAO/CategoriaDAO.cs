using Panaderia_AccesoDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia_AccesoDatos.DAO
{
    public class CategoriaDAO
    {
        private ConexionBD conexion = new ConexionBD();
        SqlCommand ejecutarSql = new SqlCommand();
        SqlDataReader transaccion;

        // Listar categorías sin usar SP
        public DataTable ListarCategoriasSinSP()
        {
            DataTable dt = new DataTable();
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "SELECT ID_categoria, Nombre FROM Categorias";
                transaccion = ejecutarSql.ExecuteReader();
                dt.Load(transaccion);
                conexion.CerrarConexion();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar categorías: " + ex.Message);
            }
        }

        // Listar categorías utilizando procedimiento almacenado
        public DataTable ListarCategorias()
        {
            DataTable dt = new DataTable();
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "pr_ListarCategorias";
                ejecutarSql.CommandType = CommandType.StoredProcedure;
                transaccion = ejecutarSql.ExecuteReader();
                dt.Load(transaccion);
                conexion.CerrarConexion();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar categorías: " + ex.Message);
            }
        }

        public List<Categoria> ListarCategoriasList()
        {
            try
            {
                DataTable dt = ListarCategorias();
                List<Categoria> categorias = new List<Categoria>();

                foreach (DataRow row in dt.Rows)
                {
                    Categoria categoria = new Categoria
                    {
                        ID_categoria = Convert.ToInt32(row["ID_categoria"]),
                        Nombre = row["Nombre"].ToString()
                        // Asigna otras propiedades si es necesario
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

        // Insertar categoría sin usar SP
        public void InsertarCategoriaSinSP(Categoria nuevaCategoria)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "INSERT INTO Categorias (Nombre) VALUES (@Nombre)";
                ejecutarSql.Parameters.AddWithValue("@Nombre", nuevaCategoria.Nombre);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar categoría: " + ex.Message);
            }
        }


        // Insertar categoría utilizando procedimiento almacenado
        public void InsertarCategoria(Categoria nuevaCategoria)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "pr_InsertarCategoria";
                ejecutarSql.CommandType = CommandType.StoredProcedure;
                ejecutarSql.Parameters.AddWithValue("@Nombre", nuevaCategoria.Nombre);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar categoría: " + ex.Message);
            }
        }

        // Modificar categoría sin usar SP
        public void ModificarCategoriaConSP(Categoria categoriaModificada)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "pr_ActualizarCategoria";
                ejecutarSql.CommandType = CommandType.StoredProcedure;
                ejecutarSql.Parameters.AddWithValue("@ID_categoria", categoriaModificada.ID_categoria);
                ejecutarSql.Parameters.AddWithValue("@Nombre", categoriaModificada.Nombre);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar categoría: " + ex.Message);
            }
        }

        // Eliminar categoría sin usar SP
        public void EliminarCategoriaSinSP(int ID_categoria)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "DELETE FROM Categorias WHERE ID_categoria = @ID_categoria";
                ejecutarSql.CommandType = CommandType.Text;
                ejecutarSql.Parameters.AddWithValue("@ID_categoria", ID_categoria);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar categoría: " + ex.Message);
            }
        }

       

    }
}
