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

        public static List<Productor> consultarProductor(Productor productor)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.consultar_productor, Method.POST);


            string data = JsonConvert.SerializeObject(productor);
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            List<Productor> lista_productor_response = JsonConvert.DeserializeObject<List<Productor>>(response.Content);


            return lista_productor_response != null ? lista_productor_response : new List<Productor>(); ;
        }

        public static int crearProductor(Productor productor)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.Productor_crear, Method.POST);

            string data = JsonConvert.SerializeObject(productor);
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

        public static int actualizarProductor(Productor productor)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.productor_actualizar, Method.POST);

            string data = JsonConvert.SerializeObject(productor);
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
