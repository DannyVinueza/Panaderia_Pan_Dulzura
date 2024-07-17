using Panaderia_AccesoDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia_AccesoDatos.DAO
{
    public class PedidosDAO
    {
        private ConexionBD conexion = new ConexionBD();// Abrir conexion a BD
        SqlCommand ejecutarSql = new SqlCommand();// Crear comandos SQL
        SqlDataReader transaccion;// Ejecutar consultas

        public DataTable ListarPedidos()
        {
            DataTable dt = new DataTable();
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "SELECT ID_pedido, ID_usuario, Fecha_Pedido, Fecha_Entrega, Estado FROM Pedidos";
                transaccion = ejecutarSql.ExecuteReader();
                dt.Load(transaccion);
                conexion.CerrarConexion();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar a los pedidos: " + ex.Message);
            }
        }

        // Insertar pedido sin SP
        public void InsertarPedido(Pedidos nuevoPedido)
        {
            ejecutarSql.Connection = conexion.AbrirConexion();
            try
            {
                ejecutarSql.CommandText = "INSERT INTO Pedidos (ID_usuario, Fecha_Pedido, Fecha_Entrega, Estado) VALUES ('" + nuevoPedido.ID_usuario + "', '" + nuevoPedido.Fecha_Pedido + "', '" + nuevoPedido.Fecha_Entrega + "', '" + nuevoPedido.Estado + "');";
                ejecutarSql.ExecuteNonQuery();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar un pedido: " + ex.Message);
            }
        }

        // Listar pedidos con SP
        public DataTable ListarPedido_PR()
        {
            DataTable dt = new DataTable();
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "pr_ListarPedidos";
                ejecutarSql.CommandType = CommandType.StoredProcedure;
                transaccion = ejecutarSql.ExecuteReader();
                dt.Load(transaccion);
                conexion.CerrarConexion();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar a los pedidos utilizando el SP: " + ex.Message);
            }
        }

        // Insertar pedido con SP
        public void InsertarPedido_PR(Pedidos nuevoPedido)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();
                ejecutarSql.CommandText = "pr_InsertarPedido";
                ejecutarSql.CommandType = CommandType.StoredProcedure;
                ejecutarSql.Parameters.AddWithValue("@ID_usuario", nuevoPedido.ID_usuario);
                ejecutarSql.Parameters.AddWithValue("@Fecha_Pedido", nuevoPedido.Fecha_Pedido);
                ejecutarSql.Parameters.AddWithValue("@Fecha_Entrega", nuevoPedido.Fecha_Entrega);
                ejecutarSql.Parameters.AddWithValue("@Estado", nuevoPedido.Estado);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar al usuario utilizando SP: " + ex.Message);
            }
        }

        // Actualizar pedido sin SP
        public void ActualizarPedido(Pedidos actualizarPedido)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();
                ejecutarSql.CommandText = "UPDATE Pedidos SET ID_usuario = @ID_usuario, Fecha_Pedido = @Fecha_Pedido, Fecha_Entrega = @Fecha_Entrega, Estado = @Estado WHERE ID_pedido = @ID_pedido";

                ejecutarSql.Parameters.AddWithValue("@ID_pedido", actualizarPedido.ID_pedido);
                ejecutarSql.Parameters.AddWithValue("@ID_usuario", actualizarPedido.ID_usuario);
                ejecutarSql.Parameters.AddWithValue("@Fecha_Pedido", actualizarPedido.Fecha_Pedido);
                ejecutarSql.Parameters.AddWithValue("@Fecha_Entrega", actualizarPedido.Fecha_Entrega);
                ejecutarSql.Parameters.AddWithValue("@Estado", actualizarPedido.Estado);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();

                conexion.CerrarConexion();
            }
            catch(Exception ex) {
                throw new Exception("Error al actualizar el pedido: " + ex.Message); 
            }
        }

        // Actualizar pedido con SP
        public void ActualizarPedido_PR(Pedidos actualizarPedido)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();
                ejecutarSql.CommandText = "pr_ActualizarPedido";
                ejecutarSql.CommandType = CommandType.StoredProcedure;

                ejecutarSql.Parameters.AddWithValue("@ID_pedido", actualizarPedido.ID_pedido);
                ejecutarSql.Parameters.AddWithValue("@ID_usuario", actualizarPedido.ID_usuario);
                ejecutarSql.Parameters.AddWithValue("@Fecha_Pedido", actualizarPedido.Fecha_Pedido);
                ejecutarSql.Parameters.AddWithValue("@Fecha_Entrega", actualizarPedido.Fecha_Entrega);
                ejecutarSql.Parameters.AddWithValue("@Estado", actualizarPedido.Estado);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();

                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el pedido: " + ex.Message);
            }
        }

        // Eliminar pedido sin SP
        public void EliminarPedido(int Id_Pedido)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();
                ejecutarSql.CommandText = "DELETE FROM Pedidos WHERE ID_pedido = @ID_pedido";

                ejecutarSql.Parameters.AddWithValue("@ID_pedido", Id_Pedido);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();

                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el pedido: " + ex.Message);
            }
        }

        // Eliminar pedido con SP
        public void EliminarPedido_PR(int Id_Pedido)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();
                ejecutarSql.CommandText = "pr_EliminarPedido";
                ejecutarSql.CommandType = CommandType.StoredProcedure;

                ejecutarSql.Parameters.AddWithValue("@ID_pedido", Id_Pedido);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();

                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el pedido: " + ex.Message);
            }
        }
    }
}
