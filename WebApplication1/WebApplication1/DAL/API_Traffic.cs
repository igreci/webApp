using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class API_Traffic
    {
        const string SEARCH_URL = "http://jsonplaceholder.typicode.com/users?email=";

        /// <summary>
        /// Searches API and returns .NET object or null
        /// </summary>
        /// <param name="url">query string</param>
        /// <returns>.NET object</returns>
        public static object GetDataFromApi(string query)
        {
            var client = new WebClient();
            var result = client.DownloadString(SEARCH_URL + query);

            if (!string.IsNullOrWhiteSpace(result))
            {
                Address addr = new Address();
                var jsonResult = JsonConvert.DeserializeObject(result);
                return jsonResult; 
            }
            else
            {
                return null;
            }
        }
    }
}