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
    public static class TransportistaService
    {
        public static List<Transportista> consultarTransportistas()
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.transportista_consultar, Method.POST);


            string data = JsonConvert.SerializeObject(new Transportista());
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            List<Transportista> lista_transportista_response = JsonConvert.DeserializeObject<List<Transportista>>(response.Content);


            return lista_transportista_response != null ? lista_transportista_response : new List<Transportista>(); ;
        }
    }
}
