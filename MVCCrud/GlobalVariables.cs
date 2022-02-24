using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MVCCrud
{
    public class GlobalVariables
    {

        public static HttpClient WepApiClient = new HttpClient();

        static GlobalVariables()
        {   
            WepApiClient.BaseAddress = new Uri("https://localhost:44380/api/");
            WepApiClient.DefaultRequestHeaders.Clear();
            WepApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}