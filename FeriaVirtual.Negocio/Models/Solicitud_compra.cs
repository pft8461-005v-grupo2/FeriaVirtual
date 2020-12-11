using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio.Models
{
    public class Solicitud_compra
    {
        
        public int? id { get; set; } // ? para dejar en null un int
        public int? cliente_id { get; set; }
        public string fechacreacion { get; set; }
        public string producto { get; set; }
        public int? kilogramos { get; set; }
        public int? habilitado { get; set; }

    }
}
