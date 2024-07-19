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
    public class Detalle_PedidoDAO
    {
        private ConexionBD conexion = new ConexionBD();// Abrir conexion a BD
        SqlCommand ejecutarSql = new SqlCommand();// Crear comandos SQL
        SqlDataReader transaccion;// Ejecutar consultas
        //Listar Detalle sin SP
        public DataTable ListarDetallePedidos()
        {
            DataTable dt = new DataTable();
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();
                ejecutarSql.CommandText = "SELECT ID_detalle, ID_pedido,ID_producto, Cantidad, Precio FROM Detalle_Pedido";
                transaccion = ejecutarSql.ExecuteReader();
                dt.Load(transaccion);
                conexion.CerrarConexion();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar a los detalles del pedido: " + ex.Message);
            }

        }
        //Insertar Detalle sin SP
        public void InsertarDetallePedido(Detalle_Pedido nuevoDetallePedido)
        {
            ejecutarSql.Connection = conexion.AbrirConexion();
            try
            {
                ejecutarSql.CommandText = "INSERT INTO Detalle_Pedido (ID_pedido, ID_producto, Cantidad, Precio) VALUES (" + nuevoDetallePedido.ID_pedido + ", " + nuevoDetallePedido.ID_producto + ", " + nuevoDetallePedido.Cantidad + ", " + nuevoDetallePedido.Precio + ");";
                ejecutarSql.ExecuteNonQuery();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar detalle del pedido:" + ex.Message);
            }

        }
        //Listar Detalle Pedido con SP
        public DataTable ListarDetallePedido_PR()
        {
            DataTable dt = new DataTable();
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();
                ejecutarSql.CommandText = "pr_ListarDetallePedido";
                ejecutarSql.CommandType = CommandType.StoredProcedure;
                transaccion = ejecutarSql.ExecuteReader();
                dt.Load(transaccion);
                conexion.CerrarConexion();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar el detalle de pedido:" + ex.Message);
            }
        }
        //Insertar Detalle Pedido con SP
        public void InsertarDetallePedido_PR(Detalle_Pedido nuevoDetallePedido)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();
                ejecutarSql.CommandText = "pr_InsertarDetallePedido";
                ejecutarSql.CommandType = CommandType.StoredProcedure;
                ejecutarSql.Parameters.AddWithValue("@ID_pedido", nuevoDetallePedido.ID_pedido);
                ejecutarSql.Parameters.AddWithValue("@ID_producto", nuevoDetallePedido.ID_producto);
                ejecutarSql.Parameters.AddWithValue("@Cantidad", nuevoDetallePedido.Cantidad);
                ejecutarSql.Parameters.AddWithValue("@Precio", nuevoDetallePedido.Precio);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el detalle pedido usando SP:" + ex.Message);
            }
        }
        //Actualizar Detalle sin SP
        public void ActualizarDetallePedido(Detalle_Pedido actualizarDetallePedido)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();
                ejecutarSql.CommandText = "UPDATE Detalle_Pedido SET ID_pedido = @ID_pedido, ID_producto = @ID_producto, Cantidad = @Cantidad, Precio = @Precio  WHERE ID_detalle = @ID_detalle";

                ejecutarSql.Parameters.AddWithValue("@ID_detalle", actualizarDetallePedido.ID_detalle);
                ejecutarSql.Parameters.AddWithValue("@ID_pedido", actualizarDetallePedido.ID_pedido);
                ejecutarSql.Parameters.AddWithValue("@ID_producto", actualizarDetallePedido.ID_producto);
                ejecutarSql.Parameters.AddWithValue("@Cantidad", actualizarDetallePedido.Cantidad);
                ejecutarSql.Parameters.AddWithValue("@Precio", actualizarDetallePedido.Precio);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();

                conexion.CerrarConexion();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el detalle:" + ex.Message);
            }
        }

        //Actualizar el Detalle Pedido con SP
        public void ActualizarDetallePedido_PR(Detalle_Pedido actualizarDetallePedido)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();
                ejecutarSql.CommandText = "pr_ActualizarDetallePedido";
                ejecutarSql.CommandType = CommandType.StoredProcedure;

                ejecutarSql.Parameters.AddWithValue("@ID_detalle", actualizarDetallePedido.ID_detalle);
                ejecutarSql.Parameters.AddWithValue("@ID_pedido", actualizarDetallePedido.ID_pedido);
                ejecutarSql.Parameters.AddWithValue("@ID_producto", actualizarDetallePedido.ID_producto);
                ejecutarSql.Parameters.AddWithValue("@Cantidad", actualizarDetallePedido.Cantidad);
                ejecutarSql.Parameters.AddWithValue("@Precio", actualizarDetallePedido.Precio);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();

                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el detalle:" + ex.Message);
            }
        }

        //Eliminar Detalle Pedido sin SP
        public void EliminarDetallePedido(int ID_detalle)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();
                ejecutarSql.CommandText = "DELETE FROM Detalle_Pedido WHERE ID_detalle = @ID_detalle";

                ejecutarSql.Parameters.AddWithValue("@ID_detalle", ID_detalle);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();

                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar al usuario: " + ex.Message);
            }
        }

        //Eliminar Detalle Pedido con SP
        public void EliminarDetallePedido_SP(int ID_detalle)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();
                ejecutarSql.CommandText = "pr_EliminarDetallePedido";
                ejecutarSql.CommandType = CommandType.StoredProcedure;

                ejecutarSql.Parameters.AddWithValue("@ID_detalle", ID_detalle);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();

                conexion.CerrarConexion();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar al usuario: " + ex.Message);
            }
        }

    }
}
