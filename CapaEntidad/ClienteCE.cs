using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClienteCE
    {
        private int id;
        private string nombre;
        private string numruc;
        private string direccion;
        private string telefono;
        public ClienteCE() { }
        public ClienteCE(int id, string nombre, string numruc, string direccion, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.numruc = numruc;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Numruc { get => numruc; set => numruc = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
