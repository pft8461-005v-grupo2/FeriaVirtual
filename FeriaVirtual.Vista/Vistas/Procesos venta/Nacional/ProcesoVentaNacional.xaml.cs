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

namespace FeriaVirtual.Vista.Vistas.Procesos_venta.Nacional
{
    /// <summary>
    /// Lógica de interacción para ProcesoVentaNacional.xaml
    /// </summary>
    public partial class ProcesoVentaNacional : Page
    {
        public ProcesoVentaNacional()
        {
            InitializeComponent();
        }

        private void Btn_generar_pedidosNacional_Click(object sender, RoutedEventArgs e)
        {
            PedidoNacional pedidoNacional = new PedidoNacional();
            pedidoNacional.Show();
        }

        

        private void Btn_detalleProcesoNacional_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
