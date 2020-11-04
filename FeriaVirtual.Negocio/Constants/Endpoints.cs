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


        // Crear
        public const string usuario_crear = "/usuario/crear";
        public const string cliente_crear = "/cliente/crear";

    }
}
