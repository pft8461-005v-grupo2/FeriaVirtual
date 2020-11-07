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



        private void btn_micuenta_Click(object sender, RoutedEventArgs e)
        {
            //(Application.Current as App).ResetSessionTimer();
        }

        private void btn_cerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            //(Application.Current as App).StopSessionTimer();
            Application.Current.Shutdown();
        }

        private void btn_cerrarAplicacion_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(-1);
        }

        //private void btnCrear_Usuario_Click(object sender, RoutedEventArgs e)
        //{
        //    //(Application.Current as App).ResetSessionTimer();
        //    frameAdm.Content = new Vistas.Usuario.CrearUsuario();
        //}

        //private void btn_menu_modificar_usuario_Click(object sender, RoutedEventArgs e)
        //{
        //    //(Application.Current as App).ResetSessionTimer();
        //}

        private void btn_menu_activar_usuario_Click(object sender, RoutedEventArgs e)
        {
            //(Application.Current as App).ResetSessionTimer();
        }

        //private void btn_menu_perfil_Click(object sender, RoutedEventArgs e)
        //{
        //    (Application.Current as App).ResetSessionTimer();
        //}

        private void btn_menu_ventaInternacional_Click(object sender, RoutedEventArgs e)
        {
            //(Application.Current as App).ResetSessionTimer();
            frameAdm.Content = new Vistas.Procesos_venta.Internacional.ProcesoVentaInternacional();
            
        }

        private void btn_menu_ventanacional_Click(object sender, RoutedEventArgs e)
        {
            //(Application.Current as App).ResetSessionTimer();
             frameAdm.Content = new Vistas.Procesos_venta.Nacional.ProcesoVentaNacional();
        }

        private void btnCrear_rol_Click(object sender, RoutedEventArgs e)
        {
            //(Application.Current as App).ResetSessionTimer();
            
        }

        private void btn_menu_activar_rol_Click(object sender, RoutedEventArgs e)
        {
            //(Application.Current as App).ResetSessionTimer();
        }

        private void btn_menu_modificar_rol_Click(object sender, RoutedEventArgs e)
        {
            //(Application.Current as App).ResetSessionTimer();
        }

        private void btn_menu_cliente_Click(object sender, RoutedEventArgs e)
        {
            frameAdm.Content = new Vistas.Mantenedor.VistaCliente();
        }

        private void btn_menu_producto_Click(object sender, RoutedEventArgs e)
        {
            frameAdm.Content = new Vistas.Mantenedor.VistaProductor();
        }

        private void btn_menu_transportista_Click(object sender, RoutedEventArgs e)
        {
            frameAdm.Content = new Vistas.Mantenedor.VistaTransportista();
        }

        //private void btn_menu_activar_rol_Click(object sender, RoutedEventArgs e)
        //{
        //    (Application.Current as App).ResetSessionTimer();
        //}

        //private void btn_menu_modificar_rol_Click(object sender, RoutedEventArgs e)
        //{
        //    (Application.Current as App).ResetSessionTimer();

        //}
    }
}
