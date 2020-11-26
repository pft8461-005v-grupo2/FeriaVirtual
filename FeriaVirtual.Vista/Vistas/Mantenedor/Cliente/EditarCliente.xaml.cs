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
    /// Lógica de interacción para EditarCliente.xaml
    /// </summary>
    public partial class EditarCliente : Window
    {

        Usuario usuario_contexto = new Usuario();
        Cliente cliente_contexto = new Cliente();

        public EditarCliente()
        {
            InitializeComponent();

            Dictionary<int, string> tipos_de_clientes = new Dictionary<int, string>();
            tipos_de_clientes.Add(1, "Internacional");
            tipos_de_clientes.Add(2, "Nacional");
            cbx_tipo_cliente.ItemsSource = tipos_de_clientes;


        }

        private void btn_buscar_cliente_Click(object sender, RoutedEventArgs e)
        {
            if(txt_buscar_correo.Text.Trim().Length == 0)
            {
                string mensaje = "Debe ingresar un identificador de cliente para buscar.";
                string titulo = "Información";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Information;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                cambiar_estado_textblock(false);
                reset_ui_textblock();
                txt_buscar_correo.Focus();
                return;
            }

            Cliente cliente = new Cliente();
            cliente.correo = txt_buscar_correo.Text.Trim();

            List<Cliente> lista_cliente_resultado = ClienteService.consultarCliente(cliente);

            if(lista_cliente_resultado.Count == 0)
            {
                string mensaje = "No se encontró el cliente con ese correo.";
                string titulo = "Error";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Error;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                cambiar_estado_textblock(false);
                reset_ui_textblock();
                txt_buscar_correo.Focus();
                return;
            }

            if (lista_cliente_resultado.Count > 1)
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


            if(lista_cliente_resultado.Count == 1)
            {

                Cliente cliente_response = lista_cliente_resultado[0];


                Usuario usuario_request = new Usuario();
                usuario_request.id = cliente_response.usuario_id;

                List<Usuario> lista_usuario_response = UsuarioService.consultarUsuario(usuario_request);

                if(lista_usuario_response.Count == 0) {
                    string mensaje = "No existe un usuario enlazado al cliente, favor contactar al administrador.";
                    string titulo = "Error";
                    MessageBoxButton tipo = MessageBoxButton.OK;
                    MessageBoxImage icono = MessageBoxImage.Error;
                    MessageBox.Show(mensaje, titulo, tipo, icono);
                    cambiar_estado_textblock(false);
                    reset_ui_textblock();
                    txt_buscar_correo.Focus();
                    return;
                }


                if(lista_usuario_response.Count == 1)
                {
                    cambiar_estado_textblock(true);

                    usuario_contexto = lista_usuario_response[0];
                    tb_identificador.Text = cliente_response.identificador;
                    tb_razonsocial.Text = cliente_response.razonSocial;
                    tb_direccion.Text = cliente_response.direccion;
                    tb_ciudad.Text = cliente_response.ciudad;
                    tb_pais_origen.Text = cliente_response.pais_origen;
                    tb_correo.Text = cliente_response.correo;
                    cbx_tipo_cliente.SelectedValue = cliente_response.tipo_cliente;


                    if(cliente_response.habilitado == 1)
                    {
                        check_habilitar.IsChecked = true;
                        check_deshabilitar.IsChecked = false;
                    }
                    if(cliente_response.habilitado == 0)
                    {
                        check_habilitar.IsChecked = false;
                        check_deshabilitar.IsChecked = true;
                    }

                    cliente_contexto = cliente_response;

                    
                }
            }



        }

        public void cambiar_estado_textblock(Boolean habilitar)
        {
            tb_identificador.IsEnabled = habilitar;
            tb_razonsocial.IsEnabled = habilitar;
            tb_direccion.IsEnabled = habilitar;
            tb_ciudad.IsEnabled = habilitar;
            tb_pais_origen.IsEnabled = habilitar;
            tb_correo.IsEnabled = habilitar;
            //tb_contrasena.IsEnabled = habilitar;
            check_habilitar.IsEnabled = habilitar;
            check_deshabilitar.IsEnabled = habilitar;
            btn_guardar.IsEnabled = habilitar;
            cbx_tipo_cliente.IsEnabled = habilitar;
            check_deshabilitar.IsEnabled = habilitar;
            check_habilitar.IsEnabled = habilitar;

        }

        public void reset_ui_textblock()
        {
            tb_identificador.Text = String.Empty;
            tb_razonsocial.Text = String.Empty;
            tb_direccion.Text = String.Empty;
            tb_ciudad.Text = String.Empty;
            tb_pais_origen.Text = String.Empty;
            tb_correo.Text = String.Empty;
            //tb_contrasena.Text = String.Empty;
            cbx_tipo_cliente.SelectedValue = -1;
            check_habilitar.IsChecked = false;
            check_deshabilitar.IsChecked = false;
            usuario_contexto = new Usuario();
            cliente_contexto = new Cliente();
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            // Validar campos vacios


            Cliente cliente_request = new Cliente();

            cliente_request.id = cliente_contexto.id;

            if(tb_identificador.Text.Trim() != cliente_contexto.identificador)
                cliente_request.identificador = tb_identificador.Text.Trim();
            if(tb_razonsocial.Text.Trim() != cliente_contexto.razonSocial)
                cliente_request.razonSocial = tb_razonsocial.Text.Trim();
            if(tb_direccion.Text.Trim() != cliente_contexto.direccion)
                cliente_request.direccion = tb_direccion.Text.Trim();
            if(tb_ciudad.Text.Trim() != cliente_contexto.ciudad)
                cliente_request.ciudad = tb_ciudad.Text.Trim();
            if(tb_pais_origen.Text.Trim() != cliente_contexto.pais_origen)
                cliente_request.pais_origen = tb_pais_origen.Text.Trim();
            if(tb_correo.Text.Trim() != cliente_contexto.correo)
                cliente_request.correo = tb_correo.Text.Trim();

            cliente_request.tipo_cliente = int.Parse(cbx_tipo_cliente.SelectedValue.ToString());
            cliente_request.habilitado = check_habilitar.IsChecked == true ? 1 : 0;


            int response = ClienteService.actualizarCliente(cliente_request);

            if(response == -1) {
                string mensaje = "No se pudo actualizar el cliente, favor revise los datos ingresados.";
                string titulo = "Error";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Error;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                return;
            }

            if(response > 0)
            {


                string mensaje = "Cliente actualizado correctamente.";
                string titulo = "Información";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Information;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                cambiar_estado_textblock(false);
                reset_ui_textblock();
                txt_buscar_correo.Focus();
                return;
            }




    

            





        }
    }
}
