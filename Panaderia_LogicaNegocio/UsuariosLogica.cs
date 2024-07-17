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
    public class UsuariosLogica
    {
        private UsuariosDAO usuariosDAO;
        public UsuariosLogica()
        {
            usuariosDAO = new UsuariosDAO();
        }

        // Insertar usuario con SP
        public bool InsertarUsuario(Usuarios nuevoUsuario)
        {
            try
            {
                usuariosDAO.InsertarUsuario_PR(nuevoUsuario);
                return true;
            }
            catch (Exception ex) {
                throw new Exception("Error: " + ex.Message);
            }
        }

        // Listar los usuarios con PR
        public DataTable ListarUsuarios()
        {
            try
            {
                return usuariosDAO.ListarUsuario_PR();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Actualizar usuario con PR
        public void ActualizarUsuario(Usuarios usuario)
        {
            try
            {
                usuariosDAO.ActualizarUsuario_PR(usuario);
            }
            catch (Exception ex) {
                throw new Exception("Error al actualizar el usuario: " + ex.Message);
            }
        }

        // Eliminar usuario con PR
        public void EliminarUsuario(int IdUsuario)
        {
            try
            {
                usuariosDAO.EliminarUsuario_SP(IdUsuario);
            }
            catch (Exception ex) {
                throw new Exception("Error al eliminar al usuario: " + ex.Message);
            }
        }

        // Obtener todos los usuarios con formato
        public List<Usuarios> ObtenerUsuariosList()
        {
            try
            {
                DataTable dt = usuariosDAO.ListarUsuario_PR();
                List<Usuarios> users = new List<Usuarios>();

                foreach (DataRow row in dt.Rows)
                {
                    Usuarios usList = new Usuarios
                    {
                        ID_usuario = Convert.ToInt32(row["ID_usuario"]),
                        Nombre = row["ID_usuario"].ToString() + ' ' + row["Nombre"].ToString()
                    };
                    users.Add(usList);
                }
                return users;
            }
            catch (Exception ex) {
                throw new Exception("Error" + ex.Message);
            }
        }
    }
}
