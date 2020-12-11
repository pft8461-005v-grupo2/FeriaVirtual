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

namespace FeriaVirtual.Vista.Vistas.Procesos_venta.Nacional
{
    /// <summary>
    /// Lógica de interacción para DetalleStockDisponible.xaml
    /// </summary>
    public partial class DetalleStockDisponible : Window
    {
        VistaStockDisponible VentanaVistaStockDisponibleAnterior = null;
        public DetalleStockDisponible(DataRowView dataRowView, VistaStockDisponible vistaStockDisponible)
        {
            InitializeComponent();

            if (vistaStockDisponible != null)
            {
                VentanaVistaStockDisponibleAnterior = vistaStockDisponible;
            }

            if (dataRowView != null) 
            {
                int? ingresoID = Int32.Parse(dataRowView.Row["ingreso_id"] as string);
                List<StockDisponible> listaStockDisponibles = StockDisponibleService.stockDisponibles_consultar();

                foreach (StockDisponible item in listaStockDisponibles)
                {
                    if (item.ingreso_id == ingresoID) {

                        txt_ingresoID.Text = item.ingreso_id.ToString();
                        txt_productoDescripcion.Text = item.descripcion;
                        txt_kilogramos.Text = item.kilogramos.ToString();
                        txt_fechaCreacion.Text = item.fechacreacion_ingreso;
                        txt_rutProductor.Text = item.rut_productor;
                        txt_razonSocial.Text = item.razonsocial_productor;
                        txt_direccionProductor.Text = item.direccion_productor;
                        txt_comunaProductor.Text = item.comuna_productor;
                        txt_correoProductor.Text = item.correo_productor;
                    }
                }

            }
        }

        private void Btn_enviar_Click(object sender, RoutedEventArgs e)
        {

           // Retornos
           //- 1 = Error
           // 1 = Se inició proceso de venta nacional

            Ingreso ingreso = new Ingreso();
            ingreso.id = Int32.Parse(txt_ingresoID.Text);

            int? respuesta = IngresoService.iniciarIngreso(ingreso);


            String mensaje = "";
            MessageBoxImage icono = MessageBoxImage.Information;
            switch (respuesta)
            {
                case -1:
                    mensaje = "Error de sistema. Contacta con el administrador de sistema";
                    icono = MessageBoxImage.Error;
                    break;
                case 1:
                    mensaje = "Se inició proceso";
                    icono = MessageBoxImage.Information;
                    VentanaVistaStockDisponibleAnterior.actualizar_tabla_datos_stockDisponibles();
                    this.Close();
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
