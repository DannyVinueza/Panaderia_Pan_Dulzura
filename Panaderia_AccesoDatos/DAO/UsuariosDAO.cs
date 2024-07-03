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
    public class UsuariosDAO
    {
        private ConexionBD conexion = new ConexionBD();// Abrir conexion a BD
        SqlCommand ejecutarSql = new SqlCommand();// Crear comandos SQL
        SqlDataReader transaccion;// Ejecutar consultas

        // Listar usuarios sin SP
        public DataTable ListarUsuario()
        {
            DataTable dt = new DataTable();
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "SELECT ID_usuario, Nombre, Direccion, Telefono, Correo_Electronico, Contrasena FROM Usuarios";
                transaccion = ejecutarSql.ExecuteReader();
                dt.Load(transaccion);
                conexion.CerrarConexion();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar a los usuarios: " + ex.Message);
            }
        }

        // Insertar usuario sin SP
        public void InsertarUsuario(Usuarios nuevoUsuario)
        {
            ejecutarSql.Connection = conexion.AbrirConexion();
            try
            {
                ejecutarSql.CommandText = "INSERT INTO Usuarios (Nombre, Direccion, Telefono, Correo_Electronico, Contrasena) VALUES ('" + nuevoUsuario.Nombre + "', '" + nuevoUsuario.Direccion + "', '" + nuevoUsuario.Telefono + "', '" + nuevoUsuario.Correo_Electronico + "', '" + nuevoUsuario.Contrasena + "')";
                ejecutarSql.ExecuteNonQuery();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar al usuario: " + ex.Message);
            }
        }

        // Listar usuarios con SP
        public DataTable ListarUsuario_PR()
        {
            DataTable dt = new DataTable();
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();

                ejecutarSql.CommandText = "pr_ListarUsuarios";
                ejecutarSql.CommandType = CommandType.StoredProcedure;
                transaccion = ejecutarSql.ExecuteReader();
                dt.Load(transaccion);
                conexion.CerrarConexion();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar a los usuarios utilizando el SP: " + ex.Message);
            }
        }

        // Insertar usuario con SP
        public void InsertarUsuario_PR(Usuarios nuevoUsuario)
        {
            try
            {
                ejecutarSql.Connection = conexion.AbrirConexion();
                ejecutarSql.CommandText = "pr_InsertarUsuario";
                ejecutarSql.CommandType = CommandType.StoredProcedure;
                ejecutarSql.Parameters.AddWithValue("@Nombre", nuevoUsuario.Nombre);
                ejecutarSql.Parameters.AddWithValue("@Direccion", nuevoUsuario.Direccion);
                ejecutarSql.Parameters.AddWithValue("@Telefono", nuevoUsuario.Telefono);
                ejecutarSql.Parameters.AddWithValue("@Correo_Electronico", nuevoUsuario.Correo_Electronico);
                ejecutarSql.Parameters.AddWithValue("@Contrasena", nuevoUsuario.Contrasena);
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
