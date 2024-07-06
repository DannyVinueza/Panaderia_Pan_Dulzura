using Panaderia_AccesoDatos.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Panaderia_AccesoDatos.DAO
{
    public class NotificacionesDAO
    {
        private ConexionBD conexion = new ConexionBD();

        // Listar notificaciones sin usar SP
        public DataTable ListarNotificacionesSinSP()
        {
            DataTable dt = new DataTable();
            SqlCommand ejecutarSql = new SqlCommand();
            SqlDataReader transaccion = null;

            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "SELECT ID_notificacion, ID_pedido, Tipo, Fecha_Notificacion FROM Notificaciones";
                transaccion = ejecutarSql.ExecuteReader();
                dt.Load(transaccion);
                conexion.CerrarConexion();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar Notificacion: " + ex.Message);
            }
            finally
            {
                if (transaccion != null)
                {
                    transaccion.Close();
                }
                conexion.CerrarConexion();
            }
        }

        // Listar notificaciones utilizando procedimiento almacenado
        public DataTable ListarNotificaciones()
        {
            DataTable dt = new DataTable();
            SqlCommand ejecutarSql = new SqlCommand();
            SqlDataReader transaccion = null;

            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "pr_ListarNotificaciones";
                ejecutarSql.CommandType = CommandType.StoredProcedure;
                transaccion = ejecutarSql.ExecuteReader();
                dt.Load(transaccion);
                conexion.CerrarConexion();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar Notificacion: " + ex.Message);
            }
            finally
            {
                if (transaccion != null)
                {
                    transaccion.Close();
                }
                conexion.CerrarConexion();
            }
        }

        // Insertar notificación utilizando procedimiento almacenado
        public void InsertarNotificacion(Notificaciones nuevaNotificacion)
        {
            SqlCommand ejecutarSql = new SqlCommand();

            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "pr_InsertarNotificacion";
                ejecutarSql.CommandType = CommandType.StoredProcedure;
                ejecutarSql.Parameters.AddWithValue("@ID_pedido", nuevaNotificacion.ID_pedido);
                ejecutarSql.Parameters.AddWithValue("@Tipo", nuevaNotificacion.Tipo);
                ejecutarSql.Parameters.AddWithValue("@Fecha_Notificacion", nuevaNotificacion.Fecha_Notificacion);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar notificación: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        // Insertar notificación sin usar SP
        public void InsertarNotificacionesSinSP(Notificaciones nuevaNotificacion)
        {
            SqlCommand ejecutarSql = new SqlCommand();

            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "INSERT INTO Notificaciones (ID_pedido, Tipo, Fecha_Notificacion) VALUES (@ID_pedido, @Tipo, @Fecha_Notificacion)";
                ejecutarSql.Parameters.AddWithValue("@ID_pedido", nuevaNotificacion.ID_pedido);
                ejecutarSql.Parameters.AddWithValue("@Tipo", nuevaNotificacion.Tipo);
                ejecutarSql.Parameters.AddWithValue("@Fecha_Notificacion", nuevaNotificacion.Fecha_Notificacion);
                ejecutarSql.ExecuteNonQuery();
                ejecutarSql.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar notificación: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
    }
}
