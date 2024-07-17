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
    namespace Panaderia_LogicaNegocio
    {
        public class NotificacionesLogica
        {
            private NotificacionesDAO notificacionesDAO;

            public NotificacionesLogica()
            {
                notificacionesDAO = new NotificacionesDAO();
            }

            // Método para insertar una notificación utilizando SP
            public void InsertarNotificacion(Notificaciones nuevaNotificacion)
            {
                try
                {
                    notificacionesDAO.InsertarNotificacion(nuevaNotificacion);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar notificación: " + ex.Message);
                }
            }

            // Método para obtener(listar) todas las notificaciones utilizando SP
            public DataTable ListarNotificaciones()
            {
                try
                {
                    return notificacionesDAO.ListarNotificaciones();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener notificaciones: " + ex.Message);
                }
            }

            // Método para actualizar una notificación utilizando SP
            public void ActualizarNotificacion(Notificaciones notificacionActualizada)
            {
                try
                {
                    notificacionesDAO.ActualizarNotificaciones(notificacionActualizada);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar notificación: " + ex.Message);
                }
            }

            // Método para eliminar una notificación sin usar SP
            public void EliminarNotificacion(int idNotificacion)
            {
                try
                {
                    notificacionesDAO.EliminarNotificacionesSinSP(idNotificacion);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar notificación: " + ex.Message);
                }
            }
        }
    }
}