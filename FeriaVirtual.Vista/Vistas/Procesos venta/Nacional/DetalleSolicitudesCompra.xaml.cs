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
using System.Windows.Shapes;

namespace FeriaVirtual.Vista.Vistas.Procesos_venta.Nacional
{
    /// <summary>
    /// Lógica de interacción para DetalleSolicitudesCompra.xaml
    /// </summary>
    public partial class DetalleSolicitudesCompra : Window
    {
        SolicitudesCompra ventanaSolicitudesCompraAnterior = null;
        public DetalleSolicitudesCompra(DataRowView dataRowView, SolicitudesCompra VentanaSolicitudesCompra)
        {
            InitializeComponent();

            if (VentanaSolicitudesCompra != null)
            {
                ventanaSolicitudesCompraAnterior = VentanaSolicitudesCompra;
            }


            ProcesoVenta procesoVenta = new ProcesoVenta();
            procesoVenta.id = Int32.Parse(dataRowView.Row["proceso_venta_id"] as string);
            List<ProcesoVenta> lista_obtenida = ProcesoVentaService.consultar_ProcesoVenta(procesoVenta);
            

            if (dataRowView != null)
            {
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

                    int? h = ingresoEncontrado.preciokgventaunitario * ingresoEncontrado.kilogramos;

                    if (lista_obtenida != null )

                    {
                        procesoVenta = lista_obtenida[0];
                        txt_ingresoID.Text = ingresoEncontrado.id.ToString();
                        txt_productoDescripcion.Text = productoEncontrado.descripcion;
                        txt_Precio.Text = h.ToString();
                        txt_kilogramos.Text = ingresoEncontrado.kilogramos.ToString();
                        txt_fechaCreacion.Text = ingresoEncontrado.fechacreacion;
                        txt_identificador.Text = clienteEncontrado.identificador;
                        txt_razonSocial.Text = clienteEncontrado.razonSocial;
                        txt_id_procesoVenta.Text = procesoVentaIngresoEncontrado.proceso_venta_id.ToString();

                    }
                }
            }
        }

        private void Btn_enviar_Click(object sender, RoutedEventArgs e)
        {
            ProcesoVenta procesoVenta = new ProcesoVenta();
            procesoVenta.id = Int32.Parse(txt_id_procesoVenta.Text);
            List<ProcesoVenta> listaProcesoVenta = ProcesoVentaService.consultar_ProcesoVenta(procesoVenta);

            if (listaProcesoVenta != null)

            {
                procesoVenta = listaProcesoVenta[0];


                procesoVenta.etapa = 102;

                int response = ProcesoVentaService.actualizarProcesoVenta(procesoVenta);

                if (response == -1)
                {

                    string mensaje = "No se pudo actualizar ";
                    string titulo = "Error";
                    MessageBoxButton tipo = MessageBoxButton.OK;
                    MessageBoxImage icono = MessageBoxImage.Error;
                    MessageBox.Show(mensaje, titulo, tipo, icono);
                    return;

                }

                if (response > 0)
                {

                    string mensaje = "actualizado correctamente.";
                    string titulo = "Información";
                    MessageBoxButton tipo = MessageBoxButton.OK;
                    MessageBoxImage icono = MessageBoxImage.Information;
                    MessageBox.Show(mensaje, titulo, tipo, icono);
                    ventanaSolicitudesCompraAnterior.actualizar_tabla_datos_procesoVenta();
                    this.Close();
                    return;

                }

            }
        }
    }
}
