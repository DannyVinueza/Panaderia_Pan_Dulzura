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
    }
}
