using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio.Constants
{
    class Endpoints
    {
        public const string SERVER = "http://192.168.100.4:8080/api";

        // Consultar
        public const string usuario_consultar = "/usuario/consultar";
        public const string cliente_consultar = "/cliente/consultar";
        public const string consultar_productor = "/productor/consultar";
        public const string transportista_consultar = "/transportista/consultar";
        public const string solicitud_compra_consultar = "/solicitud-compra/consultar";



        // Crear
        public const string usuario_crear = "/usuario/crear";
        public const string cliente_crear = "/cliente/crear";
        public const string Productor_crear = "/productor/crear";
        public const string transportista_crear = "/transportista/crear";

        // Actualizar
        public const string cliente_actualizar = "/cliente/actualizar";
        public const string productor_actualizar = "/productor/actualizar";
        public const string transportista_actualizar = "/transportista/actualizar";
    }
}
