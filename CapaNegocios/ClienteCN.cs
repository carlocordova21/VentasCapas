using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaNegocios
{
    public class ClienteCN
    {
        public ClienteCE buscarId(int id)
        {
            ClienteCD clienteCD = new ClienteCD();
            ClienteCE clienteCE = clienteCD.buscarId(id);
            return clienteCE;
        }

        public List<ClienteCE> buscarNombre(string nombre)
        {
            ClienteCD clienteCD = new ClienteCD();
            List<ClienteCE> listaclientes = clienteCD.buscarNombre(nombre);
            return listaclientes;
        }

        public List<ClienteCE> buscarRuc(string ruc)
        {
            ClienteCD clienteCD = new ClienteCD();
            List<ClienteCE> listaclientes = clienteCD.buscarRuc(ruc);
            return listaclientes;
        }

        public int insertar(ClienteCE clienteCE)
        {
            ClienteCD clienteCD = new ClienteCD();
            int id = clienteCD.insertar(clienteCE);
            return id;
        }

        public bool actualizar(ClienteCE clienteCE)
        {
            ClienteCD clienteCD = new ClienteCD();
            bool estado = clienteCD.actualizar(clienteCE);
            return estado;
        }

        public bool eliminar(int id)
        {
            ClienteCD clienteCD = new ClienteCD();
            bool estado = clienteCD.eliminar(id);
            return estado;
        }
    }
}
