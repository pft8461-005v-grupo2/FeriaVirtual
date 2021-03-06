﻿using FeriaVirtual.Negocio.Constants;
using Newtonsoft.Json;
using BCrypt.Net;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeriaVirtual.Negocio.Models;

namespace FeriaVirtual.Negocio
{
    public static class UsuarioService
    {

        public static Boolean login(string correo, string contrasena)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.usuario_consultar, Method.POST);

            Usuario usuario = new Usuario();
            usuario.correo = correo;
            string data = JsonConvert.SerializeObject(usuario);
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            List<Usuario> lista_response = JsonConvert.DeserializeObject<List<Usuario>>(response.Content);


            foreach (Usuario aux in lista_response) {
                usuario = aux;
            }

            return BCrypt.Net.BCrypt.Verify(contrasena, usuario.contrasena) ? usuario.rol_id == Parametros.ROLE_ADMIN : false;

        }

        public static int crearUsuario(int rol_id, string correo, string contrasena)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.usuario_crear, Method.POST);

            Usuario usuario = new Usuario();

            usuario.rol_id = rol_id;
            usuario.correo = correo;
            usuario.contrasena = BCrypt.Net.BCrypt.HashPassword(contrasena);


            string data = JsonConvert.SerializeObject(usuario);

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


        public static int actualizarUsuario(Usuario usuario)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.usuario_crear, Method.POST);

            if(usuario.contrasena != null)
                usuario.contrasena = BCrypt.Net.BCrypt.HashPassword(usuario.contrasena);


            string data = JsonConvert.SerializeObject(usuario);

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


        public static List<Usuario> consultarUsuario(Usuario usuario)
        {
            RestClient client = new RestClient(Endpoints.SERVER);
            RestRequest request = new RestRequest(Endpoints.usuario_consultar, Method.POST);


            string data = JsonConvert.SerializeObject(usuario);
            request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            List<Usuario> lista_usuario_response = JsonConvert.DeserializeObject<List<Usuario>>(response.Content);


            return lista_usuario_response != null ? lista_usuario_response : new List<Usuario>(); ;
        }

    }
}
