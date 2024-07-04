using Panaderia_AccesoDatos.DAO;
using Panaderia_AccesoDatos.Entidades;
using System;
using System.Data;

namespace Prueba_AccesoDatos
{
    public class Program
    {
        static void Main(string[] args)
        {
            Usuarios user = new Usuarios();
            user.Nombre = "Danny";
            user.Direccion = "Av. Panamericana";
            user.Telefono = "593888888888";
            user.Correo_Electronico = "danny@gmail.com";
            user.Contrasena = "1234";

            var res = new UsuariosDAO();
            //res.InsertarUsuario(user);
            var respuesta = res.ListarUsuario();

            foreach (DataRow row in respuesta.Rows)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", row[0], row[1], row[2], row[3], row[4], row[5]);
            }

            Pedidos pedido = new Pedidos();
            pedido.ID_usuario = 1;
            pedido.Fecha_Pedido = DateTime.UtcNow.AddHours(-5);
            pedido.Fecha_Entrega = DateTime.UtcNow.AddHours(-5);
            pedido.Estado = "Entregado";

            var resPed = new PedidosDAO();
            //resPed.InsertarPedido_PR(pedido);
            var respuestaPedido = resPed.ListarPedido_PR();

            foreach (DataRow rowP in respuestaPedido.Rows)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", rowP[0], rowP[1], rowP[2], rowP[3], rowP[4]);
            }

            // Insertar categoría
            Categoria nuevaCategoria = new Categoria();
            //nuevaCategoria.Nombre = "Panes";
            nuevaCategoria.Nombre = "Roscas";

            CategoriaDAO categoriaDAO = new CategoriaDAO();
            //categoriaDAO.InsertarCategoriaSinSP(nuevaCategoria);
            //categoriaDAO.InsertarCategoria(nuevaCategoria);

            // Listar categorías
            Console.WriteLine("**Listado de categorías:**");
            DataTable categorias = categoriaDAO.ListarCategoriasSinSP();
            foreach (DataRow filaCategoria in categorias.Rows)
            {
                Console.WriteLine($"ID: {filaCategoria["ID_categoria"]} - Nombre: {filaCategoria["Nombre"]}");
            }

            // Insertar producto
            Producto nuevoProducto = new Producto();
            nuevoProducto.Nombre = "Pan de molde";
            nuevoProducto.ID_categoria = 1; // ID de la categoría insertada anteriormente
            nuevoProducto.Descripcion = "Pan de molde integral elaborado con harina de trigo integral, salvado de trigo y semillas de lino.";
            nuevoProducto.Ingredientes = "Harina de trigo integral, salvado de trigo, semillas de lino, levadura, agua, sal.";
            nuevoProducto.Calorias = 250;
            ProductoDAO productoDAO = new ProductoDAO();
            //productoDAO.InsertarProductoSinSP(nuevoProducto);

            // Listar productos
            Console.WriteLine("\n**Listado de productos:**");
            DataTable productos = productoDAO.ListarProductosSinSP();
            foreach (DataRow filaProducto in productos.Rows)
            {
                Console.WriteLine($"ID: {filaProducto["ID_producto"]} - Nombre: {filaProducto["Nombre"]} - Categoría: {filaProducto["ID_categoria"]} - Descripción: {filaProducto["Descripcion"]}");
            }
            Console.ReadLine();
        }
    }
}
