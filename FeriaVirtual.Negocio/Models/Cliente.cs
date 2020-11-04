using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public int usuario_id { get; set; }
        public string identificador { get; set; }
        public string razonSocial { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public string pais_origen { get; set; }
        public int tipo_cliente { get; set; }
        public string correo { get; set; }
        public char habilitado { get; set; }
    }
}
