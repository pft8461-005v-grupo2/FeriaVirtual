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
using FeriaVirtual.Negocio.Models;
using FeriaVirtual.Negocio.Services;

namespace FeriaVirtual.Vista.Vistas.Mantenedor
{
    /// <summary>
    /// Lógica de interacción para Productor.xaml
    /// </summary>
    public partial class VistaProductor : Page
    {
        public VistaProductor()
        {
            InitializeComponent();
            actualizar_tabla_datos_productor();
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

        public void actualizar_tabla_datos_productor()
        {
            List<Productor> lista_obtenida = ProductorService.consultarProductor();


            DataTable tabla_con_datos = new DataTable();
            //int c = 0;

            tabla_con_datos.TableName = "Lista de Productores";
            tabla_con_datos.Columns.Add("ID");
            tabla_con_datos.Columns.Add("USUARIO_ID");
            //tabla_con_datos.Columns.Add("CONTRATO_ID");
            tabla_con_datos.Columns.Add("RUT");
            tabla_con_datos.Columns.Add("RAZONSOCIAL");
            tabla_con_datos.Columns.Add("DIRECCION");
            tabla_con_datos.Columns.Add("COMUNA");
            tabla_con_datos.Columns.Add("CORREO");
            tabla_con_datos.Columns.Add("HABILITADO");
            //tabla_con_datos.Columns.Add("ACCION");


            for (int i = 0; i < lista_obtenida.Count; i++)
            {
                tabla_con_datos.Rows.Add(

                    lista_obtenida[i].id,
                    lista_obtenida[i].usuario_id,
                    //lista_obtenida[i].contrato_id,
                    lista_obtenida[i].rut,
                    lista_obtenida[i].razonsocial,
                    lista_obtenida[i].direccion,
                    lista_obtenida[i].comuna,
                    lista_obtenida[i].correo,
                    lista_obtenida[i].habilitado

                    );
            }


            data_productores.ItemsSource = tabla_con_datos.AsDataView();



        }

     

        private void Btn_refrescar_Click(object sender, RoutedEventArgs e)
        {
            actualizar_tabla_datos_productor();
        }
    }
}
