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

namespace FeriaVirtual.Vista.Vistas.Mantenedor.Productos
{
    /// <summary>
    /// Lógica de interacción para VistaProductos.xaml
    /// </summary>
    public partial class VistaProductos : Page
    {
        public VistaProductos()
        {
            InitializeComponent();
            actualizar_tabla_datos_productos();
        }

        private void Btn_refrescar_Click(object sender, RoutedEventArgs e)
        {
            actualizar_tabla_datos_productos();
        }

        private void btn_crearProducto_Click(object sender, RoutedEventArgs e)
        {
            CrearProducto crearProducto = new CrearProducto(this);
            crearProducto.Show();
        }

        private void btn_editarProducto_Click(object sender, RoutedEventArgs e)
        {
            EditarProducto editarProducto = new EditarProducto(this);
            editarProducto.Show();
        }

        public void actualizar_tabla_datos_productos()
        {
            List<Producto> lista_obtenida = ProductoService.consultarProducto();


            DataTable tabla_con_datos = new DataTable();
   

            tabla_con_datos.TableName = "Lista de Productos";
            tabla_con_datos.Columns.Add("ID");
            tabla_con_datos.Columns.Add("DESCRIPCION");
            tabla_con_datos.Columns.Add("HABILITADO");



            for (int i = 0; i < lista_obtenida.Count; i++)
            {
                tabla_con_datos.Rows.Add(

                    lista_obtenida[i].id,
                    lista_obtenida[i].descripcion,
                    lista_obtenida[i].habilitado == 1 ? "Si" : "No"

                    );
            }


            data_productos.ItemsSource = tabla_con_datos.AsDataView();



        }
    }
}
