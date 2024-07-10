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

        //Metodo para actualizar un producto
        public void ActualizarProducto(Producto producto)
        {
            //productoDAO.ac(producto);
        }

        //Metodo para eliminar un producto
        public void EliminarProducto(int id)
        {
            //productoDAO.EliminarProducto(id);
        }
    }
}
