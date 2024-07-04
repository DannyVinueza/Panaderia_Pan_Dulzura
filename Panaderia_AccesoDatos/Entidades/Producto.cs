using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia_AccesoDatos.Entidades
{
    public class Producto
    {
        public int ID_producto { get; set; }
        public string Nombre { get; set; }
        public int? ID_categoria { get; set; }
        public string Descripcion { get; set; }
        public string Ingredientes { get; set; }
        public int? Calorias { get; set; }

        // Propiedad de navegación para la categoría asociada (opcional)
        public Categoria Categoria { get; set; }
    }
}
