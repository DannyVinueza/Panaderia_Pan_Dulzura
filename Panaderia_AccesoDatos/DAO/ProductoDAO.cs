﻿using Panaderia_AccesoDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia_AccesoDatos.DAO
{
    public class ProductoDAO
    {
        private ConexionBD conexion = new ConexionBD();
        SqlCommand ejecutarSql = new SqlCommand();
        SqlDataReader transaccion;

        // Listar productos sin usar SP
        public DataTable ListarProductosSinSP()
        {
            DataTable dt = new DataTable();
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "SELECT ID_producto, Nombre, ID_categoria, Descripcion, Ingredientes, Calorias FROM Productos";
                transaccion = ejecutarSql.ExecuteReader();
                dt.Load(transaccion);
                conexion.CerrarConexion();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar productos: " + ex.Message);
            }
        }


        // Listar productos utilizando procedimiento almacenado
        public DataTable ListarProductos()
        {
            DataTable dt = new DataTable();
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "pr_ListarProductos";
                ejecutarSql.CommandType = CommandType.StoredProcedure;
                transaccion = ejecutarSql.ExecuteReader();
                dt.Load(transaccion);
                conexion.CerrarConexion();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar productos: " + ex.Message);
            }
        }

        // Insertar producto utilizando procedimiento almacenado
        public void InsertarProducto(Producto nuevoProducto)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "pr_InsertarProducto";
                ejecutarSql.CommandType = CommandType.StoredProcedure;
                ejecutarSql.Parameters.AddWithValue("@Nombre", nuevoProducto.Nombre);
                ejecutarSql.Parameters.AddWithValue("@ID_categoria", nuevoProducto.ID_categoria);
                ejecutarSql.Parameters.AddWithValue("@Descripcion", nuevoProducto.Descripcion);
                ejecutarSql.Parameters.AddWithValue("@Ingredientes", nuevoProducto.Ingredientes);
                ejecutarSql.Parameters.AddWithValue("@Calorias", nuevoProducto.Calorias);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar producto: " + ex.Message);
            }
        }

        // Insertar producto sin usar SP
        public void InsertarProductoSinSP(Producto nuevoProducto)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "INSERT INTO Productos (Nombre, ID_categoria, Descripcion, Ingredientes, Calorias) VALUES (@Nombre, @ID_categoria, @Descripcion, @Ingredientes, @Calorias)";
                ejecutarSql.Parameters.AddWithValue("@Nombre", nuevoProducto.Nombre);
                ejecutarSql.Parameters.AddWithValue("@ID_categoria", nuevoProducto.ID_categoria);
                ejecutarSql.Parameters.AddWithValue("@Descripcion", nuevoProducto.Descripcion);
                ejecutarSql.Parameters.AddWithValue("@Ingredientes", nuevoProducto.Ingredientes);
                ejecutarSql.Parameters.AddWithValue("@Calorias", nuevoProducto.Calorias);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar producto: " + ex.Message);
            }
        }

        // Modificar producto sin usar SP
        public void ModificarProductoSinSP(Producto productoModificado)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "UPDATE Productos SET Nombre = @Nombre, ID_categoria = @ID_categoria, Descripcion = @Descripcion, Ingredientes = @Ingredientes, Calorias = @Calorias WHERE ID_producto = @ID_producto";
                ejecutarSql.Parameters.AddWithValue("@ID_producto", productoModificado.ID_producto);
                ejecutarSql.Parameters.AddWithValue("@Nombre", productoModificado.Nombre);
                ejecutarSql.Parameters.AddWithValue("@ID_categoria", productoModificado.ID_categoria);
                ejecutarSql.Parameters.AddWithValue("@Descripcion", productoModificado.Descripcion);
                ejecutarSql.Parameters.AddWithValue("@Ingredientes", productoModificado.Ingredientes);
                ejecutarSql.Parameters.AddWithValue("@Calorias", productoModificado.Calorias);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar producto: " + ex.Message);
            }
        }

        // Actualizar producto utilizando procedimiento almacenado
        public void ActualizarProducto(Producto productoActualizado)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();
                ejecutarSql.CommandText = "pr_ActualizarProducto";
                ejecutarSql.CommandType = CommandType.StoredProcedure;
                ejecutarSql.Parameters.AddWithValue("@ID_producto", productoActualizado.ID_producto);
                ejecutarSql.Parameters.AddWithValue("@Nombre", productoActualizado.Nombre);
                ejecutarSql.Parameters.AddWithValue("@ID_categoria", productoActualizado.ID_categoria);
                ejecutarSql.Parameters.AddWithValue("@Descripcion", productoActualizado.Descripcion);
                ejecutarSql.Parameters.AddWithValue("@Ingredientes", productoActualizado.Ingredientes);
                ejecutarSql.Parameters.AddWithValue("@Calorias", productoActualizado.Calorias);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar producto: " + ex.Message);
            }
        }

        // Eliminar producto sin usar SP
        public void EliminarProductoSinSP(int ID_producto)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();
                ejecutarSql.CommandText = "DELETE FROM Productos WHERE ID_producto = @ID_producto";
                ejecutarSql.CommandType = CommandType.Text;
                ejecutarSql.Parameters.AddWithValue("@ID_producto", ID_producto);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar producto: " + ex.Message);
            }
        }


    }
}