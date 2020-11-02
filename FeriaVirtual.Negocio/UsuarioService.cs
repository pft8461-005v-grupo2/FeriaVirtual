using FeriaVirtual.Negocio.Constants;
using Newtonsoft.Json;
using BCrypt.Net;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            foreach(Usuario aux in lista_response){
                usuario = aux;
            }

            return BCrypt.Net.BCrypt.Verify(contrasena, usuario.contrasena) ? usuario.rol_id == Parametros.ROLE_ADMIN : false;

        }

    }
}
    /*
     * 
   
   var response = client.Execute(request);
   Console.WriteLine(response.Content);
    */