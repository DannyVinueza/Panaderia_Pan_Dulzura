using Panaderia_AccesoDatos.DAO;
using Panaderia_AccesoDatos.Entidades;
using System;
using System.Data;

namespace Panaderia_LogicaNegocio
{
    public class PedidosLogica
    {
        private PedidosDAO pedidosDAO;
        public PedidosLogica() { 
            pedidosDAO = new PedidosDAO();
        }

        // Insertar pedido con SP
        public bool InsertarPedido(Pedidos nuevoPedido)
        {
            try
            {
                pedidosDAO.InsertarPedido_PR(nuevoPedido);
                return true;
            }
            catch (Exception ex) {
                throw new Exception("Error: " + ex.Message);
            }
        }

        // Listar pedidos con SP
        public DataTable ListarPedidos()
        {
            try
            {
                return pedidosDAO.ListarPedido_PR();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        // Actualizar pedido con SP
        public void ActualizarPedido(Pedidos pedido)
        {
            try
            {
                pedidosDAO.ActualizarPedido_PR(pedido);
            }
            catch (Exception ex) {
                throw new Exception("Error al actualizar el pedido: " + ex.Message);
            }
        }

        // Eliminar el pedido con SP
        public void EliminarPedido(int IdPedido)
        {
            try
            {
                pedidosDAO.EliminarPedido_PR(IdPedido);
            }
            catch (Exception ex) {
                throw new Exception("Error al eliminar el pedido: " + ex.Message);
            }  
        }
    }
}
