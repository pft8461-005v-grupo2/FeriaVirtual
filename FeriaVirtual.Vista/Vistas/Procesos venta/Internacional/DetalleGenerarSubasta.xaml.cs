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
    /// Lógica de interacción para DetalleGenerarSubasta.xaml
    /// </summary>
    /// 
   
    public partial class DetalleGenerarSubasta : Window
    {
        private int? subastaContexto = -1;

        GenerarSubastas VentanaGenerarSubastasAnterior = null;
        public DetalleGenerarSubasta(DataRowView dataRowView, GenerarSubastas ventanaGenerarSubastas)
        {
            InitializeComponent();
            
            if (ventanaGenerarSubastas!=null) {
                VentanaGenerarSubastasAnterior = ventanaGenerarSubastas;
            }

            if (dataRowView != null)
            {

                ProcesoVenta procesoVenta = new ProcesoVenta();
                procesoVenta.id = Int32.Parse(dataRowView.Row["id"] as string);
                List<ProcesoVenta> listaProcesoVenta = ProcesoVentaService.consultar_ProcesoVenta(procesoVenta);


                Solicitud_compra solicitud_Compra = new Solicitud_compra();
                solicitud_Compra.id = Int32.Parse(dataRowView.Row["solicitud_compra_id"] as string);
                List<Solicitud_compra> lista_obtenida = Solicitud_compraService.solicitud_Compras(solicitud_Compra);

                

                int? cliente_id = (
                     from sol in lista_obtenida
                     select sol.cliente_id
                  ).First();

                Cliente cliente = new Cliente();
                cliente.id = cliente_id;

                List<Cliente> listaCliente = ClienteService.consultarCliente(cliente);

                cliente = (
                     from cli in listaCliente

                     select cli
                  ).First();



                if (listaProcesoVenta != null && listaProcesoVenta.Count == 1)

                {
                    procesoVenta = listaProcesoVenta[0];
                    solicitud_Compra = lista_obtenida[0];
                    txt_solicitud_compra.Text = solicitud_Compra.producto + " kg: " + solicitud_Compra.kilogramos;
                    txt_fechaCreacion.Text = procesoVenta.fechacreacion;
                    txt_precioVentaTotal.Text = procesoVenta.precioventatotal.ToString();
                    txt_precioCostoTotal.Text = procesoVenta.preciocostototal.ToString(); ;
                    txt_identificador.Text = cliente.identificador;
                    txt_razonSocial.Text = cliente.razonSocial;
                    txt_correo.Text = cliente.correo;
                    txt_paisOrigen.Text = cliente.pais_origen;
                    txt_id.Text = procesoVenta.id.ToString();
                    

                }

            }
        }

        private void Btn_enviar_subasta_Click(object sender, RoutedEventArgs e)
        {
            
            Subasta subasta = new Subasta();
            subasta.id= Int32.Parse(txt_id.Text);

            string selectDateAsString = dpk_fechaTermino.SelectedDate.Value.ToString("dd-MM-yyyy");

            subasta.fechatermino = dpk_fechaTermino.SelectedDate;

            
            int? respuesta = SubastaService.iniciarSubastaInter(subasta);

            String mensaje = "";
            MessageBoxImage icono = MessageBoxImage.Information;
            switch (respuesta)
            {
                case -2:
                    mensaje = "Proceso de venta esta en una etapa no habilitada para iniciar subasta";
                    icono = MessageBoxImage.Error;
                    break;
                case -1:
                    mensaje = "Error de sistema. Contacta con el administrador de sistema";
                    icono = MessageBoxImage.Error;
                    break;
                case 1:
                    mensaje = "Subasta iniciada";
                    icono = MessageBoxImage.Warning;
                    VentanaGenerarSubastasAnterior.actualizar_tabla_datos_procesoVenta();
                    this.Close();
                    break;

                default:
                    mensaje = "Error no tratado";
                    break;
            }

            string titulo = "Información";
            MessageBoxButton tipo = MessageBoxButton.OK;
            MessageBox.Show(mensaje, titulo, tipo, icono);
            this.Close();
            return;

        }
        
    }
}
