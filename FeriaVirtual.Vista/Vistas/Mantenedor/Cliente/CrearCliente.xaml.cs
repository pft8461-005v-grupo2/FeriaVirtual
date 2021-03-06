﻿using System;
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
using FeriaVirtual.Negocio;
using FeriaVirtual.Negocio.Constants;
using FeriaVirtual.Negocio.Models;
using FeriaVirtual.Negocio.Services;

namespace FeriaVirtual.Vista.Vistas.Mantenedor
{
    /// <summary>
    /// Lógica de interacción para CrearCliente.xaml
    /// </summary>
    public partial class CrearCliente : Window
    {
        VistaCliente ventanaVistaClienteAnterior = null;
        public CrearCliente(VistaCliente ventanaVistaCliente)
        {
            InitializeComponent();

            if (ventanaVistaCliente != null)
            {
                ventanaVistaClienteAnterior = ventanaVistaCliente;
            }

            Dictionary<int, string> tipos_de_clientes = new Dictionary<int, string>();
            tipos_de_clientes.Add(1, "Internacional");
            tipos_de_clientes.Add(2, "Nacional");

            cbx_tipo_cliente.ItemsSource = tipos_de_clientes;
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // TODO: Validaciones

                Cliente cliente = new Cliente();

                cliente.identificador = txt_identificador.Text;
                cliente.razonSocial = txt_razonsocial.Text;
                cliente.direccion = txt_direccion.Text;
                cliente.ciudad = txt_ciudad.Text;
                cliente.pais_origen = txt_pais_origen.Text;
                cliente.tipo_cliente = int.Parse(cbx_tipo_cliente.SelectedValue.ToString());
                cliente.correo = txt_correo.Text;


                int id_usuario_creado = -1;


                // Verificar qué tipo de cliente es y se crea el usuario
                if (cliente.tipo_cliente == 1)
                {
                    id_usuario_creado = UsuarioService.crearUsuario(Parametros.ROLE_CLIENTEINT, cliente.correo, cliente.identificador);
                }

                if (cliente.tipo_cliente == 2)
                {
                    id_usuario_creado = UsuarioService.crearUsuario(Parametros.ROLE_CLIENTEEXT, cliente.correo, cliente.identificador);
                }


                int id_cliente_creado = -1;

                if (id_usuario_creado != -1)
                {
                    cliente.usuario_id = id_usuario_creado;
                    id_cliente_creado = ClienteService.crearCliente(cliente);
                }


                if (id_cliente_creado != -1)
                {
                    string mensaje = "Cliente ingresado correctamente.";
                    string titulo = "Información";
                    MessageBoxButton tipo = MessageBoxButton.OK;
                    MessageBoxImage icono = MessageBoxImage.Information;
                    MessageBox.Show(mensaje, titulo, tipo, icono);
                    ventanaVistaClienteAnterior.actualizar_tabla_datos_cliente();
                    this.Close();
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void Cerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
