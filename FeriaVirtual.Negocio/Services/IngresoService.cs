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
    public static class IngresoService
    {
        public static int? iniciarIngreso(Ingreso ingreso)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.procesoNacional_iniciar, Method.POST);

            string data = JsonConvert.SerializeObject(ingreso);
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            int? response_object = JsonConvert.DeserializeObject<int?>(response.Content);

            return response_object;

        }

        public static List<Ingreso> consultarIngreso()
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.ingreso_consultar, Method.POST);


            string data = JsonConvert.SerializeObject(new Ingreso());
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            List<Ingreso> lista_ingreso_response = JsonConvert.DeserializeObject<List<Ingreso>>(response.Content);


            return lista_ingreso_response != null ? lista_ingreso_response : new List<Ingreso>(); ;
        }
    }
}
