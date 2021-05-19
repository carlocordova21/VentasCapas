using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class VentaCE
    {
        private int id;
        private DateTime fechaVenta;
        private int idCliente;

        public VentaCE(int id, DateTime fechaVenta, int idCliente)
        {
            this.id = id;
            this.fechaVenta = fechaVenta;
            this.idCliente = idCliente;
        }

        public int Id { get => id; set => id = value; }
        public DateTime FechaVenta { get => fechaVenta; set => fechaVenta = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
    }
}
