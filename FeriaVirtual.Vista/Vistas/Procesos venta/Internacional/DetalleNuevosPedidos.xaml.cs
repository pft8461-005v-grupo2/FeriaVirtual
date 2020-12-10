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

namespace FeriaVirtual.Vista.Vistas.Procesos_venta.Internacional
{
    /// <summary>
    /// Lógica de interacción para DetalleNuevosPedidos.xaml
    /// </summary>
    public partial class DetalleNuevosPedidos : Window
    {
        private int? solicitudCompraContexto = -1;
        NuevosPedidos ventanaNuevosPedidosAnterior = null;

        public DetalleNuevosPedidos(DataRowView dataRowView, NuevosPedidos ventanaPedidos)
        {
            InitializeComponent();

            if( ventanaPedidos != null)
            {
                ventanaNuevosPedidosAnterior = ventanaPedidos;
            }

            if (dataRowView != null)
            {
                Cliente cliente = new Cliente();
                cliente.id = Int32.Parse(dataRowView.Row["cliente_id"] as string);
                List<Cliente> listaCliente = ClienteService.consultarCliente(cliente);

                Solicitud_compra solicitud_Compra = new Solicitud_compra();
                solicitud_Compra.id = Int32.Parse(dataRowView.Row["id"] as string);
                List<Solicitud_compra> lista_obtenida = Solicitud_compraService.solicitud_Compras(solicitud_Compra);
                solicitudCompraContexto = solicitud_Compra.id;
                if (listaCliente != null && listaCliente.Count == 1)

                {  
                    cliente = listaCliente[0];
                    solicitud_Compra = lista_obtenida[0];
                    txt_id.Text = cliente.id.ToString();
                    txt_razonSocial.Text = cliente.razonSocial;
                    txt_identificador.Text = cliente.identificador;
                    txt_direccion.Text = cliente.direccion;
                    txt_pais.Text = cliente.pais_origen;
                    txt_correo.Text = cliente.correo;
                    txt_producto.Text = solicitud_Compra.producto;
                    txt_kilogramos.Text = solicitud_Compra.kilogramos.ToString();
                
                }
                
            }


        }
   

        private void Btn_generaProcesoVenta_Click(object sender, RoutedEventArgs e)
        {

            ProcesoVenta procesoVenta = new ProcesoVenta();
            procesoVenta.solicitud_compra_id = solicitudCompraContexto;
           int? respuesta=  ProcesoVentaService.iniciarProcesoVenta(procesoVenta);

            //-3 = producto no encontrado
            //-2 = Solicitud no encontrada
            //-1 = Error
            //1 = Se creo proceso y no hay stock
            //2 = Se creo proceso y stock insuficiente
            //3 = Se creo proceso y stock suficiente


            String mensaje = "";
            MessageBoxImage icono = MessageBoxImage.Information;
            switch (respuesta)
            {
                case -3 :
                    mensaje = "No existe producto a  procesar. Favor crear el producto en sistema";
                    icono = MessageBoxImage.Error;
                    break;
                case -2:
                    mensaje = "No existe solicitud de compra";
                    icono = MessageBoxImage.Error;
                    break;
                case -1:
                    mensaje = "Error de sistema. Contacta con el administrador de sistema";
                    icono = MessageBoxImage.Error;
                    break;
                case 1:
                    mensaje = "Se inició el proceso de venta, pero no hay stock del producto seleccionado";
                    icono = MessageBoxImage.Warning;
                    ventanaNuevosPedidosAnterior.actualizar_tabla_datos_NuevosPedidos();
                    break;
                case 2:
                    mensaje = "Se inició el proceso de venta, pero el stock es insuficiente";
                    icono = MessageBoxImage.Warning;
                    ventanaNuevosPedidosAnterior.actualizar_tabla_datos_NuevosPedidos();
                    break;
                case 3:
                    mensaje = "Se inició el proceso de venta correctamente";
                    icono = MessageBoxImage.Information;
                    ventanaNuevosPedidosAnterior.actualizar_tabla_datos_NuevosPedidos();
                    break;
                default:
                    mensaje = "Error no tratado";
                    break;
            }
          
            string titulo = "Información";
            MessageBoxButton tipo = MessageBoxButton.OK;
            MessageBox.Show(mensaje, titulo, tipo, icono);
            this.Close();
            return;
        }
    }
}
