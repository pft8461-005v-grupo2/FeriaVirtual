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
using System.Windows.Shapes;

namespace FeriaVirtual.Vista.Vistas.Procesos_venta.Internacional
{
    /// <summary>
    /// Lógica de interacción para DetalleVentaDespachar.xaml
    /// </summary>
    public partial class DetalleVentaDespachar : Window
    {
        VentaDespachar ventanaVentaDespacharAnterior = null;
        public DetalleVentaDespachar( DataRowView dataRowView, VentaDespachar ventanaVentaDespachar)
        {
            InitializeComponent();

            if (ventanaVentaDespachar!=null) {

                ventanaVentaDespacharAnterior = ventanaVentaDespachar;
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

       

        private void Btn_enviar_despacho_Click(object sender, RoutedEventArgs e)
        {
            ProcesoVenta procesoVenta = new ProcesoVenta();
            procesoVenta.id = Int32.Parse(txt_id.Text);
            List<ProcesoVenta> listaProcesoVenta = ProcesoVentaService.consultar_ProcesoVenta(procesoVenta);

            if (listaProcesoVenta != null)

            {
                procesoVenta = listaProcesoVenta[0];


                procesoVenta.etapa = 8;

                int response = ProcesoVentaService.actualizarProcesoVenta(procesoVenta);

                if (response == -1)
                {

                    string mensaje = "No se pudo actualizar ";
                    string titulo = "Error";
                    MessageBoxButton tipo = MessageBoxButton.OK;
                    MessageBoxImage icono = MessageBoxImage.Error;
                    MessageBox.Show(mensaje, titulo, tipo, icono);
                    return;

                }

                if (response > 0)
                {

                    string mensaje = "actualizado correctamente.";
                    string titulo = "Información";
                    MessageBoxButton tipo = MessageBoxButton.OK;
                    MessageBoxImage icono = MessageBoxImage.Information;
                    MessageBox.Show(mensaje, titulo, tipo, icono);
                    ventanaVentaDespacharAnterior.actualizar_tabla_datos_procesoVenta();
                    this.Close();
                    return;

                }

            }
        }
    }
}
