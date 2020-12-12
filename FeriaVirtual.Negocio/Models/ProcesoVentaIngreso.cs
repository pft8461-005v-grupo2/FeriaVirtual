using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio.Models
{
    public class ProcesoVentaIngreso
    {
        public int? ingreso_id { get; set; }
        public int? proceso_venta_id { get; set; }
        public int? kilogramosocupados { get; set; }
        public int? habilitado { get; set; }
    }
}
