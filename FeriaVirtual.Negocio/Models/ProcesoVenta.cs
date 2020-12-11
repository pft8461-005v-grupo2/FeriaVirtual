using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio.Models
{
    public class ProcesoVenta
    {
        public int? id { get; set; }
        public int? solicitud_compra_id { get; set; }
        public int? subasta_id { get; set; }
        public int? etapa { get; set; }
        public string fechacreacion { get; set; }
        public int? clienteaceptaacuerdo { get; set; }
        public int? precioventatotal { get; set; }
        public int? preciocostototal { get; set; }

    }
}
