using FYHome.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace FYHome.Util
{
    public class UserUtil
    {
        public static void SetUserLogin(Person user)
        {
            App.Current.Properties["LOGIN"] = JsonConvert.SerializeObject(user);
        }

        public static Person GetUserLogin()
        {
            if (App.Current.Properties.ContainsKey("LOGIN"))
            {
                return JsonConvert.DeserializeObject<Person>((string)App.Current.Properties["LOGIN"]);
            }
            else
            {
                return null;
            }
        }

        public static void SetAddressId(int id)
        {
            App.Current.Properties["ADDRESS_ID"] = id;
        }

        public static int GetAddressId()
        {
            if (App.Current.Properties.ContainsKey("ADDRESS_ID"))
            {
                return int.Parse(App.Current.Properties["ADDRESS_ID"].ToString());
            }
            else
            {
                return 0;
            }
        }

        public static void SetTypeResPropId(int id)
        {
            App.Current.Properties["TYPERESPROP_ID"] = id;
        }

        public static int GetTypeResPropId()
        {
            if (App.Current.Properties.ContainsKey("TYPERESPROP_ID"))
            {
                return int.Parse(App.Current.Properties["TYPERESPROP_ID"].ToString());
            }
            else
            {
                return 0;
            }
        }
    }
}
