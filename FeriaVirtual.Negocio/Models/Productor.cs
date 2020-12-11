using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio.Models
{
    public class Productor
    {
        public int? id { get; set; }
        public int? usuario_id { get; set; }
        public string rut { get; set; }
        public string razonsocial { get; set; }
        public string direccion { get; set; }
        public string comuna { get; set; }
        public string correo { get; set; }
        public int? habilitado { get; set; }

    }
}
