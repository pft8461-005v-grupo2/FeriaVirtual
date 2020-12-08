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
    public static class ProductoService
    {
        public static List<Producto> consultarProducto()
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.producto_consultar, Method.POST);


            string data = JsonConvert.SerializeObject(new Producto());
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            List<Producto> lista_producto_response = JsonConvert.DeserializeObject<List<Producto>>(response.Content);


            return lista_producto_response != null ? lista_producto_response : new List<Producto>(); ;
        }

        public static List<Producto> consultarProducto( Producto producto)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.producto_consultar, Method.POST);


            string data = JsonConvert.SerializeObject(producto);
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            List<Producto> lista_producto_response = JsonConvert.DeserializeObject<List<Producto>>(response.Content);


            return lista_producto_response != null ? lista_producto_response : new List<Producto>(); ;
        }

        public static int crearProducto(Producto producto)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.productos_crear, Method.POST);

            string data = JsonConvert.SerializeObject(producto);
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


        public static int actualizarProducto(Producto producto)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.producto_actualizar, Method.POST);

            string data = JsonConvert.SerializeObject(producto);
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
