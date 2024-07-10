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
    }
}
