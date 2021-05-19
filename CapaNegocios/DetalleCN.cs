using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;
namespace CapaNegocios
{
    public class DetalleCN
    {
        public int insertar(DetalleCE detalleCE)
        {       
            DetalleCD detalleCD = new DetalleCD();
            int nuevoId = detalleCD.insertar(detalleCE);
            return nuevoId;
        }
    }
}
