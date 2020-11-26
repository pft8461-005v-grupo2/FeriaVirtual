using FeriaVirtual.Negocio.Models;
using FeriaVirtual.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para DetalleNuevosPedidos.xaml
    /// </summary>
    public partial class DetalleNuevosPedidos : Window
    {
        public DetalleNuevosPedidos(DataRowView dataRowView)
        {
            InitializeComponent();

            if (dataRowView != null)
            {
                Cliente cliente = new Cliente();
                cliente.id = Int32.Parse(dataRowView.Row["cliente_id"] as string);
                List<Cliente> listaCliente = ClienteService.consultarCliente(cliente);

                if(listaCliente != null && listaCliente.Count == 1)
                {
                    cliente = listaCliente[0];
                    txt_id.Text = cliente.id.ToString();
                    txt_razonSocial.Text = cliente.razonSocial;
                }
                
            }


        }
   

        private void Btn_generaProcesoVenta_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
