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
    public class ProcesoVentaService
    {
         public static List<ProcesoVenta> consultar_ProcesoVenta()
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.procesoVenta_consultar, Method.POST);


            string data = JsonConvert.SerializeObject(new ProcesoVenta());
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

           List<ProcesoVenta> lista_ProcesoVenta_response = JsonConvert.DeserializeObject<List<ProcesoVenta>>(response.Content);


            return lista_ProcesoVenta_response != null ? lista_ProcesoVenta_response : new List<ProcesoVenta>(); ;
        }

        public static List<ProcesoVenta> consultar_ProcesoVenta(ProcesoVenta procesoVenta)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.procesoVenta_consultar, Method.POST);


            string data = JsonConvert.SerializeObject(procesoVenta);
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            List<ProcesoVenta> lista_ProcesoVenta_response = JsonConvert.DeserializeObject<List<ProcesoVenta>>(response.Content);


            return lista_ProcesoVenta_response != null ? lista_ProcesoVenta_response : new List<ProcesoVenta>(); ;
        }
    }
}
