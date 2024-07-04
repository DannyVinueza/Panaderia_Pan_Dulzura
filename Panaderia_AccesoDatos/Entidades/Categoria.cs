using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia_AccesoDatos.Entidades
{
    public class Categoria
    {
        public int ID_categoria { get; set; }
        public string Nombre { get; set; }

        // Propiedad de navegación para los productos asociados (opcional)
        public ICollection<Producto> Productos { get; set; }
    }
}
