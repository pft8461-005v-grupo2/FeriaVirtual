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
    public static class StockDisponibleService
    {
        public static List<StockDisponible> stockDisponibles_consultar()
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.stock_disponible_iniciar, Method.POST);


            string data = JsonConvert.SerializeObject(new Solicitud_compra());
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            List<StockDisponible> lista_StockDisponible = JsonConvert.DeserializeObject<List<StockDisponible>>(response.Content);


            return lista_StockDisponible != null ? lista_StockDisponible : new List<StockDisponible>(); ;
        }
    }
}
