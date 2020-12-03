using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BCrypt.Net;
using RestSharp;
using FeriaVirtual.Negocio.Constants;
using FeriaVirtual.Negocio.Models;
using System.Collections;

namespace FeriaVirtual.Negocio.Services
{
    public class Solicitud_compraService
    {
        public static List<Solicitud_compra> solicitud_Compras()
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.solicitud_compra_consultar, Method.POST);

            string data = JsonConvert.SerializeObject(new Solicitud_compra());        
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);
                
            List<Solicitud_compra> lista_Solicitud_compra_response = JsonConvert.DeserializeObject<List<Solicitud_compra>>(response.Content);

            return lista_Solicitud_compra_response != null ? lista_Solicitud_compra_response : new List<Solicitud_compra>(); ;



        }

        public static List<Solicitud_compra> solicitud_Compras(Solicitud_compra solicitud_Compra)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.solicitud_compra_consultar, Method.POST);

         
            string data = JsonConvert.SerializeObject(solicitud_Compra);
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            List<Solicitud_compra> lista_Solicitud_compra_response = JsonConvert.DeserializeObject<List<Solicitud_compra>>(response.Content);


            return lista_Solicitud_compra_response != null ? lista_Solicitud_compra_response : new List<Solicitud_compra>(); ;
        }

       
    }
}
