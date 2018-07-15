using FYHome.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace FYHome.Services
{
    public class ResidentialPropertyService
    {
        public static List<ResidencialProperty> GetResidentialProperty()
        {
            //https://localhost:44302/api/ResidencialProperties/GetAllAsync
            var URL = "http://www.mocky.io/v2/5b4abd7b2f000083001e0e6a";

            HttpClient request = new HttpClient();
            HttpResponseMessage resposta = request.GetAsync(URL).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string content = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                if (content.Length > 2)
                {
                    List<ResidencialProperty> lista = JsonConvert.DeserializeObject<List<ResidencialProperty>>(content);
                    return lista;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
