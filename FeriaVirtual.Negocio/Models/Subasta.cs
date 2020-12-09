using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio.Models
{
    public class Subasta
    {
        public int? id { get; set; }
        public String fechatermino { get; set; }
        public int? precioganador { get; set; }
        public int? habilitado { get; set; }
    }
}
