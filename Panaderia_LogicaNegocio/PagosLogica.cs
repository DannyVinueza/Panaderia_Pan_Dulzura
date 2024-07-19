using Panaderia_AccesoDatos.DAO;
using Panaderia_AccesoDatos.Entidades;
using System;
using System.Data;

namespace Panaderia_LogicaNegocio
{
    public class PagosLogica
    {
        private PagosDAO PagosDAO;
        public PagosLogica()
        {
            PagosDAO = new PagosDAO();
        }

        //Metodo para insertar un pago

        public bool InsertarPago(Pagos nuevoPago)
        {
            try
            {
                PagosDAO.InsertarPago(nuevoPago);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);

            }
        }
        //Metodo para listar un pago
        public DataTable ListarPagos()
        {
            try
            {
                return PagosDAO.ListarPagos();

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);



            }

        }
        // Actualizar pago con SP
        public void ActualizarPago(Pagos pago)
        {
            try
            {
                PagosDAO.ActualizarPago_PR(pago);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el pago: " + ex.Message);
            }
        }

        // Eliminar el pago con SP
        public void EliminarPago(int IdPago)
        {
            try
            {
                PagosDAO.EliminarPago_PR(IdPago);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el pago: " + ex.Message);
            }
        }
    }
}