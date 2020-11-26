using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio
{
    public class Usuario
    {
        public int? id { get; set; }
        public int? rol_id { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public int? habilitado { get; set; }
    }
}
