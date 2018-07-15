using FYHome.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace FYHome.Services
{
    public class AddressService
    {
        public static Address PostAddress(Address address)
        {
            var URL = "https://localhost:44302/api/Addresses/PostAsync";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {

                new KeyValuePair<string,string>("cep", address.Cep),
                new KeyValuePair<string,string>("street", address.Street),
                new KeyValuePair<string,string>("number", address.Number.ToString()),
                new KeyValuePair<string,string>("neighborhood", address.Neighborhood),
                new KeyValuePair<string,string>("city", address.City),
                new KeyValuePair<string,string>("state", address.State),
                new KeyValuePair<string, string>("country", address.Country),
                new KeyValuePair<string, string>("uf", address.UF),
                new KeyValuePair<string, string>("additionalInfo", address.AdditionalInfo)
            });

            HttpClient request = new HttpClient();

            HttpResponseMessage response = request.PostAsync(URL, param).GetAwaiter().GetResult();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var addr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return JsonConvert.DeserializeObject<Address>(addr);
            }

            return null;
        }
    }
}
