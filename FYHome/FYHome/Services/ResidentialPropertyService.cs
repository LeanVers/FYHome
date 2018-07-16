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

        public static List<ResidencialProperty> GetResidentialPropertyByPersonId(int personId)
        {
            //https://localhost:44302/api/ResidencialProperties/GetAllAsyncById?personId=
            var URL = "http://www.mocky.io/v2/5b4bfeee3100006300a7de72";

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

        public static Favorite PostFavorite(Favorite favorite)
        {
            var URL = "https://localhost:44302/api/Favorites/PostAsync";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("personID", favorite.PersonID.ToString()),
                new KeyValuePair<string,string>("residencialPropertyId", favorite.ResidencialPropertyId.ToString()),
            });

            HttpClient request = new HttpClient();

            HttpResponseMessage response = request.PostAsync(URL, param).GetAwaiter().GetResult();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var fav = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return JsonConvert.DeserializeObject<Favorite>(fav);
            }

            return null;
        }

        public static List<Favorite> GetAllFavorites()
        {
            //https://localhost:44302/api/Favorites/GetAllAsync
            var URL = "http://www.mocky.io/v2/5b4bf9f53100003f07a7de70";

            HttpClient request = new HttpClient();
            HttpResponseMessage resposta = request.GetAsync(URL).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string content = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                if (content.Length > 2)
                {
                    List<Favorite> lista = JsonConvert.DeserializeObject<List<Favorite>>(content);
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

        public static RecordFilter PostSearch(RecordFilter recFil)
        {
            var URL = "https://localhost:44302/api/RecordFilters/PostAsync";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("rooms", recFil.Rooms.ToString()),
                new KeyValuePair<string,string>("parkingSpaces", recFil.ParkingSpaces.ToString()),
                new KeyValuePair<string,string>("salePriceMin", recFil.SalePriceMin.ToString()),
                new KeyValuePair<string,string>("salePriceMax", recFil.SalePriceMax.ToString()),
                new KeyValuePair<string,string>("state", recFil.State),
                new KeyValuePair<string,string>("city", recFil.City),
                new KeyValuePair<string, string>("uf", recFil.Uf),
                new KeyValuePair<string, string>("neighborhood", recFil.Neighborhood),
                new KeyValuePair<string, string>("personId", recFil.PersonId.ToString())
            });

            HttpClient request = new HttpClient();

            HttpResponseMessage response = request.PostAsync(URL, param).GetAwaiter().GetResult();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var rec = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return JsonConvert.DeserializeObject<RecordFilter>(rec);
            }

            return null;
        }

        public static List<RecordFilter> GetAllSearchSaved()
        {
            //https://localhost:44302/api/RecordFilters/GetAllAsync
            var URL = "http://www.mocky.io/v2/5b4bddb33100001e04a7de5d";

            HttpClient request = new HttpClient();
            HttpResponseMessage resposta = request.GetAsync(URL).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string content = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                if (content.Length > 2)
                {
                    List<RecordFilter> lista = JsonConvert.DeserializeObject<List<RecordFilter>>(content);
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
