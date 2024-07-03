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

        // Insertar usuario sin SP
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

        // Listar usuarios con SP
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

        // Insertar usuario con SP
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
    }
}
