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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FeriaVirtual.Vista.Vistas.Procesos_venta.Internacional
{
    /// <summary>
    /// Lógica de interacción para AcuerdosPendientes.xaml
    /// </summary>
    public partial class AcuerdosPendientes : Page
    {
        public AcuerdosPendientes()
        {
            InitializeComponent();
            actualizar_tabla_datos_procesoVenta();
        }


        public void actualizar_tabla_datos_procesoVenta()
        {
            List<ProcesoVenta> lista_obtenida = ProcesoVentaService.consultar_ProcesoVenta();

            DataTable tabla_con_datos = new DataTable();
            //int c = 0;

            tabla_con_datos.TableName = "Lista de pedidos";
            tabla_con_datos.Columns.Add("id");
            tabla_con_datos.Columns.Add("solicitud_compra_id");
            tabla_con_datos.Columns.Add("subasta_id");
            tabla_con_datos.Columns.Add("etapa");
            tabla_con_datos.Columns.Add("fechacreacion");
            tabla_con_datos.Columns.Add("clienteaceptaacuerdo");
            tabla_con_datos.Columns.Add("precioventatotal");
            tabla_con_datos.Columns.Add("preciocostototal");


            for (int i = 0; i < lista_obtenida.Count; i++)
            {
                if (lista_obtenida[i].etapa == 2) {
                    tabla_con_datos.Rows.Add(

                    lista_obtenida[i].id,
                    lista_obtenida[i].solicitud_compra_id,
                    lista_obtenida[i].subasta_id,
                    lista_obtenida[i].etapa,
                    lista_obtenida[i].fechacreacion,
                    lista_obtenida[i].clienteaceptaacuerdo,
                    lista_obtenida[i].precioventatotal,
                    lista_obtenida[i].preciocostototal

                    );
                };

                
            }


            data_AcuerdosPendientes.ItemsSource = tabla_con_datos.AsDataView();

        }

        private void Btn_ver_detalle_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = data_AcuerdosPendientes.SelectedItem as DataRowView;
            DetalleAcuerdoPendiente detalleAcuerdoPendiente = new DetalleAcuerdoPendiente(dataRowView);
            detalleAcuerdoPendiente.Show();
        }
    }
}
