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
    public static class ClienteService
    {

        public static int crearCliente(Cliente cliente)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.cliente_crear, Method.POST);

            string data = JsonConvert.SerializeObject(cliente);
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


        public static int actualizarCliente(Cliente cliente)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.cliente_actualizar, Method.POST);

            string data = JsonConvert.SerializeObject(cliente);
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


        public static List<Cliente> consultarCliente()
        {

            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.cliente_consultar, Method.POST);

            string data = JsonConvert.SerializeObject(new Cliente());
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            List<Cliente> lista_cliente_response = JsonConvert.DeserializeObject<List<Cliente>>(response.Content);


            return lista_cliente_response != null ? lista_cliente_response : new List<Cliente>(); ;
        }

        public static List<Cliente> consultarCliente(Cliente cliente)
        {
            
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.cliente_consultar, Method.POST);

            string data = JsonConvert.SerializeObject(cliente);
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            List<Cliente> lista_cliente_response = JsonConvert.DeserializeObject<List<Cliente>>(response.Content);


            return lista_cliente_response != null ? lista_cliente_response : new List<Cliente>(); ;
        }
    }
}
