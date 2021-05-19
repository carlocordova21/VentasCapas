using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
namespace CapaDatos
{
    class ConexionCD
    {
        public static SqlConnection conectarSqlServer()
        {
            SqlConnectionStringBuilder cadena = new SqlConnectionStringBuilder();
            cadena.DataSource = "localhost";
            cadena.InitialCatalog = "BDMARKET";
            cadena.UserID = "sa";
            cadena.Password = "12345";
            string cadenaConexion = cadena.ConnectionString;

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            return conexion;
        }
    }
}
