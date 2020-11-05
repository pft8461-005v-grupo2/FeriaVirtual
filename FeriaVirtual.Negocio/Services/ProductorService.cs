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
    public static class ProductorService
    {

        public static List<Productor> consultarProductor()
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.consultar_productor, Method.POST);


            string data = JsonConvert.SerializeObject(new Productor());
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            List<Productor> lista_productor_response = JsonConvert.DeserializeObject<List<Productor>>(response.Content);


            return lista_productor_response != null ? lista_productor_response : new List<Productor>(); ;
        }

        //public static List<Cliente> consultarCliente()
        //{
        //    RestClient client = new RestClient(Endpoints.SERVER);
        //    RestRequest request = new RestRequest(Endpoints.cliente_consultar, Method.POST);


        //    string data = JsonConvert.SerializeObject(new Cliente());
        //    request.AddJsonBody(data);

        //    IRestResponse response = client.Execute(request);

        //    List<Cliente> lista_cliente_response = JsonConvert.DeserializeObject<List<Cliente>>(response.Content);


        //    return lista_cliente_response != null ? lista_cliente_response : new List<Cliente>(); ;
        //}
    }
}
