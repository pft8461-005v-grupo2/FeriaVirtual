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
    /// Lógica de interacción para Cliente.xaml
    /// </summary>
    
    public partial class VistaCliente : Page
    {
        
        public VistaCliente()
        {
            InitializeComponent();
            actualizar_tabla_datos_cliente();
        }


        private void btn_crearCliente_Click(object sender, RoutedEventArgs e)
        {
            CrearCliente crearCliente = new CrearCliente(this);
            crearCliente.Show();
        }

        private void btn_edtitarCliente_Click(object sender, RoutedEventArgs e)
        {
            EditarCliente editarCliente = new EditarCliente(this);
            editarCliente.Show();
        }


        public void actualizar_tabla_datos_cliente()
        {
            List<Cliente> lista_obtenida =  ClienteService.consultarCliente();


            DataTable tabla_con_datos = new DataTable();
            //int c = 0;

            tabla_con_datos.TableName = "Lista de clientes";
            tabla_con_datos.Columns.Add("ID");
            tabla_con_datos.Columns.Add("USUARIO_ID");
            tabla_con_datos.Columns.Add("IDENTIFICADOR");
            tabla_con_datos.Columns.Add("RAZONSOCIAL");
            tabla_con_datos.Columns.Add("DIRECCION");
            tabla_con_datos.Columns.Add("CIUDAD");
            tabla_con_datos.Columns.Add("PAIS_ORIGEN");
            tabla_con_datos.Columns.Add("TIPO_CLIENTE");
            tabla_con_datos.Columns.Add("CORREO");
            tabla_con_datos.Columns.Add("HABILITADO");


            for (int i = 0; i < lista_obtenida.Count; i++)
            {

                Button boton = new Button();
                boton.Content = "Editar";
               

                tabla_con_datos.Rows.Add(

                    lista_obtenida[i].id,
                    lista_obtenida[i].usuario_id,
                    lista_obtenida[i].identificador,
                    lista_obtenida[i].razonSocial,
                    lista_obtenida[i].direccion,
                    lista_obtenida[i].ciudad,
                    lista_obtenida[i].pais_origen,
                    lista_obtenida[i].tipo_cliente,
                    lista_obtenida[i].correo,
                    lista_obtenida[i].habilitado
                    );
            }






            data_clientes.ItemsSource = tabla_con_datos.AsDataView();
           


        }

        private void btn_refrescar_Click(object sender, RoutedEventArgs e)
        {

            actualizar_tabla_datos_cliente();

        }
    }
}
