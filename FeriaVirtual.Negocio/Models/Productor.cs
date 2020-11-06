using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio.Models
{
    public class Productor
    {
        public int id { get; set; }
        public int usuario_id { get; set; }
        public int contrato_id { get; set; }
        public String rut { get; set; }
        public String razonsocial { get; set; }
        public String direccion { get; set; }
        public String comuna { get; set; }
        public String correo { get; set; }
        public char habilitado { get; set; }

    }
}
