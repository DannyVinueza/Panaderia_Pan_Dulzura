using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia_AccesoDatos.Entidades
{
    public class Pedidos
    {
        public int ID_pedido { get; set; }
        public int ID_usuario { get; set; }
        public DateTime Fecha_Pedido { get; set; }
        public DateTime Fecha_Entrega { get; set; }
        public string Estado { get; set; }
    }
}
