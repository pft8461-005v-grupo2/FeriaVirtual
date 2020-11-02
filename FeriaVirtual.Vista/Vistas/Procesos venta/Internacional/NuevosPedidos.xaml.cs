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

namespace FeriaVirtual.Vista.Vistas.Procesos_venta.Internacional
{
    /// <summary>
    /// Lógica de interacción para NuevosPedidos.xaml
    /// </summary>
    public partial class NuevosPedidos : Window
    {
        public NuevosPedidos()
        {
            InitializeComponent();
        }

        private void btn_ver_detalle_Click(object sender, RoutedEventArgs e)
        {
            DetalleNuevosPedidos detalleNuevoP = new DetalleNuevosPedidos();
            detalleNuevoP.Show();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
