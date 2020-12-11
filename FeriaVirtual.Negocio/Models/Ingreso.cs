using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio.Models
{
    public class Ingreso
    {
        public int? id { get; set; }
        public int? productor_id { get; set; }
        public int? producto_id { get; set; }
        public string fechacreacion { get; set; }
        public int? kilogramos { get; set; }
        public int? preciokgcostounitario { get; set; }
        public int? preciokgventaunitario { get; set; }
        public int? habilitado { get; set; }
 
    }
}
