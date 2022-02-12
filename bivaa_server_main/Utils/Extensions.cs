﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace bivaa_server_main.Utils
{
    public static class Extensions
    {
        public static string toJson(this object obj) => JsonConvert.SerializeObject(obj);

        public static string toJson(this tax_rate taxRate)
        {
            dynamic result = new JObject();
            result.Id = taxRate.id;
            result.Code = taxRate.code;
            result.Name = taxRate.name;
            result.Rate = taxRate.rate;
            // list se da pak udelat napriklad takto
            //result.SomeArray = JArray("1", "2", "3", ...);
            //result.SomeArray = JArray(JObject(...), JObject(...), ...)
            return Convert.ToString(result);
        }

        // Muze byt i jedna genericka metoda pro serializaci podle object typu viz nize
        // switch case typ input objektu a podle vysledku sestaveni dynamic resultu a convert do json
        /*public static string toJson<T>(this T obj)
        {
            dynamic result;
            switch (obj.GetType().Name)
            {
                case "tax_rate":
                    {
                        var taxRate = obj as tax_rate;
                        result = new
                        {
                            Id = taxRate.id,
                            Code = taxRate.code,
                            Name = taxRate.name,
                            Rate = taxRate.rate
                        };
                        break;
                    }

                case "brand": 
                        {
                            ...
                        }
                default:
                    {
                        result = new { result = "OK" };
                        break;
                    }
            }
            return result.toJson();
        }*/

        public static T fromJson<T>(this string obj)
        {
            return JsonConvert.DeserializeObject<T>(obj);
        }

        public static void ApplyJsonContentType(this HttpResponseMessage msg, string mediaType = "application/json")
        {
            msg.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(mediaType);
        }
    }
}