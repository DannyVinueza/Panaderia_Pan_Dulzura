using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia_AccesoDatos.Entidades
{
    public class Notificaciones
    {
        public int ID_Notificacion { get; set; }
        public int ID_pedido { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha_Notificacion { get; set; }
    }
}
