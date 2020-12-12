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
    public static class ProcesoVentaIngresoService
    {
        public static List<ProcesoVentaIngreso> consultar_ProcesoVentaIngreso()
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.procesoVentaIngreso_consultar, Method.POST);


            string data = JsonConvert.SerializeObject(new ProcesoVentaIngreso());
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            List<ProcesoVentaIngreso> lista_ProcesoVentaIngreso_response = JsonConvert.DeserializeObject<List<ProcesoVentaIngreso>>(response.Content);


            return lista_ProcesoVentaIngreso_response != null ? lista_ProcesoVentaIngreso_response : new List<ProcesoVentaIngreso>(); ;
        }

        public static List<ProcesoVentaIngreso> consultar_ProcesoVentaIngreso(ProcesoVentaIngreso procesoVentaIngreso)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.procesoVentaIngreso_consultar, Method.POST);


            string data = JsonConvert.SerializeObject(procesoVentaIngreso);
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            List<ProcesoVentaIngreso> lista_ProcesoVentaIngreso_response = JsonConvert.DeserializeObject<List<ProcesoVentaIngreso>>(response.Content);


            return lista_ProcesoVentaIngreso_response != null ? lista_ProcesoVentaIngreso_response : new List<ProcesoVentaIngreso>(); ;
        }
    }
}
