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

namespace FeriaVirtual.Vista.Vistas.Procesos_venta.Nacional
{
    /// <summary>
    /// Lógica de interacción para VistaStock.xaml
    /// </summary>
    public partial class VistaStockDisponible : Page
    {
        public VistaStockDisponible()
        {
            InitializeComponent();
            actualizar_tabla_datos_stockDisponibles();
        }

        public void actualizar_tabla_datos_stockDisponibles()
        {
            List<StockDisponible> lista_obtenida = StockDisponibleService.stockDisponibles_consultar();

            DataTable tabla_con_datos = new DataTable();

            tabla_con_datos.TableName = "Lista de Stock disponibles";
            tabla_con_datos.Columns.Add("ingreso_id");
            tabla_con_datos.Columns.Add("producto_id");
            tabla_con_datos.Columns.Add("descripcion");
            tabla_con_datos.Columns.Add("kilogramos");
            tabla_con_datos.Columns.Add("fechacreacion_ingreso");
            tabla_con_datos.Columns.Add("rut_productor");
            tabla_con_datos.Columns.Add("razonsocial_productor");

            for (int i = 0; i < lista_obtenida.Count; i++)
            {
                tabla_con_datos.Rows.Add(
                    lista_obtenida[i].ingreso_id,
                    lista_obtenida[i].productor_id,
                    lista_obtenida[i].descripcion,
                    lista_obtenida[i].kilogramos,
                    lista_obtenida[i].fechacreacion_ingreso,
                    lista_obtenida[i].rut_productor,
                    lista_obtenida[i].razonsocial_productor
                    );

                data_stock_disponible.ItemsSource = tabla_con_datos.AsDataView();
            }
        }

        private void Btn_generarProceso_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = data_stock_disponible.SelectedItem as DataRowView;
            DetalleStockDisponible detalleStockDisponible = new DetalleStockDisponible(dataRowView, this);
            detalleStockDisponible.Show();
        }
    }
}
