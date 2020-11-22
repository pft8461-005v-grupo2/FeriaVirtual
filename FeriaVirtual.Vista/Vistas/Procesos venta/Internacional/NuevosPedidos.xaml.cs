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
    /// Lógica de interacción para NuevosPedidos.xaml
    /// </summary>
    public partial class NuevosPedidos : Page
    {
        public NuevosPedidos()
        {
            InitializeComponent();
            actualizar_tabla_datos_NuevosPedidos();
        }

        private void btn_ver_detalle_Click(object sender, RoutedEventArgs e)
        {
            DetalleNuevosPedidos detalleNuevoP = new DetalleNuevosPedidos();
            detalleNuevoP.Show();

        }

        public void actualizar_tabla_datos_NuevosPedidos()
        {
            List<Solicitud_compra> lista_obtenida = Solicitud_compraService.solicitud_Compras();



            DataTable tabla_con_datos = new DataTable();
            //int c = 0;

            tabla_con_datos.TableName = "Lista de pedidos";
            tabla_con_datos.Columns.Add("id");
            tabla_con_datos.Columns.Add("cliente_id");
            tabla_con_datos.Columns.Add("fechacreacion");
            tabla_con_datos.Columns.Add("producto");
            tabla_con_datos.Columns.Add("kilogramos");
            tabla_con_datos.Columns.Add("habilitado");
            tabla_con_datos.Columns.Add("Acciones");
       
            //tabla_con_datos.Columns.Add("accion");


            for (int i = 0; i < lista_obtenida.Count; i++)
            {
                tabla_con_datos.Rows.Add(

                    lista_obtenida[i].id,
                    lista_obtenida[i].cliente_id,
                    lista_obtenida[i].fechacreacion,
                    lista_obtenida[i].producto,
                    lista_obtenida[i].kilogramos,
                    lista_obtenida[i].habilitado

                    );
            }


            data_NuevoPedidos.ItemsSource = tabla_con_datos.AsDataView();



        }
    }
}
