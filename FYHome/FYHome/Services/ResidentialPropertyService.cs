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

        public static ResidencialProperty PostResidencialProperty(ResidencialProperty resProp)
        {
            var URL = "https://localhost:44302/api/ResidencialProperties/PostAsync";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("rooms", resProp.Rooms.ToString()),
                new KeyValuePair<string,string>("parkingSpaces", resProp.ParkingSpaces.ToString()),
                new KeyValuePair<string,string>("area", resProp.Area.ToString()),
                new KeyValuePair<string,string>("additionalInfo", resProp.AdditionalInfo),
                new KeyValuePair<string,string>("salePrice", resProp.SalePrice.ToString()),
                new KeyValuePair<string,string>("description", resProp.Description),
                new KeyValuePair<string, string>("addressId", resProp.AddressId.ToString()),
                new KeyValuePair<string, string>("typeResidencialPropertyId", resProp.TypeResidencialPropertyId.ToString()),
                new KeyValuePair<string, string>("personId", resProp.PersonId.ToString())
            });

            HttpClient request = new HttpClient();

            HttpResponseMessage response = request.PostAsync(URL, param).GetAwaiter().GetResult();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var residProp = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return JsonConvert.DeserializeObject<ResidencialProperty>(residProp);
            }

            return null;
        }
    }
}
