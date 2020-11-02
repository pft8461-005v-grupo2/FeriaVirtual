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
    /// Lógica de interacción para AcuerdosPendientes.xaml
    /// </summary>
    public partial class AcuerdosPendientes : Window
    {
        public AcuerdosPendientes()
        {
            InitializeComponent();
        }

       

        private void Btn_ver_detalle_Click(object sender, RoutedEventArgs e)
        {
            DetalleAcuerdoPendiente detalle_acuerdoP = new DetalleAcuerdoPendiente();
            detalle_acuerdoP.Show();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
