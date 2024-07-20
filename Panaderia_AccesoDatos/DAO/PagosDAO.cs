using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panaderia_AccesoDatos.Entidades;
using System.Threading;

namespace Panaderia_AccesoDatos.DAO
{
    public class PagosDAO
    {
        private ConexionBD conexion = new ConexionBD();// Abrir conexion a BD
        SqlCommand ejecutarSql = new SqlCommand();// Crear comandos SQL
        SqlDataReader transaccion;// Ejecutar consultas

        public DataTable ListarPagos()
        {
            DataTable dt = new DataTable();
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "SELECT ID_pago,ID_pedido, Monto, Fecha_Pago, Metodo_Pago FROM Pagos";

                transaccion = ejecutarSql.ExecuteReader();
                dt.Load(transaccion);
                conexion.CerrarConexion();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar a los pagos: " + ex.Message);
            }
        }
        // Insertar Pago sin SP
        public void InsertarPago(Pagos nuevoPago)
        {
            ejecutarSql.Connection = conexion.AbrirConexion();
            try
            {
                ejecutarSql.CommandText = "INSERT INTO Pagos (ID_pedido, Monto, Fecha_Pago, Metodo_Pago) VALUES ('" + nuevoPago.ID_pedido + "', '" + nuevoPago.Monto + "', '" + nuevoPago.Fecha_Pago + "', '" + nuevoPago.Metodo_Pago + "');";

                ejecutarSql.ExecuteNonQuery();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar un pago: " + ex.Message);
            }
        }
        // Listar pago con SP
        public DataTable ListarPago_PR()
        {
            DataTable dt = new DataTable();
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "pr_ListarPagos";
                ejecutarSql.CommandType = CommandType.StoredProcedure;
                transaccion = ejecutarSql.ExecuteReader();
                dt.Load(transaccion);
                conexion.CerrarConexion();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar el pago: " + ex.Message);
            }
        }
        // Insertar usuario con SP
        public void InsertarPago_PR(Pagos nuevoPago)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();
                ejecutarSql.CommandText = "pr_InsertarPago";
                ejecutarSql.CommandType = CommandType.StoredProcedure;
                ejecutarSql.Parameters.AddWithValue("@ID_pedido", nuevoPago.ID_pedido);
                ejecutarSql.Parameters.AddWithValue("@Monto", nuevoPago.Monto);
                ejecutarSql.Parameters.AddWithValue("@Fecha_Pago", nuevoPago.Fecha_Pago);
                ejecutarSql.Parameters.AddWithValue("@Metodo_Pago", nuevoPago.Metodo_Pago);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar al insertar pago: " + ex.Message);
            }
        }
        // Actualizar pedido sin SP
        public void ActualizarPago(Pagos actualizarPago)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "UPDATE Pagos SET ID_pago = @ID_pago, ID_pedido = @ID_pedido, Monto = @Monto, Fecha_pago = @Fecha_pago WHERE Metodo_Pago = @Metodo_Pago";
                ejecutarSql.Parameters.AddWithValue("@ID_pago", actualizarPago.ID_pago);
                ejecutarSql.Parameters.AddWithValue("@ID_pedido", actualizarPago.ID_pedido);
                ejecutarSql.Parameters.AddWithValue("@Monto", actualizarPago.Monto);
                ejecutarSql.Parameters.AddWithValue("@Fecha_pago", actualizarPago.Fecha_Pago);
                ejecutarSql.Parameters.AddWithValue("@Metodo_pago", actualizarPago.Metodo_Pago);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el pago: " + ex.Message);
            }
        }

        // Actualizar pago con SP
        public void ActualizarPago_PR(Pagos actualizarPago)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();
                ejecutarSql.CommandText = "pr_ActualizarPago";
                ejecutarSql.CommandType = CommandType.StoredProcedure;

                ejecutarSql.Parameters.AddWithValue("@ID_pago", actualizarPago.ID_pago);
                ejecutarSql.Parameters.AddWithValue("@ID_pedido", actualizarPago.ID_pedido);
                ejecutarSql.Parameters.AddWithValue("@Fecha_Pago", actualizarPago.Fecha_Pago);
                ejecutarSql.Parameters.AddWithValue("@Metodo_pago", actualizarPago.Metodo_Pago);
                ejecutarSql.Parameters.AddWithValue("@Monto", actualizarPago.Monto);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();

                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el pago: " + ex.Message);
            }
        }
        // Eliminar pago sin SP
        public void EliminarPago(int Id_Pago)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();
                ejecutarSql.CommandText = "DELETE FROM Pagos WHERE ID_pago = @ID_pago";
                ejecutarSql.Parameters.AddWithValue("@ID_pago", Id_Pago);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();

                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el pago: " + ex.Message);
            }
        }
        // Eliminar pago con SP
        public void EliminarPago_PR(int Id_Pago)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();
                ejecutarSql.CommandText = "pr_EliminarPago";
                ejecutarSql.CommandType = CommandType.StoredProcedure;

                ejecutarSql.Parameters.AddWithValue("@ID_pago", Id_Pago);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();

                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el pago: " + ex.Message);
            }
        }
    }
}
