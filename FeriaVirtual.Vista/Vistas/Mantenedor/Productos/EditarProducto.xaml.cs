using FeriaVirtual.Negocio;
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
    /// Lógica de interacción para EditarProducto.xaml
    /// </summary>
    public partial class EditarProducto : Window
    {

        Producto producto_contexto = new Producto();
        public EditarProducto()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_guardar_editar_Click(object sender, RoutedEventArgs e)
        {
            Producto producto_resquest = new Producto();
            producto_resquest.id = producto_contexto.id;

            if (tb_descripcion.Text.Trim() != producto_contexto.descripcion)
                producto_resquest.descripcion = tb_descripcion.Text.Trim();

            producto_resquest.habilitado = check_habilitar.IsChecked == true ? 1 : 0;


            int response = ProductoService.actualizarProducto(producto_resquest);

            if (response == -1) {

                string mensaje = "No se pudo actualizar el producto, favor revise los datos ingresados.";
                string titulo = "Error";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Error;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                return;

            }

            if (response > 0)
            {

                string mensaje = "Producto actualizado correctamente.";
                string titulo = "Información";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Information;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                cambiar_estado_textblock(false);
                reset_ui_textblock();
                txt_buscar_descripcion.Focus();
                return;

            }
        }

        private void btn_buscar_producto_Click(object sender, RoutedEventArgs e)
        {
            if (txt_buscar_descripcion.Text.Trim().Length==0) {

                string mensaje = "Debe ingresar un identificador de producto para buscar.";
                string titulo = "Información";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Information;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                cambiar_estado_textblock(false);
                reset_ui_textblock();
                txt_buscar_descripcion.Focus();
                return;
            }


            Producto producto = new Producto();
            producto.descripcion = txt_buscar_descripcion.Text.Trim();

            List<Producto> lista_producto_resultado = ProductoService.consultarProducto(producto);

            if (lista_producto_resultado.Count == 0)
            {
                string mensaje = "No se encontró el producto con esa descripcion.";
                string titulo = "Error";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Error;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                cambiar_estado_textblock(false);
                reset_ui_textblock();
                txt_buscar_descripcion.Focus();
                return;
            }

            if (lista_producto_resultado.Count > 1)
            {
                string mensaje = "Se encontraron muchas coincidencias para su busqueda, favor contactar a un administrador.";
                string titulo = "Error";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Error;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                cambiar_estado_textblock(false);
                reset_ui_textblock();
                txt_buscar_descripcion.Focus();
                return;
            }

                cambiar_estado_textblock(true);
                Producto producto_response = lista_producto_resultado[0];
                tb_descripcion.Text = producto_response.descripcion;
                


                if (producto_response.habilitado == 1)
                {
                    check_habilitar.IsChecked = true;
                    check_deshabilitar.IsChecked = false;
                }
                if (producto_response.habilitado == 0)
                {
                    check_habilitar.IsChecked = false;
                    check_deshabilitar.IsChecked = true;
                }

                producto_contexto = producto_response;
            
        }



        public void cambiar_estado_textblock(Boolean habilitar)
        {

            tb_descripcion.IsEnabled = habilitar;
            check_habilitar.IsEnabled = habilitar;
            check_deshabilitar.IsEnabled = habilitar;
            btn_guardar_editar.IsEnabled = habilitar;
            lbl_descripcion.IsEnabled = habilitar;
            lbl_habilitado.IsEnabled = habilitar;

        }

        public void reset_ui_textblock()
        {
            tb_descripcion.Text = String.Empty;
            check_habilitar.IsChecked = false;
            check_deshabilitar.IsChecked = false;
            producto_contexto = new Producto();
        }
    }
}
