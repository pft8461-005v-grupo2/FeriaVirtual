using System;
using System.Collections.Generic;
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
using System.Threading;

namespace FeriaVirtual.Vista
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
        }





        private void btn_cerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void btn_cerrarAplicacion_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(-1);
        }


        //private void btn_menu_ventanacional_Click(object sender, RoutedEventArgs e)
        //{
        //    deshabilitar_textos_principales();
        //     frameAdm.Content = new Vistas.Procesos_venta.Nacional.ProcesoVentaNacional();
        //}


        private void btn_menu_cliente_Click(object sender, RoutedEventArgs e)
        {
            deshabilitar_textos_principales();
            frameAdm.Content = new Vistas.Mantenedor.VistaCliente();
        }

        private void btn_menu_producto_Click(object sender, RoutedEventArgs e)
        {
            deshabilitar_textos_principales();
            frameAdm.Content = new Vistas.Mantenedor.VistaProductor();
        }

        private void btn_menu_transportista_Click(object sender, RoutedEventArgs e)
        {
            deshabilitar_textos_principales();
            frameAdm.Content = new Vistas.Mantenedor.VistaTransportista();
        }

        private void btn_menu_nuevosPendientes_Click(object sender, RoutedEventArgs e)
        {
            deshabilitar_textos_principales();
            frameAdm.Content = new Vistas.Procesos_venta.Internacional.NuevosPedidos();
        }

        private void btn_menu_acuerdosPendientes_Click(object sender, RoutedEventArgs e)
        {
            deshabilitar_textos_principales();
            frameAdm.Content = new Vistas.Procesos_venta.Internacional.AcuerdosPendientes();
        }

        private void btn_menu_productos_Click(object sender, RoutedEventArgs e)
        {
            deshabilitar_textos_principales();
            frameAdm.Content = new Vistas.Mantenedor.Productos.VistaProductos();
        }

        private void btn_menu_subastasPendientes_Click(object sender, RoutedEventArgs e)
        {
            deshabilitar_textos_principales();
            frameAdm.Content = new Vistas.Procesos_venta.Internacional.GenerarSubastas();
        }

        private void btn_menu_despachosPendientes_Click(object sender, RoutedEventArgs e)
        {
            deshabilitar_textos_principales();
            frameAdm.Content = new Vistas.Procesos_venta.Internacional.VentaDespachar();
        }

        private void btn_menu_stockDisponible_Click(object sender, RoutedEventArgs e)
        {
            deshabilitar_textos_principales();
            frameAdm.Content = new Vistas.Procesos_venta.Nacional.VistaStockDisponible();
        }

        private void deshabilitar_textos_principales()
        {
            titulo.Visibility = Visibility.Hidden;
            descripcion.Visibility = Visibility.Hidden;
            imagen_principal.Visibility = Visibility.Hidden;
        }

        private void btn_menu_solicitudCompra_Click(object sender, RoutedEventArgs e)
        {
            deshabilitar_textos_principales();
            frameAdm.Content = new Vistas.Procesos_venta.Nacional.SolicitudesCompra();
        }
    }
}
