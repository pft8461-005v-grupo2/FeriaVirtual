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

namespace FeriaVirtual.Vista.Vistas.Mantenedor
{
    /// <summary>
    /// Lógica de interacción para ransportista.xaml
    /// </summary>
    public partial class VistaTransportista : Page
    {
        public VistaTransportista()
        {
            InitializeComponent();
            actualizar_tabla_datos_transportista();
        }

        private void btn_crearTransportista_Click(object sender, RoutedEventArgs e)
        {
            CrearTransportista crearTransportista = new CrearTransportista();
            crearTransportista.Show();
        }

        public void actualizar_tabla_datos_transportista()
        {
            List<Transportista> lista_obtenida = TransportistaService.consultarTransportistas();
         


            DataTable tabla_con_datos = new DataTable();
            //int c = 0;

            tabla_con_datos.TableName = "Lista de Productores";
            tabla_con_datos.Columns.Add("id");
            tabla_con_datos.Columns.Add("usuario_id");
            tabla_con_datos.Columns.Add("rut");
            tabla_con_datos.Columns.Add("razonSocial");
            tabla_con_datos.Columns.Add("direccion");
            tabla_con_datos.Columns.Add("comuna");
            tabla_con_datos.Columns.Add("correo");
            tabla_con_datos.Columns.Add("habilitado");
            tabla_con_datos.Columns.Add("accion");


            for (int i = 0; i < lista_obtenida.Count; i++)
            {
                tabla_con_datos.Rows.Add(

                    lista_obtenida[i].id,
                    lista_obtenida[i].usuario_id,
                    lista_obtenida[i].rut,
                    lista_obtenida[i].razonsocial,
                    lista_obtenida[i].direccion,
                    lista_obtenida[i].comuna,
                    lista_obtenida[i].correo,
                    lista_obtenida[i].habilitado
                    );
            }






            data_transportista.ItemsSource = tabla_con_datos.AsDataView();



        }

        private void btn_editarTransportista_Click(object sender, RoutedEventArgs e)
        {
            EditarTransportista editarTransportista = new EditarTransportista();
            editarTransportista.Show();
        }

       
    }
}
