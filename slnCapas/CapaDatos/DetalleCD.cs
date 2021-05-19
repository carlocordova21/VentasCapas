using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using CapaEntidad;
namespace CapaDatos
{
    public class DetalleCD
    {
        public int insertar(DetalleCE detalleCE)
        {
            SqlConnection conexion = ConexionCD.conectarSqlServer();
            conexion.Open();

            SqlCommand cmd = conexion.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into detalle(idVenta, idProducto, cantidad) " +
                "values (@idVenta, @idProducto, @cantidad)";

            cmd.Parameters.AddWithValue("@idVenta", detalleCE.IdVenta);
            cmd.Parameters.AddWithValue("@idProducto", detalleCE.IdProducto);
            cmd.Parameters.AddWithValue("@cantidad", detalleCE.Cantidad);

            //******************************
            //Iniciar el control de transacciones
            int nuevoId;
            using (SqlTransaction transaction = conexion.BeginTransaction())
            {
                cmd.Transaction = transaction;
                try
                {
                    int nfilas = cmd.ExecuteNonQuery();
                    transaction.Commit();

                    if (nfilas == 0)
                    {
                        nuevoId = 0;
                    }
                    else
                    {
                        cmd.CommandText = "select max(id) as nuevoId from detalle " +
                            "where idVenta=@idVenta";

                        cmd.Parameters["@idVenta"].Value = detalleCE.IdVenta;

                        SqlDataReader drDetalle = cmd.ExecuteReader();
                        if (drDetalle.Read())
                        {
                            nuevoId = Convert.ToInt32(drDetalle["nuevoId"]);
                        }
                        else
                        {
                            nuevoId = 0;
                        }
                    }
                }
                catch
                {
                    transaction.Rollback();
                    nuevoId = 0;
                }
            }
            
            conexion.Close();

            return nuevoId;
        }
    }
}
