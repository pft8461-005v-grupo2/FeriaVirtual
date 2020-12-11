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
    public static class SubastaService
    {
        public static List<Subasta> consultarSubasta()
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.subasta_consultar, Method.POST);


            string data = JsonConvert.SerializeObject(new Subasta());
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            List<Subasta> lista_subasta_response = JsonConvert.DeserializeObject<List<Subasta>>(response.Content);


            return lista_subasta_response != null ? lista_subasta_response : new List<Subasta>(); ;
        }

        public static List<Subasta> consultarSubasta(Subasta subasta)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.subasta_consultar, Method.POST);


            string data = JsonConvert.SerializeObject(subasta);
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            List<Subasta> lista_subasta_response = JsonConvert.DeserializeObject<List<Subasta>>(response.Content);


            return lista_subasta_response != null ? lista_subasta_response : new List<Subasta>(); ;
        }

        public static int? iniciarSubastaInter(Subasta subasta)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.procesoSubasta_inter_iniciar, Method.POST);

            string data = JsonConvert.SerializeObject(subasta);
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            int? response_object = JsonConvert.DeserializeObject<int?>(response.Content);

            return response_object;

        }


    }
}
