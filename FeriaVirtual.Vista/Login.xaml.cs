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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FeriaVirtual.Negocio;

namespace FeriaVirtual.Vista
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txt_nombre.Focus();
        }

        private void btn_ingresar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_nombre.Text.Trim().Length == 0)
            {
                string mensaje = "Debe ingresar un correo válido, Ej: admin@feriavirtual.cl.";
                string titulo = "Información";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Information;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                txt_nombre.Focus();
                return;
            }
            if (txt_contrasena.Password.Trim().Length == 0)
            {
                string mensaje = "Contraseña inválida, favor corrobore datos de ingreso.";
                string titulo = "Información";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Information;
                MessageBox.Show(mensaje, titulo, tipo, icono);
                txt_contrasena.Focus();
                return;
            }

            if(UsuarioService.login(txt_nombre.Text.Trim(), txt_contrasena.Password.Trim()))
            {
                Principal principal = new Principal();
                principal.Show();
                this.Close();
            }
            else
            {
                string mensaje = "Correo y/o contraseña incorrecta, favor verifique sus datos de acceso.";
                string titulo = "Información";
                MessageBoxButton tipo = MessageBoxButton.OK;
                MessageBoxImage icono = MessageBoxImage.Information;
                MessageBoxResult resultado = MessageBox.Show(mensaje, titulo, tipo, icono);
                txt_contrasena.Password = string.Empty;
                txt_nombre.SelectAll();
                txt_nombre.Focus();
                return;
            }

        }

        private void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
