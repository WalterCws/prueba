using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaWeb.Models
{    public static class HttpHelper
    {
        
        public static async Task<string> Get(string url)
        {
            string salida = null;
            RestClient client = new RestClient(url);
            client.Timeout = 10000;
            RestRequest request = new RestRequest(Method.GET);            
            var result = await client.ExecuteAsync(request);
            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                salida = result.Content;
            }
            else
            {
                salida = null;
                if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    throw new Exception("Error en el servidor");
                }
                
            }
            return salida;
        }

        public static async Task<IRestResponse> Post(string url, object data)
        {
            RestClient client = new RestClient(url);
            client.Timeout = 10000;
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            var result = await client.ExecuteAsync(request);
            return result;
        }
    }
}
