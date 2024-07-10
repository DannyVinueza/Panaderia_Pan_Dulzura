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
    public class NotificacionesLogica
    {
        private NotificacionesDAO notificacionesDAO;

        public NotificacionesLogica()
        { 
            notificacionesDAO = new NotificacionesDAO();
        }

        public bool InsertarNotificaciones(Notificaciones nuevaNotificacion)
        {
            try
            {
                notificacionesDAO.InsertarNotificacion(nuevaNotificacion);
                return true;
            }
            catch (Exception ex)
            { 
                throw new Exception("Error: " + ex.Message);
            }
        }

        public DataTable ListarNotificaciones()
        {
            try
            {
                return notificacionesDAO.ListarNotificaciones();
            }
            catch (Exception ex)
            { 
                throw new Exception ("Error: " + ex.Message);
            }
        }
    }
}
