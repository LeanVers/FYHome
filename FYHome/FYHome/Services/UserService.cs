using FYHome.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace FYHome.Services
{
    public class UserService : BaseService
    {
        public static Person GetUser(Person user)
        {
            //var URL = urlApi + "/api/People/GetPersonLogin";
            var URL = "http://www.mocky.io/v2/5b4568992f00005400420c00";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("email", user.Email),
                new KeyValuePair<string,string>("passphrase", user.Passphrase)
            });

            HttpClient request = new HttpClient();
            //HttpResponseMessage response = request.PostAsync(URL, param).GetAwaiter().GetResult();

            HttpResponseMessage response = request.PostAsync(URL, param).GetAwaiter().GetResult();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var person = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return JsonConvert.DeserializeObject<Person>(person);
            }

            return null;
        }

        public static Person PostUser(Person user)
        {
            var URL = urlApi + "/api/People/PostAsync";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("name", user.Name),
                new KeyValuePair<string,string>("email", user.Email),
                new KeyValuePair<string,string>("birthdayDate", user.BirthdayDate.ToString()),
                new KeyValuePair<string,string>("cpf", user.CPF),
                new KeyValuePair<string,string>("phone", user.Phone),
                new KeyValuePair<string,string>("passphrase", user.Passphrase)
            });

            HttpClient request = new HttpClient();

            HttpResponseMessage response = request.PostAsync(URL, param).GetAwaiter().GetResult();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var person = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return JsonConvert.DeserializeObject<Person>(person);
            }

            return null;
        }

        public static Person PutUser(Person user)
        {
            var URL = urlApi + "/api/People/PutAsync";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("name", user.Name),
                new KeyValuePair<string,string>("email", user.Email),
                new KeyValuePair<string,string>("birthdayDate", user.BirthdayDate.ToString()),
                new KeyValuePair<string,string>("cpf", user.CPF),
                new KeyValuePair<string,string>("phone", user.Phone),
                new KeyValuePair<string,string>("passphrase", user.Passphrase)
            });

            HttpClient request = new HttpClient();

            HttpResponseMessage response = request.PutAsync(URL, param).GetAwaiter().GetResult();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var person = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return JsonConvert.DeserializeObject<Person>(person);
            }

            return null;
        }
    }
}
