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

namespace FeriaVirtual.Vista.Vistas.Mantenedor
{
    /// <summary>
    /// Lógica de interacción para EditarProductor.xaml
    /// </summary>
    public partial class EditarProductor : Window
    {
        Usuario usuario_contexto = new Usuario();
        Productor productor_contexto = new Productor();
        VistaProductor ventanVistaProductorAnterior = null;
        public EditarProductor(VistaProductor VentanaVistaProductor)
        {
            InitializeComponent();
            if (VentanaVistaProductor != null)
            {
                ventanVistaProductorAnterior = VentanaVistaProductor;
            }
        }

        private void btn_buscar_productor_Click(object sender, RoutedEventArgs e)
        {
            if (txt_buscar_correo.Text.Trim().Length == 0)
            {
                string mensaje = "Debe ingresar un identificador de productor para buscar.";
                string titulo = "Información";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Information;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                cambiar_estado_textblock(false);
                reset_ui_textblock();
                txt_buscar_correo.Focus();
                return;
            }

            Productor productor = new Productor();
            productor.correo = txt_buscar_correo.Text.Trim();

            List<Productor> lista_productor_resultado = ProductorService.consultarProductor(productor);

            if (lista_productor_resultado.Count == 0) {
                string mensaje = "No se encontró el productor con ese correo.";
                string titulo = "Error";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Error;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                cambiar_estado_textblock(false);
                reset_ui_textblock();
                txt_buscar_correo.Focus();
                return;
            }

            if (lista_productor_resultado.Count > 1) {
                string mensaje = "Se encontraron muchas coincidencias para su busqueda, favor contactar a un administrador.";
                string titulo = "Error";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Error;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                cambiar_estado_textblock(false);
                reset_ui_textblock();
                txt_buscar_correo.Focus();
                return;
            }

            if (lista_productor_resultado.Count == 1) {

                Productor productor_response = lista_productor_resultado[0];

                Usuario usuario_request = new Usuario();
                usuario_request.id = productor_response.usuario_id;

                List<Usuario> lista_usuario_response = UsuarioService.consultarUsuario(usuario_request);

                if (lista_usuario_response.Count == 0)
                {
                    string mensaje = "No existe un usuario enlazado al productor, favor contactar al administrador.";
                    string titulo = "Error";
                    MessageBoxButton tipo = MessageBoxButton.OK;
                    MessageBoxImage icono = MessageBoxImage.Error;
                    MessageBox.Show(mensaje, titulo, tipo, icono);
                    cambiar_estado_textblock(false);
                    reset_ui_textblock();
                    txt_buscar_correo.Focus();
                    return;
                }

                if (lista_usuario_response.Count == 1)
                {
                    cambiar_estado_textblock(true);

                    usuario_contexto = lista_usuario_response[0];
                    tb_rut.Text = productor_response.rut;
                    tb_razon_social.Text = productor_response.razonsocial;
                    tb_direccion.Text = productor_response.direccion;
                    tb_comuna.Text = productor_response.comuna;
                    tb_correo.Text = productor_response.correo;



                    if (productor_response.habilitado == 1)
                    {
                        check_habilitar.IsChecked = true;
                        check_deshabilitar.IsChecked = false;
                    }
                    if (productor_response.habilitado == 0)
                    {
                        check_habilitar.IsChecked = false;
                        check_deshabilitar.IsChecked = true;
                    }

                    productor_contexto = productor_response;


                }
            }
        }

        public void cambiar_estado_textblock(Boolean habilitar)
        {
           
            tb_rut.IsEnabled = habilitar;
            tb_razon_social.IsEnabled = habilitar;
            tb_direccion.IsEnabled = habilitar;
            tb_comuna.IsEnabled = habilitar;
            tb_correo.IsEnabled = habilitar;
            check_habilitar.IsEnabled = habilitar;
            check_deshabilitar.IsEnabled = habilitar;
            btn_guardar_editar.IsEnabled = habilitar;

        }

        public void reset_ui_textblock()
        {
            tb_rut.Text = String.Empty;
            tb_razon_social.Text = String.Empty;
            tb_direccion.Text = String.Empty;
            tb_comuna.Text = String.Empty;
            tb_correo.Text = String.Empty;
            check_habilitar.IsChecked = false;
            check_deshabilitar.IsChecked = false;
            usuario_contexto = new Usuario();
            productor_contexto = new Productor();
        }

        private void btn_guardar_editar_Click(object sender, RoutedEventArgs e)
        {
            Productor productor_request = new Productor();
            productor_request.id = productor_contexto.id;

            if (tb_rut.Text.Trim() != productor_contexto.rut)
                productor_request.rut = tb_rut.Text.Trim();
            if (tb_razon_social.Text.Trim() != productor_contexto.razonsocial)
                productor_request.razonsocial = tb_razon_social.Text.Trim();
            if (tb_direccion.Text.Trim() != productor_contexto.direccion)
                productor_request.direccion = tb_direccion.Text.Trim();
            if (tb_comuna.Text.Trim() != productor_contexto.comuna)
                productor_request.comuna = tb_comuna.Text.Trim();
            if (tb_correo.Text.Trim() != productor_contexto.correo)
                productor_request.correo = tb_correo.Text.Trim();

            productor_request.habilitado = check_habilitar.IsChecked == true ? 1 : 0;

            int response = ProductorService.actualizarProductor(productor_request);

            if (response == -1)
            {
                string mensaje = "No se pudo actualizar el productor, favor revise los datos ingresados.";
                string titulo = "Error";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Error;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                return;
            }
            if (response > 0)
            {

                string mensaje = "Productor actualizado correctamente.";
                string titulo = "Información";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Information;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                cambiar_estado_textblock(false);
                reset_ui_textblock();
                txt_buscar_correo.Focus();
                ventanVistaProductorAnterior.actualizar_tabla_datos_productor();
                this.Close();
                return;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
