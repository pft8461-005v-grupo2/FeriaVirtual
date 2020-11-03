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

namespace FeriaVirtual.Vista.Vistas.Mantenedor
{
    /// <summary>
    /// Lógica de interacción para ransportista.xaml
    /// </summary>
    public partial class Transportista : Page
    {
        public Transportista()
        {
            InitializeComponent();
        }

        private void btn_crearTransportista_Click(object sender, RoutedEventArgs e)
        {
            CrearTransportista crearTransportista = new CrearTransportista();
            crearTransportista.Show();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
