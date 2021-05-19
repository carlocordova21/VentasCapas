using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetalleCE
    {
        private int id;
        private int idVenta;
        private int idProducto;
        private int cantidad;

        public DetalleCE() { }
        public DetalleCE(int id, int idVenta, int idProducto, int cantidad)
        {
            this.id = id;
            this.idVenta = idVenta;
            this.idProducto = idProducto;
            this.cantidad = cantidad;
        }

        public int Id { get => id; set => id = value; }
        public int IdVenta { get => idVenta; set => idVenta = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}
