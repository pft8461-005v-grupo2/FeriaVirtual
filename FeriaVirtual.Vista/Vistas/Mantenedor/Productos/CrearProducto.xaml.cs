using FeriaVirtual.Negocio;
using FeriaVirtual.Negocio.Constants;
using FeriaVirtual.Negocio.Models;
using FeriaVirtual.Negocio.Services;
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

namespace FeriaVirtual.Vista.Vistas.Mantenedor.Productos
{
    /// <summary>
    /// Lógica de interacción para CrearProducto.xaml
    /// </summary>
    public partial class CrearProducto : Window
    {
        public CrearProducto()
        {
            InitializeComponent();
        }

        private void Btn_Cerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_crear_producto_Click(object sender, RoutedEventArgs e)
        {
            Producto producto = new Producto();

            producto.descripcion = txt_descipcion.Text.ToUpper();

            int producto_id_creado = 0;


            producto_id_creado = ProductoService.crearProducto(producto);



            if (producto_id_creado != -1)
            {
                string mensaje = "producto ingresado correctamente.";
                string titulo = "Información";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Information;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                return;
            }

        }
    }
}
