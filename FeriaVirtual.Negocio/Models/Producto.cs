using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio.Models
{
    public class Producto
    {
        public int? id { get; set; }
        public string descripcion { get; set; }
        public int? habilitado { get; set; }
    }
}
