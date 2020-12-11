using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio.Models
{
    public class StockDisponible
    {
        public int? ingreso_id { get; set; }
        public int? producto_id { get; set; }
        public string descripcion { get; set; }
        public int? kilogramos { get; set; }
        public int? precioventaunitario { get; set; }
        public int? preciocostounitario { get; set; }
        public string fechacreacion_ingreso { get; set; }
        public int? productor_id { get; set; }
        public int? usuario_id { get; set; }
        public string rut_productor { get; set; }
        public string razonsocial_productor { get; set; }
        public string direccion_productor { get; set; }
        public string comuna_productor { get; set; }
        public string correo_productor { get; set; }
        public int? contrato_id { get; set; }
        public int? vigencia_contrato { get; set; }
    }
}
