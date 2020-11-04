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
    /// Lógica de interacción para Productor.xaml
    /// </summary>
    public partial class Productor : Page
    {
        public Productor()
        {
            InitializeComponent();
        }

       

        private void btn_crearProductor_Click(object sender, RoutedEventArgs e)
        {
            CrearProductor crearProductor = new CrearProductor();
            crearProductor.Show();
        }


        private void btn_editarProductor_Click(object sender, RoutedEventArgs e)
        {
            EditarProductor editarProductor = new EditarProductor();
            editarProductor.Show();
        }
    }
}
