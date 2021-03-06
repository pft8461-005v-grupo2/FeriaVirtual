﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Negocio.Constants
{
    class Endpoints
    {
        public const string SERVER = "http://localhost:8090/api";
        //public const string SERVER = "http://192.168.100.4:8080/api";

        // Consultar
        public const string usuario_consultar = "/usuario/consultar";
        public const string cliente_consultar = "/cliente/consultar";
        public const string consultar_productor = "/productor/consultar";
        public const string transportista_consultar = "/transportista/consultar";
        public const string solicitud_compra_consultar = "/solicitud-compra/consultar";
        public const string procesoVenta_consultar = "/proceso-venta/consultar";
        public const string producto_consultar = "/producto/consultar";
        public const string subasta_consultar = "/subasta/consultar";
        public const string stock_disponible_consultar = "/consulta-stock-disponible";
        public const string ingreso_consultar = "/ingreso/consultar";
        public const string procesoVentaIngreso_consultar = "/proceso-venta-ingreso/consultar";

        // Crear
        public const string usuario_crear = "/usuario/crear";
        public const string cliente_crear = "/cliente/crear";
        public const string Productor_crear = "/productor/crear";
        public const string transportista_crear = "/transportista/crear";
        public const string productos_crear = "/producto/crear";

        // Actualizar
        public const string cliente_actualizar = "/cliente/actualizar";
        public const string productor_actualizar = "/productor/actualizar";
        public const string transportista_actualizar = "/transportista/actualizar";
        public const string producto_actualizar = "/producto/actualizar";
        public const string procesoVenta_actualizar = "/proceso-venta/actualizar";

        // Gestiones
        public const string procesoVenta_iniciar = "/proceso-internacional/iniciar-proceso";
        public const string procesoSubasta_inter_iniciar = "/proceso-internacional/iniciar-subasta";
        public const string procesoNacional_iniciar = " /api/proceso-nacional/iniciar-proceso";

    }
}
