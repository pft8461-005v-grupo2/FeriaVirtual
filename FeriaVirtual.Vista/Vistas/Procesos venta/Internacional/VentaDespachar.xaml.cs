﻿using FeriaVirtual.Negocio.Models;
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
    /// Lógica de interacción para VentaDespachar.xaml
    /// </summary>
    public partial class VentaDespachar : Page
    {
        public VentaDespachar()
        {
            InitializeComponent();
            actualizar_tabla_datos_procesoVenta();
        }

        public void actualizar_tabla_datos_procesoVenta()
        {
            List<ProcesoVenta> lista_obtenida = ProcesoVentaService.consultar_ProcesoVenta();

            DataTable tabla_con_datos = new DataTable();


            tabla_con_datos.TableName = "Lista de pedidos";
            tabla_con_datos.Columns.Add("id");
            tabla_con_datos.Columns.Add("identificador");
            tabla_con_datos.Columns.Add("razonsocial");
            tabla_con_datos.Columns.Add("producto");
            tabla_con_datos.Columns.Add("solicitud_compra_id");
            tabla_con_datos.Columns.Add("subasta_id");
            tabla_con_datos.Columns.Add("etapa");
            tabla_con_datos.Columns.Add("fechacreacion");
            tabla_con_datos.Columns.Add("clienteaceptaacuerdo");
            tabla_con_datos.Columns.Add("precioventatotal");
            tabla_con_datos.Columns.Add("preciocostototal");

            Solicitud_compra solicitud_Compra = new Solicitud_compra();
            List<Solicitud_compra> listaSolicitudCompra = Solicitud_compraService.solicitud_Compras(solicitud_Compra);

            for (int i = 0; i < lista_obtenida.Count; i++)
            {
                if (lista_obtenida[i].solicitud_compra_id != null)
                {

                    int? cliente_id = (from sol in listaSolicitudCompra
                                       where sol.id == lista_obtenida[i].solicitud_compra_id
                                       select sol.cliente_id).First();

                    Cliente cliente = new Cliente();
                    cliente.id = cliente_id;

                    List<Cliente> listaCliente = ClienteService.consultarCliente(cliente);

                    cliente = (
                         from cli in listaCliente

                         select cli
                      ).First();

                    Solicitud_compra solicitudCompraABuscar = new Solicitud_compra();
                    solicitudCompraABuscar.id = lista_obtenida[i].solicitud_compra_id;
                    List<Solicitud_compra> lista_solicitudCompra = Solicitud_compraService.solicitud_Compras(solicitudCompraABuscar);

                    Solicitud_compra solicitudCompraEncontrado = (
                        from sc in lista_solicitudCompra
                        select sc
                        ).First();

                    if (lista_obtenida[i].etapa == 7)
                    {

                        tabla_con_datos.Rows.Add(

                        lista_obtenida[i].id,
                        cliente.identificador,
                        cliente.razonSocial,
                        solicitudCompraEncontrado.producto,
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
                    data_VentaDespacho.ItemsSource = tabla_con_datos.AsDataView();
                
            }

        }

        private void Btn_ver_detalle_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = data_VentaDespacho.SelectedItem as DataRowView;
            DetalleVentaDespachar detalleVentaDespachar = new DetalleVentaDespachar(dataRowView, this);
            detalleVentaDespachar.Show();
        }

    }
}
