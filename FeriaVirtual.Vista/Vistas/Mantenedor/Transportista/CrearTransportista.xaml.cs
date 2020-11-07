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

namespace FeriaVirtual.Vista.Vistas.Mantenedor
{
    /// <summary>
    /// Lógica de interacción para CrearTransportista.xaml
    /// </summary>
    public partial class CrearTransportista : Window
    {
        public CrearTransportista()
        {
            InitializeComponent();
        }

       

        private void btn_crear_transportista_Click(object sender, RoutedEventArgs e)
        {

            Transportista transportista = new Transportista();

            transportista.rut = txt_rut.Text;
            transportista.razonsocial = txt_razonSocial.Text;
            transportista.direccion = txt_direccion.Text;
            transportista.comuna = txt_comuna.Text;
            transportista.correo = txt_correo.Text;

            int id_usuario_creado = -1;

            id_usuario_creado = UsuarioService.crearUsuario(Parametros.ROLE_TRANSPORTISTA, transportista.correo, transportista.rut);


            int id_transportista_creado = 0;

            if (id_usuario_creado != -1)
            {
                transportista.usuario_id = id_usuario_creado;
                id_transportista_creado = TransportistaService.crearTransportista(transportista);
            }


            if (id_usuario_creado != -1)
            {
                string mensaje = "transportista ingresado correctamente.";
                string titulo = "Información";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Information;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                return;
            }

        }



    }
}
