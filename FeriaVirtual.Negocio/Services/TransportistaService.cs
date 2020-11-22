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

        public static List<Transportista> consultarTransportistas(Transportista transportista)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.transportista_consultar, Method.POST);


            string data = JsonConvert.SerializeObject(transportista);
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            List<Transportista> lista_transportista_response = JsonConvert.DeserializeObject<List<Transportista>>(response.Content);


            return lista_transportista_response != null ? lista_transportista_response : new List<Transportista>(); ;
        }

        public static int crearTransportista(Transportista transportista)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.transportista_crear, Method.POST);

            string data = JsonConvert.SerializeObject(transportista);
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            ResponseObject response_object = JsonConvert.DeserializeObject<ResponseObject>(response.Content);


            if (response_object != null)
                if (response_object.OUT_ESTADO == 0)
                    return response_object.OUT_ID_SALIDA;
                else
                    return -1;
            else
                return -1;

        }

        public static int actualizarTransportista(Transportista transportista)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.transportista_actualizar, Method.POST);

            string data = JsonConvert.SerializeObject(transportista);
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            ResponseObject response_object = JsonConvert.DeserializeObject<ResponseObject>(response.Content);


            if (response_object != null)
                if (response_object.OUT_ESTADO == 0)
                    return response_object.OUT_ID_SALIDA;
                else
                    return -1;
            else
                return -1;

        }
    }
}
