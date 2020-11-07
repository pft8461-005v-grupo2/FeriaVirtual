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
    /// Lógica de interacción para CrearProductor.xaml
    /// </summary>
    public partial class CrearProductor : Window
    {
        public CrearProductor()
        {
            InitializeComponent();
        }

      

       

        private void btn_crear_productor_Click(object sender, RoutedEventArgs e)
        {
            Productor productor = new Productor();

            productor.rut = txt_rut.Text;
            productor.razonsocial = txt_razon_social.Text;
            productor.direccion = txt_direccion.Text;
            productor.comuna = txt_comuna.Text;
            productor.correo = txt_correo.Text;

            int id_usuario_creado = -1;

            id_usuario_creado = UsuarioService.crearUsuario(Parametros.ROLE_PRODUCTOR, productor.correo, productor.rut);


            int id_transportista_creado = 0;

            if (id_usuario_creado != -1)
            {
                productor.usuario_id = id_usuario_creado;
                id_transportista_creado = ProductorService.crearProductor(productor);
            }


            if (id_usuario_creado != -1)
            {
                string mensaje = "productor ingresado correctamente.";
                string titulo = "Información";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Information;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                return;
            }
        }

       

        private void Btn_Cerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
