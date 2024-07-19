using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia_AccesoDatos
{
    internal class ConexionBD
    {
        private SqlConnection connection = new SqlConnection("Server=DESKTOP-2LFT1KS\\MSSQLSERVER01;DataBase=Pan_dulzura;Integrated Security=True;");

        // Metodo para abrir la conexion
        public SqlConnection AbrirConexion()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        // Metodo para cerrar la conexion
        public SqlConnection CerrarConexion()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            return connection;
        }
    }
}
