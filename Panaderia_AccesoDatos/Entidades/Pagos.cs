﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia_AccesoDatos.Entidades
{
    public class Pagos
    {
        public int ID_pagos { get; set; }
        public int ID_pedido { get; set; }
        public int Monto { get; set; }
        public DateTime Fecha_Pago { get; set; }
        public string Metodo_Pago { get; set; }
    }

}
