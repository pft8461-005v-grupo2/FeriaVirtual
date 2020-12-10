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
    /// Lógica de interacción para EditarTransportista.xaml
    /// </summary>
    public partial class EditarTransportista : Window
    {
        Usuario usuario_contexto = new Usuario();
        Transportista transportistaContexto = new Transportista();
        VistaTransportista VentanaVistaTransportistaAnterior = null;
        public EditarTransportista(VistaTransportista VentaVistaTransportista)
        {
            InitializeComponent();
            if (VentaVistaTransportista != null)
            {
                VentanaVistaTransportistaAnterior = VentaVistaTransportista;
            }
        }

        private void btn_buscar_transportista_Click(object sender, RoutedEventArgs e)
        {
            if (txt_buscar_correo.Text.Trim().Length == 0)
            {
                string mensaje = "Debe ingresar un identificador de Transportista para buscar.";
                string titulo = "Información";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Information;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                cambiar_estado_textblock(false);
                reset_ui_textblock();
                txt_buscar_correo.Focus();
                return;
            }

            Transportista transportista = new Transportista();
            transportista.correo = txt_buscar_correo.Text.Trim();

            List<Transportista> lista_transportista_resultado = TransportistaService.consultarTransportistas(transportista);

            if (lista_transportista_resultado.Count == 0)
            {
                string mensaje = "No se encontró el Transportista con ese correo.";
                string titulo = "Error";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Error;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                cambiar_estado_textblock(false);
                reset_ui_textblock();
                txt_buscar_correo.Focus();
                return;
            }

            if (lista_transportista_resultado.Count > 1)
            {
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

            if (lista_transportista_resultado.Count == 1)
            {

                Transportista transportista_response = lista_transportista_resultado[0];

                Usuario usuario_request = new Usuario();
                usuario_request.id = transportista_response.usuario_id;

                List<Usuario> lista_usuario_response = UsuarioService.consultarUsuario(usuario_request);

                if (lista_usuario_response.Count == 0)
                {
                    string mensaje = "No existe un usuario enlazado al Transportista, favor contactar al administrador.";
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
                    tb_rut.Text = transportista_response.rut;
                    tb_razon_social.Text = transportista_response.razonsocial;
                    tb_direccion.Text = transportista_response.direccion;
                    tb_comuna.Text = transportista_response.comuna;
                    tb_correo.Text = transportista_response.correo;



                    if (transportista_response.habilitado == 1)
                    {
                        check_habilitar.IsChecked = true;
                        check_deshabilitar.IsChecked = false;
                    }
                    if (transportista_response.habilitado == 0)
                    {
                        check_habilitar.IsChecked = false;
                        check_deshabilitar.IsChecked = true;
                    }

                    transportistaContexto = transportista_response;


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
            btn_guardar_editar .IsEnabled = habilitar;

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
            transportistaContexto = new Transportista();
        }

        private void btn_guardar_editar_Click(object sender, RoutedEventArgs e)
        {
            Transportista transportista_request = new Transportista();
            transportista_request.id = transportistaContexto.id;

            if (tb_rut.Text.Trim() != transportistaContexto.rut)
                transportista_request.rut = tb_rut.Text.Trim();
            if (tb_razon_social.Text.Trim() != transportistaContexto.razonsocial)
                transportista_request.razonsocial = tb_razon_social.Text.Trim();
            if (tb_direccion.Text.Trim() != transportistaContexto.direccion)
                transportista_request.direccion = tb_direccion.Text.Trim();
            if (tb_comuna.Text.Trim() != transportistaContexto.comuna)
                transportista_request.comuna = tb_comuna.Text.Trim();
            if (tb_correo.Text.Trim() != transportistaContexto.correo)
                transportista_request.correo = tb_correo.Text.Trim();

            transportista_request.habilitado = check_habilitar.IsChecked == true ? 1 : 0;

            int response = TransportistaService.actualizarTransportista(transportista_request);


            if (response == -1)
            {
                string mensaje = "No se pudo actualizar el Transportista, favor revise los datos ingresados.";
                string titulo = "Error";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Error;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                return;
            }
            if (response > 0)
            {

                string mensaje = "Transportista actualizado correctamente.";
                string titulo = "Información";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Information;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                cambiar_estado_textblock(false);
                reset_ui_textblock();
                txt_buscar_correo.Focus();
                VentanaVistaTransportistaAnterior.actualizar_tabla_datos_transportista();
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
