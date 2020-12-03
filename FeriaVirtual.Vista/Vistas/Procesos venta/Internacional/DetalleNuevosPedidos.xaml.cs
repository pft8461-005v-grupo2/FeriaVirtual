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
    /// Lógica de interacción para DetalleNuevosPedidos.xaml
    /// </summary>
    public partial class DetalleNuevosPedidos : Window
    {
        public DetalleNuevosPedidos(DataRowView dataRowView)
        {
            InitializeComponent();

            if (dataRowView != null)
            {
                Cliente cliente = new Cliente();
                cliente.id = Int32.Parse(dataRowView.Row["cliente_id"] as string);
                List<Cliente> listaCliente = ClienteService.consultarCliente(cliente);

                Solicitud_compra solicitud_Compra = new Solicitud_compra();
                solicitud_Compra.id = Int32.Parse(dataRowView.Row["id"] as string);
                List<Solicitud_compra> lista_obtenida = Solicitud_compraService.solicitud_Compras(solicitud_Compra);

                if (listaCliente != null && listaCliente.Count == 1)

                {
                    cliente = listaCliente[0];
                    solicitud_Compra = lista_obtenida[0];
;
                   
                    
                    txt_id.Text = cliente.id.ToString();
                    txt_razonSocial.Text = cliente.razonSocial;
                    txt_identificador.Text = cliente.identificador;
                    txt_direccion.Text = cliente.direccion;
                    txt_pais.Text = cliente.pais_origen;
                    txt_correo.Text = cliente.correo;
                    txt_producto.Text = solicitud_Compra.producto;
                    txt_kilogramos.Text = solicitud_Compra.kilogramos.ToString();
                  
                }
                
            }


        }
   

        private void Btn_generaProcesoVenta_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
