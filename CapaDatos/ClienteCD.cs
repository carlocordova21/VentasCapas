using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class ClienteCD
    {
        public ClienteCE buscarId(int id)
        {
            SqlConnection conexion = ConexionCD.conectarSqlServer();
            conexion.Open();
            SqlCommand cmd = conexion.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from cliente where id=@id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader drCliente = cmd.ExecuteReader();
            ClienteCE clienteCE = new ClienteCE();

            if(drCliente.Read())
            {
                clienteCE.Id = Convert.ToInt32(drCliente["id"]);
                clienteCE.Nombre = drCliente["nombre"].ToString();
                clienteCE.Numruc = drCliente["numruc"].ToString();
                clienteCE.Direccion = drCliente["direccion"].ToString();
                clienteCE.Telefono = drCliente["telefono"].ToString();
            } else
            {
                clienteCE.Id = 0;
                clienteCE.Nombre = "";
                clienteCE.Numruc = "";
                clienteCE.Direccion = "";
                clienteCE.Telefono = "";
            }
            conexion.Close();

            return clienteCE;
        }

        public List<ClienteCE> buscarNombre(string nombre)
        {
            SqlConnection conexion = ConexionCD.conectarSqlServer();
            conexion.Open();
            SqlCommand cmd = conexion.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from cliente where nombre " +
                "like '%' + @nombre + '%'";

            cmd.Parameters.AddWithValue("@nombre", nombre);

            SqlDataReader drCliente = cmd.ExecuteReader();
            List<ClienteCE> listaClientesCE = new List<ClienteCE>();

            while (drCliente.Read())
            {
                ClienteCE clienteCE = new ClienteCE();
                clienteCE.Id = Convert.ToInt32(drCliente["id"]);
                clienteCE.Nombre = drCliente["nombre"].ToString();
                clienteCE.Numruc = drCliente["numruc"].ToString();
                clienteCE.Direccion = drCliente["direccion"].ToString();
                clienteCE.Telefono = drCliente["telefono"].ToString();

                listaClientesCE.Add(clienteCE);
            }
            conexion.Close();

            return listaClientesCE;
        }

        public List<ClienteCE> buscarRuc(string numruc)
        {
            SqlConnection conexion = ConexionCD.conectarSqlServer();
            conexion.Open();
            SqlCommand cmd = conexion.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from cliente where numruc " +
                "like + @numruc + '%'";

            cmd.Parameters.AddWithValue("@numruc", numruc);

            SqlDataReader drCliente = cmd.ExecuteReader();
            List<ClienteCE> listaClientesCE = new List<ClienteCE>();

            while (drCliente.Read())
            {
                ClienteCE clienteCE = new ClienteCE();
                clienteCE.Id = Convert.ToInt32(drCliente["id"]);
                clienteCE.Nombre = drCliente["nombre"].ToString();
                clienteCE.Numruc = drCliente["numruc"].ToString();
                clienteCE.Direccion = drCliente["direccion"].ToString();
                clienteCE.Telefono = drCliente["telefono"].ToString();

                listaClientesCE.Add(clienteCE);
            }
            conexion.Close();

            return listaClientesCE;
        }

        public int insertar(ClienteCE clienteCE)
        {
            SqlConnection conexion = ConexionCD.conectarSqlServer();
            conexion.Open();
            SqlCommand cmd = conexion.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "insert into cliente (nombre, numruc, direccion, telefono) " +
                "values (@nombre, @numruc, @direccion, @telefono)";

            cmd.Parameters.AddWithValue("@nombre", clienteCE.Nombre);
            cmd.Parameters.AddWithValue("@numruc", clienteCE.Numruc);
            cmd.Parameters.AddWithValue("@direccion", clienteCE.Direccion);
            cmd.Parameters.AddWithValue("@telefono", clienteCE.Telefono);

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
                        cmd.CommandText = "select max(id) as nuevoId from cliente " +
                        "where nombre=@nombre";
                        cmd.Parameters["@nombre"].Value = clienteCE.Nombre;

                        SqlDataReader drCliente = cmd.ExecuteReader();
                        if (drCliente.Read())
                        {
                            nuevoId = Convert.ToInt32(drCliente["nuevoId"]);
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

        public bool actualizar(ClienteCE clienteCE)
        {
            SqlConnection conexion = ConexionCD.conectarSqlServer();
            conexion.Open();
            SqlCommand cmd = conexion.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "update cliente set nombre=@nombre, " +
                "numruc=@numruc, direccion=@direccion, telefono=@telefono" +
                " where id=@id";

            cmd.Parameters.AddWithValue("@id", clienteCE.Id);
            cmd.Parameters.AddWithValue("@nombre", clienteCE.Nombre);
            cmd.Parameters.AddWithValue("@numruc", clienteCE.Numruc);
            cmd.Parameters.AddWithValue("@direccion", clienteCE.Direccion);
            cmd.Parameters.AddWithValue("@telefono", clienteCE.Telefono);

            //******************************
            //Iniciar el control de transacciones
            int nfilas;
            using (SqlTransaction transaction = conexion.BeginTransaction())
            {
                cmd.Transaction = transaction;
                try
                {
                    nfilas = cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    nfilas = 0;
                }
            }
            
            conexion.Close();

            if (nfilas == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool eliminar(int id)
        {
            SqlConnection conexion = ConexionCD.conectarSqlServer();
            conexion.Open();
            SqlCommand cmd = conexion.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "delete from cliente where id=@id";
            cmd.Parameters.AddWithValue("@id", id);

            //******************************
            //Iniciar el control de transacciones
            int nfilas;
            using (SqlTransaction transaction = conexion.BeginTransaction())
            {
                cmd.Transaction = transaction;
                try
                {
                    nfilas = cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    nfilas = 0;
                }
                
            }
            
            conexion.Close();

            if (nfilas == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
