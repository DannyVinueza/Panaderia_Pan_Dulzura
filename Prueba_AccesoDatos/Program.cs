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
            Console.ReadLine();
        }
    }
}
