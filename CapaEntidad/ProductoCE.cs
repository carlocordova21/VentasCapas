using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ProductoCE
    {
        //Propiedades
        private int id;
        private string descripcion;
        private string categoria;
        private double precio;

        //Constructor
        public ProductoCE() { }
        public ProductoCE(int id, string descripcion, string categoria, double precio)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.categoria = categoria;
            this.precio = precio;
        }

        //Encapsulado
        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public double Precio { get => precio; set => precio = value; }


        //Metodos
    }
}
