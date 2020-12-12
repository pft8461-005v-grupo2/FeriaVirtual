using FeriaVirtual.Negocio.Models;
using FeriaVirtual.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FeriaVirtual.Vista.Vistas.Procesos_venta.Nacional
{
    /// <summary>
    /// Lógica de interacción para SolicitudesCompra.xaml
    /// </summary>
    public partial class SolicitudesCompra : Page
    {
        public SolicitudesCompra()
        {
            InitializeComponent();
            actualizar_tabla_datos_procesoVenta();
        }

        public void actualizar_tabla_datos_procesoVenta()
        {
            ProcesoVenta procVenta = new ProcesoVenta();
            procVenta.etapa = 101;

            List<ProcesoVenta> lista_obtenida = ProcesoVentaService.consultar_ProcesoVenta(procVenta);

            DataTable tabla_con_datos = new DataTable();

            tabla_con_datos.TableName = "Lista de stock mas cliente";
            tabla_con_datos.Columns.Add("ingreso_id");
            tabla_con_datos.Columns.Add("producto_id");
            tabla_con_datos.Columns.Add("descripcion");
            tabla_con_datos.Columns.Add("kilogramos");
            tabla_con_datos.Columns.Add("fechacreacion_ingreso");
            tabla_con_datos.Columns.Add("identificador");
            tabla_con_datos.Columns.Add("razonsocial");
            tabla_con_datos.Columns.Add("proceso_venta_id");

            //Solicitud_compra solicitud_Compra = new Solicitud_compra();
            //List<Solicitud_compra> listaSolicitudCompra = Solicitud_compraService.solicitud_Compras(solicitud_Compra);


            for (int i = 0; i < lista_obtenida.Count; i++)
            {
                ProcesoVentaIngreso buscarProcesoVentaIngreso = new ProcesoVentaIngreso();
                buscarProcesoVentaIngreso.proceso_venta_id = lista_obtenida[i].id;

                ProcesoVentaIngreso procesoVentaIngresoEncontrado = ProcesoVentaIngresoService.consultar_ProcesoVentaIngreso(buscarProcesoVentaIngreso).First();

                Ingreso ingresoBuscar = new Ingreso();
                ingresoBuscar.id = procesoVentaIngresoEncontrado.ingreso_id;

                Ingreso ingresoEncontrado = IngresoService.consultarIngreso(ingresoBuscar).First();

                Productor productorBuscar = new Productor();
                productorBuscar.id = ingresoEncontrado.productor_id;

                Productor productorEncontrado = ProductorService.consultarProductor(productorBuscar).First();

                Producto productoBuscar = new Producto();
                productoBuscar.id = ingresoEncontrado.producto_id;

                Producto productoEncontrado = ProductoService.consultarProducto(productoBuscar).First();

                Solicitud_compra solicitudesCompraBuscar = new Solicitud_compra();
                solicitudesCompraBuscar.id = lista_obtenida[i].solicitud_compra_id;

                Solicitud_compra solicitud_CompraEncontrado = Solicitud_compraService.solicitud_Compras(solicitudesCompraBuscar).First();

                Cliente clienteBuscar = new Cliente();
                clienteBuscar.id = solicitud_CompraEncontrado.cliente_id;

                Cliente clienteEncontrado = ClienteService.consultarCliente(clienteBuscar).First();



                        tabla_con_datos.Rows.Add(

                        //lista_obtenida[i].id,
                        ingresoEncontrado.id,
                        productoEncontrado.id,
                        productoEncontrado.descripcion,
                        ingresoEncontrado.kilogramos,
                        ingresoEncontrado.fechacreacion,
                        clienteEncontrado.identificador,
                        clienteEncontrado.razonSocial,
                        procesoVentaIngresoEncontrado.proceso_venta_id
                        

                        );
                    
                

                data_stock_disponible_C.ItemsSource = tabla_con_datos.AsDataView();
            }

        }

        private void Btn_generarOrden_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = data_stock_disponible_C.SelectedItem as DataRowView;
            DetalleSolicitudesCompra detalleSolicitudesCompra = new DetalleSolicitudesCompra(dataRowView,this);
            detalleSolicitudesCompra.Show();

        }
    }
}
