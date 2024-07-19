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
    public class DetallePedidoLogica
    {
        private Detalle_PedidoDAO Detalle_PedidoDAO;

        public DetallePedidoLogica()
        {
            Detalle_PedidoDAO = new Detalle_PedidoDAO();

        }
        public bool InsertarDetallePedido(Detalle_Pedido nuevoDetallePedido)
        {
            try
            {
                Detalle_PedidoDAO.InsertarDetallePedido(nuevoDetallePedido);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);

            }

        }
        public DataTable ListarDetallePedido()
        {
            try
            {
                return Detalle_PedidoDAO.ListarDetallePedidos();

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);

            }

        }
        //Actualizar usuario con PR
        public void ActualizarDetallePedido(Detalle_Pedido detalle_Pedido)
        {
            try
            {
                Detalle_PedidoDAO.ActualizarDetallePedido_PR(detalle_Pedido);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar detalle Pedido:" + ex.Message);
            }
        }
        //Eliminar uaurio con PR
        public void EliminarDetallePedido(int IdDetallePedido)
        {
            try
            {
                Detalle_PedidoDAO.EliminarDetallePedido_SP(IdDetallePedido);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar detalle pedido:" + ex.Message);
            }
        }
    }
}
