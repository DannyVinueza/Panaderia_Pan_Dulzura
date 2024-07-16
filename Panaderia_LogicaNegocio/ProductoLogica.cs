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
    public class ProductoLogica
    {
        private ProductoDAO productoDAO;


        public ProductoLogica()
        {
            productoDAO = new ProductoDAO();
        }

        //Metodo para insertar un producto
        public bool InsertarProducto(Producto producto)
        {
            try
            {
                productoDAO.InsertarProducto(producto);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error"+ ex.Message);                
            }
        }

        //Metodo para obtener todos los productos
        public DataTable ObtenerProductos()
        {
            try { 
            return productoDAO.ListarProductos();
            }
            catch(Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }


        }
        // Metodo para actulizar los productos
        public void ActualizarProducto(Producto producto)
        {
            try
            {
                productoDAO.ActualizarProducto(producto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar producto: " + ex.Message);
            }
        }

        // Metodo para eliminar los productos
        public void EliminarProducto(int idProducto)
        {
            try
            {
                productoDAO.EliminarProductoSinSP(idProducto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar producto: " + ex.Message);
            }
        }


    }
}
