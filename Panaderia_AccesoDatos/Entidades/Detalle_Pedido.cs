using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia_AccesoDatos.Entidades
{
    public class Detalle_Pedido
    {
        public int ID_detalle { get; set; }
        public int ID_pedido { get; set; }
        public int ID_producto { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        // Propiedad de navegación para Pedidos y Productos
        public Pedidos Pedidos { get; set; }
        public Producto Producto { get; set; }

    }
}
